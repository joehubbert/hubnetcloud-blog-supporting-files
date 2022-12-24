param azureActiveDirectorySQLServerAdministrator string
param azureActiveDirectoryTenantId string
param costCenter string
param currentDate string = utcNow('yyyyMMdd')
param environmentType string
param resourceLocation string
param resourceLocationShort string
@secure()
param sqlServerAdministratorPassword string
@secure()
param sqlServerAdministratorUsername string
@secure()
param virtualMachineAdminPassword string
@secure()
param virtualMachineAdminUsername string

var azureSQLServerName = 'wingitairlines-${currentDate}'
var bastionName = 'bastion-wingitdemo-${resourceLocationShort}'
var bastionPublicIPAddressName = 'bastion-public-ip'
var bastionSubnetAddressSpace = '10.13.0.0/26'
var bastionSubnetName = 'AzureBastionSubnet'
var networkSecurityGroupName = 'wingitdemo-${resourceLocationShort}-nsg'
var privateEndpointSubnetAddressSPace = '10.13.0.96/27'
var privateEndpointSubnetName = 'private-endpoint-subnet'
var sqlPrivateDNSZoneName = 'privatelink.${environment().suffixes.sqlServerHostname}'
var sqlVMSubnetAddressSpace = '10.13.0.64/28'
var sqlVMSubnetName = 'sql-vm-subnet'
var virtualMachineADDSServerAPrivateIP = '10.13.0.84'
var virtualMachineADDSServerBPrivateIP = '10.13.0.85'
var virtualMachineSQLServerPrivateIP = '10.13.0.68'
var virtualMachineSubnetAddressSpace = '10.13.0.80/28'
var virtualMachineSubnetName = 'vm-subnet'
var virtualNetworkName = 'wingitairlines-core-vnet'

module networkSecurityGroup 'networkSecurityGroup.bicep' = {
  name: 'deployNetworkSecurityGroup'
  params: {
    costCenter: costCenter
    environmentType: environmentType
    networkSecurityGroupName: networkSecurityGroupName
    resourceLocation: resourceLocation
  }
}

module remoteDesktopRuleSQLVM 'networkSecurityGroupRule.bicep' = {
  name: 'deployRemoteDesktopRuleSQLVM'
  dependsOn: [
    networkSecurityGroup
  ]
  params: {
    networkSecurityGroupName: networkSecurityGroupName
    networkSecurityGroupRuleAccess: 'Allow'
    networkSecurityGroupRuleDescription: 'Allows access between Bastion and SQL VM Subnet for RDP'
    networkSecurityGroupRuleDestinationAddressPrefix: sqlVMSubnetAddressSpace
    networkSecurityGroupRuleDestinationPortRange: '3389'
    networkSecurityGroupRuleDirection: 'Inbound'
    networkSecurityGroupRulePriority: 100
    networkSecurityGroupRuleProtocol: 'TCP'
    networkSecurityGroupRuleSourceAddressPrefix: bastionSubnetAddressSpace
    networkSecurityGroupRuleSourcePortRange: '*'
    networkSecurityGroupRuleName: 'Allow_Bastion_RDP_Access_SQLVM'
  }
}

module remoteDesktopRuleADDSVM 'networkSecurityGroupRule.bicep' = {
  name: 'deployRemoteDesktopRuleADDSVM'
  dependsOn: [
    networkSecurityGroup
  ]
  params: {
    networkSecurityGroupName: networkSecurityGroupName
    networkSecurityGroupRuleAccess: 'Allow'
    networkSecurityGroupRuleDescription: 'Allows access between Bastion and VM Subnet for RDP'
    networkSecurityGroupRuleDestinationAddressPrefix: virtualMachineSubnetAddressSpace
    networkSecurityGroupRuleDestinationPortRange: '3389'
    networkSecurityGroupRuleDirection: 'Inbound'
    networkSecurityGroupRulePriority: 101
    networkSecurityGroupRuleProtocol: 'TCP'
    networkSecurityGroupRuleSourceAddressPrefix: bastionSubnetAddressSpace
    networkSecurityGroupRuleSourcePortRange: '*'
    networkSecurityGroupRuleName: 'Allow_Bastion_RDP_Access_VM'
  }
}

module dnsRule 'networkSecurityGroupRule.bicep' = {
  name: 'deployDNSRule'
  dependsOn: [
    networkSecurityGroup
  ]
  params: {
    networkSecurityGroupName: networkSecurityGroupName
    networkSecurityGroupRuleAccess: 'Allow'
    networkSecurityGroupRuleDescription: 'Allows access between VM Subnet and SQL VM subnet for DNS'
    networkSecurityGroupRuleDestinationAddressPrefix: virtualMachineSubnetAddressSpace
    networkSecurityGroupRuleDestinationPortRange: '53'
    networkSecurityGroupRuleDirection: 'Inbound'
    networkSecurityGroupRulePriority: 102
    networkSecurityGroupRuleProtocol: 'TCP'
    networkSecurityGroupRuleSourceAddressPrefix: sqlVMSubnetAddressSpace
    networkSecurityGroupRuleSourcePortRange: '*'
    networkSecurityGroupRuleName: 'Allow_DNS_VM_SQLVM'
  }
}

module httpsRuleVM 'networkSecurityGroupRule.bicep' = {
  name: 'deployHTTPSVMSubnetRule'
  dependsOn: [
    networkSecurityGroup
  ]
  params: {
    networkSecurityGroupName: networkSecurityGroupName
    networkSecurityGroupRuleAccess: 'Allow'
    networkSecurityGroupRuleDescription: 'Allows access between VM Subnet and the internet'
    networkSecurityGroupRuleDestinationAddressPrefix: '*'
    networkSecurityGroupRuleDestinationPortRange: '443'
    networkSecurityGroupRuleDirection: 'Outbound'
    networkSecurityGroupRulePriority: 103
    networkSecurityGroupRuleProtocol: 'TCP'
    networkSecurityGroupRuleSourceAddressPrefix: virtualMachineSubnetAddressSpace
    networkSecurityGroupRuleSourcePortRange: '*'
    networkSecurityGroupRuleName: 'Allow_HTTPS_VM'
  }
}

module httpsRuleSQLVM 'networkSecurityGroupRule.bicep' = {
  name: 'deployHTTPSSQLVMSubnetRule'
  dependsOn: [
    networkSecurityGroup
  ]
  params: {
    networkSecurityGroupName: networkSecurityGroupName
    networkSecurityGroupRuleAccess: 'Allow'
    networkSecurityGroupRuleDescription: 'Allows access between SQLVM Subnet and the internet'
    networkSecurityGroupRuleDestinationAddressPrefix: '*'
    networkSecurityGroupRuleDestinationPortRange: '443'
    networkSecurityGroupRuleDirection: 'Outbound'
    networkSecurityGroupRulePriority: 104
    networkSecurityGroupRuleProtocol: 'TCP'
    networkSecurityGroupRuleSourceAddressPrefix: sqlVMSubnetAddressSpace
    networkSecurityGroupRuleSourcePortRange: '*'
    networkSecurityGroupRuleName: 'Allow_HTTPS_SQLVM'
  }
}

module privateDNSZone 'privateDNSZone.bicep' = {
  name: 'deploySQLPrivateDNSZone'
  params: {
    costCenter: costCenter
    environmentType: environmentType
    privateDNSZoneName: sqlPrivateDNSZoneName
    resourceLocation: resourceLocation    
  }
}

module virtualNetwork 'virtualNetwork.bicep' = {
  name: 'deployVirtualNetwork'
  params: {
    costCenter: costCenter
    environmentType: environmentType
    resourceLocation: resourceLocation
    virtualNetworkAddressSpace: '10.13.0.0/24'
    virtualNetworkDNSServerAPrivateIPAddress: virtualMachineADDSServerAPrivateIP
    virtualNetworkDNSServerBPrivateIPAddress: virtualMachineADDSServerBPrivateIP
    virtualNetworkName: virtualNetworkName
  }
}

module bastionSubnet 'virtualNetworkSubnet.bicep' = {
  name: 'deployBastionSubnet'
  dependsOn: [
    virtualNetwork, networkSecurityGroup
  ]
  params: {
    networkSecurityGroupName: networkSecurityGroupName
    virtualNetworkName: virtualNetworkName
    virtualNetworkSubnetAddressSpace: bastionSubnetAddressSpace
    virtualNetworkSubnetName: bastionSubnetName
  }
}

module sqlVMSubnet 'virtualNetworkSubnet.bicep' = {
  name: 'deploySQLVMSubnet'
  dependsOn: [
    virtualNetwork, networkSecurityGroup
  ]
  params: {
    networkSecurityGroupName: networkSecurityGroupName
    virtualNetworkName: virtualNetworkName
    virtualNetworkSubnetAddressSpace: sqlVMSubnetAddressSpace
    virtualNetworkSubnetName: sqlVMSubnetName
  }
}

module vmSubnet 'virtualNetworkSubnet.bicep' = {
  name: 'deployVMSubnet'
  dependsOn: [
    virtualNetwork, networkSecurityGroup
  ]
  params: {
    networkSecurityGroupName: networkSecurityGroupName
    virtualNetworkName: virtualNetworkName
    virtualNetworkSubnetAddressSpace: virtualMachineSubnetAddressSpace
    virtualNetworkSubnetName: virtualMachineSubnetName
  }
}

module privateEndpointSubnet 'virtualNetworkSubnet.bicep' = {
  name: 'deployPrivateEndpointSubnet'
  dependsOn: [
    virtualNetwork, networkSecurityGroup
  ]
  params: {
    networkSecurityGroupName: networkSecurityGroupName
    virtualNetworkName: virtualNetworkName
    virtualNetworkSubnetAddressSpace: privateEndpointSubnetAddressSPace
    virtualNetworkSubnetName: privateEndpointSubnetName
  }
}

module bastionPublicIpAddress 'publicIPAddress.bicep' = {
  name: 'deployBastionPublicIPAddress'
  params: {
    costCenter: costCenter
    environmentType: environmentType
    publicIPAddressName: bastionPublicIPAddressName
    resourceLocation: resourceLocation
  }
}

module bastion 'bastion.bicep' = {
  name: 'deployBastion'
  dependsOn: [
    bastionSubnet, bastionPublicIpAddress
  ]
  params: {
    bastionName: bastionName
    bastionScaleUnits: 2
    bastionSKU: 'Standard'
    costCenter: costCenter
    environmentType: environmentType
    publicIPAddressName: bastionPublicIPAddressName
    resourceLocation: resourceLocation
    virtualNetworkName: virtualNetworkName
    virtualNetworkSubnetName: bastionSubnetName
  }
}

module domainControllerA 'virtualMachineVanilla.bicep' = {
  name: 'deployADDSServerA'
  dependsOn: [
    vmSubnet
  ]
  params: {
    costCenter: costCenter
    environmentType: environmentType
    resourceLocation: resourceLocation
    virtualMachineAdminPassword: virtualMachineAdminPassword
    virtualMachineAdminUsername: virtualMachineAdminUsername
    virtualMachinePrivateIPAddress: virtualMachineADDSServerAPrivateIP
    virtualMachineName: 'azvm${resourceLocationShort}adds001'
    virtualMachineSize: 'Standard_D2ads_v5'
    virtualNetworkSubnetName: virtualMachineSubnetName
  }
}

module domainControllerB 'virtualMachineVanilla.bicep' = {
  name: 'deployADDSServerB'
  dependsOn: [
    vmSubnet
  ]
  params: {
    costCenter: costCenter
    environmentType: environmentType
    resourceLocation: resourceLocation
    virtualMachineAdminPassword: virtualMachineAdminPassword
    virtualMachineAdminUsername: virtualMachineAdminUsername
    virtualMachinePrivateIPAddress: virtualMachineADDSServerBPrivateIP
    virtualMachineName: 'azvm${resourceLocationShort}adds002'
    virtualMachineSize: 'Standard_D2ads_v5'
    virtualNetworkSubnetName: virtualMachineSubnetName
  }
}

module sqlServerVirtualMachine 'virtualMachineSQLLegacy.bicep' = {
  name: 'deploySQLServerVirtualMachine'
  dependsOn: [
    sqlVMSubnet
  ]
  params: {
    costCenter: costCenter
    environmentType: environmentType
    resourceLocation: resourceLocation
    virtualMachineAdminPassword: virtualMachineAdminPassword
    virtualMachineAdminUsername: virtualMachineAdminUsername
    virtualMachinePrivateIPAddress: virtualMachineSQLServerPrivateIP
    virtualMachineName: 'azvm${resourceLocationShort}sql2014001'
    virtualMachineSize: 'Standard_D2ads_v5'
    virtualNetworkSubnetName: virtualMachineSubnetName    
  }
}

module azureSQLServer 'azureSQLServer.bicep' = {
  name: 'deployAzureSQLLogicalServer'
  dependsOn: [
    privateEndpointSubnet, privateDNSZone
  ]
  params: {
    azureActiveDirectorySQLServerAdministrator: azureActiveDirectorySQLServerAdministrator
    azureActiveDirectoryTenantId: azureActiveDirectoryTenantId
    costCenter: costCenter
    environmentType: environmentType
    resourceLocation: resourceLocation
    sqlServerAdministratorPassword: sqlServerAdministratorPassword
    sqlServerAdministratorUsername: sqlServerAdministratorUsername
    sqlServerName: azureSQLServerName
    sqlServerPrivateDNSZoneName: sqlPrivateDNSZoneName
    virtualNetworkName: virtualNetworkName
    virtualNetworkSubnetName: privateEndpointSubnetName
  }
}

module azureSQLDatabase 'azureSQLDatabase.bicep' = {
  name: 'deployAzureSQLDatabase'
  dependsOn: [
    azureSQLServer
  ]
  params: {
    costCenter: costCenter
    environmentType: environmentType
    resourceLocation: resourceLocation
    sqlDatabaseBackupStorageRedundancy: 'Local'
    sqlDatabaseCapacity: 5
    sqlDatabaseCollation: 'SQL_Latin1_General_CP1_CI_AS'
    sqlDatabaseMaxSizeBytes: 2147483648
    sqlDatabaseName: 'wingitairlines-sales'
    sqlDatabaseReadScale: 'Disabled'
    sqlDatabaseSKUName: 'Basic'
    sqlDatabaseSKUTier: 'Basic'
    sqlDatabaseZoneRedundancyFlag: false
    sqlServerName: azureSQLServerName
  }
}
