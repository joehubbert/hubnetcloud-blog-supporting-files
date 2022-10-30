@secure()
param azureActiveDirectoryTenantId string
@secure()
param azureSQLLogicalServerAADAuthLoginName string
@secure()
param azureSQLLogicalServerAADAuthPrincipalType string
@secure()
param azureSQLLogicalServerAADAuthSID string
param azureSQLLogicalServerName string
@secure()
param azureSQLLogicalServerSQLAuthPassword string
@secure()
param azureSQLLogicalServerSQLAuthUsername string
param environmentName string
param resourceLocation string

resource azureSQLLogicalServer 'Microsoft.Sql/servers@2022-05-01-preview' = {
  name: azureSQLLogicalServerName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
  properties: {
    administratorLogin: azureSQLLogicalServerSQLAuthUsername
    administratorLoginPassword: azureSQLLogicalServerSQLAuthPassword
    administrators: {
      administratorType: 'ActiveDirectory'
      azureADOnlyAuthentication: false
      login: azureSQLLogicalServerAADAuthLoginName
      principalType: azureSQLLogicalServerAADAuthPrincipalType
      sid: azureSQLLogicalServerAADAuthSID
      tenantId: azureActiveDirectoryTenantId
    }
    minimalTlsVersion: '1.2'
    publicNetworkAccess: 'Enabled'
    restrictOutboundNetworkAccess: 'Disabled'
    version: '12.0'
  }
}
