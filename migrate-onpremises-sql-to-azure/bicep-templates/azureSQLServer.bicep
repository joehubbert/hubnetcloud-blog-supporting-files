param azureActiveDirectorySQLServerAdministrator string
param azureActiveDirectorySQLServerAdministratorSID string
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
      login: azureActiveDirectorySQLServerAdministrator
      sid: azureActiveDirectorySQLServerAdministratorSID
      principalType: 'User'
      tenantId: azureActiveDirectoryTenantId
    }
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Disabled'
    restrictOutboundNetworkAccess: 'Disabled'
    version: '12.0'
  }
}

resource privateEndpoint 'Microsoft.Network/privateEndpoints@2022-05-01' = {
  name: '${sqlServerName}-sqlserver-pep'
  dependsOn: [
    sqlServer
  ]
  location: resourceLocation
  tags: {
    costCenter: costCenter
    environmentType: environmentType
  }
  properties: {
    customNetworkInterfaceName: '${sqlServerName}-sqlserver-pep-nic'
    privateLinkServiceConnections: [
      {
        name: '${sqlServerName}-privateLinkServiceConnection'
        properties: {
          groupIds: [
            'sqlServer'
          ]
          privateLinkServiceId: resourceId('Microsoft.Sql/servers', sqlServerName)
        }
      }
    ]
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

resource sqlServerPrivateEndpointDNSZoneGroup 'Microsoft.Network/privateEndpoints/privateDnsZoneGroups@2022-07-01' = {
  name: sqlServerPrivateDNSZoneName
  parent: privateEndpoint
  properties: {
    privateDnsZoneConfigs: [
      {
        name: 'SqlServerDNSConfig'
        properties: {
          privateDnsZoneId: resourceId('Microsoft.Network/privateDnsZones', sqlServerPrivateDNSZoneName)
        }
      }
    ]
  }
}
