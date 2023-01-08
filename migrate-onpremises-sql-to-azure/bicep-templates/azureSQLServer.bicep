param azureActiveDirectorySQLServerAdministrator string
param azureActiveDirectoryTenantId string
param costCenter string
param environmentType string
param resourceLocation string
@secure()
param sqlServerAdministratorPassword string
@secure()
param sqlServerAdministratorUsername string
param sqlServerName string
param sqlServerPrivateDNSZoneName string
param virtualNetworkName string
param virtualNetworkSubnetName string

resource privateDNSZone 'Microsoft.Network/privateDnsZones@2020-06-01' existing = {
  name: sqlServerPrivateDNSZoneName
}

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' existing = {
  name: virtualNetworkName
}

resource virtualNetworkSubnet 'Microsoft.Network/virtualNetworks/subnets@2022-05-01' existing = {
  name: virtualNetworkSubnetName
  parent: virtualNetwork
}

resource sqlServer 'Microsoft.Sql/servers@2022-05-01-preview' = {
  name: sqlServerName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    environmentType: environmentType
  }
  properties: {
    administratorLogin: sqlServerAdministratorUsername
    administratorLoginPassword: sqlServerAdministratorPassword
    administrators: {
      administratorType: 'ActiveDirectory'
      azureADOnlyAuthentication: false
      sid: azureActiveDirectorySQLServerAdministrator
      principalType: 'User'
      tenantId: azureActiveDirectoryTenantId
    }
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Disabled'
    restrictOutboundNetworkAccess: 'Disabled'
    version: '12.0'
  }
}

resource sqlServerPrivateEndpoint 'Microsoft.Network/privateEndpoints@2022-05-01' = {
  name: '${sqlServerName}-sqlserver-pep'
  location: resourceLocation
  tags: {
    costCenter: costCenter
    environmentType: environmentType
  }
  properties: {
    customNetworkInterfaceName: '${sqlServerName}-sqlserver-pep-nic'
    ipConfigurations: [
      {
        name: '${sqlServerName}-sqlserver-pep-nic-ip-configuration'
        properties: {
          groupId: privateDNSZone.id
          memberName: sqlServerName
        }
      }
    ]
    subnet: {
      id: virtualNetworkSubnet.id
    }
  }
}

resource sqlServerPrivateEndpointConnection 'Microsoft.Sql/servers/privateEndpointConnections@2022-05-01-preview' = {
  name: '${sqlServerName}-sqlserver-pep-connection'
  parent: sqlServer
  properties: {
    privateEndpoint: {
      id: sqlServerPrivateEndpoint.id
    }
  }
}
