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
param virtualNetworkName string
param virtualNetworkSubnetName string

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
    publicNetworkAccess: 'Enabled'
    restrictOutboundNetworkAccess: 'Disabled'
    version: '12.0'
  }
}

resource sqlServerVirtualNetworkRule 'Microsoft.Sql/servers/virtualNetworkRules@2022-08-01-preview' = {
  name: '${sqlServerName}-${virtualNetworkSubnetName}-rule'
  parent: sqlServer
  properties: {
    ignoreMissingVnetServiceEndpoint: false
    virtualNetworkSubnetId: virtualNetworkSubnet.id
  }
}
