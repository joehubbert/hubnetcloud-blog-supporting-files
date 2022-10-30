param azureSQLDatabaseName string
param azureSQLDatabaseSKUName string
param azureSQLDatabaseSKUTier string
param azureSQLLogicalServerName string
param environmentName string
param resourceLocation string

resource azureSQLLogicalServer 'Microsoft.Sql/servers@2022-05-01-preview' existing = {
  name: azureSQLLogicalServerName
}

resource azureSQLDatabase 'Microsoft.Sql/servers/databases@2022-05-01-preview' = {
  name: azureSQLDatabaseName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
  sku: {
    capacity: 50
    name: azureSQLDatabaseSKUName
    tier: azureSQLDatabaseSKUTier
  }
  parent: azureSQLLogicalServer
  properties: {
    catalogCollation: 'SQL_Latin1_General_CP1_CI_AS'
    collation: 'SQL_Latin1_General_CP1_CI_AS'
    createMode: 'Default'
    isLedgerOn: false
    licenseType: 'LicenseIncluded'
    preferredEnclaveType: 'Default'
    requestedBackupStorageRedundancy: 'GeoZone'
    zoneRedundant: false
  }
}
