param costCenter string
param environmentType string
param resourceLocation string
param sqlDatabaseBackupStorageRedundancy string
param sqlDatabaseCapacity int
param sqlDatabaseCollation string
param sqlDatabaseMaxSizeBytes int
param sqlDatabaseName string
param sqlDatabaseReadScale string
param sqlDatabaseSKUName string
param sqlDatabaseSKUTier string
param sqlDatabaseZoneRedundancyFlag bool
param sqlServerName string

resource sqlServer 'Microsoft.Sql/servers@2022-05-01-preview' existing = {
  name: sqlServerName
}

resource sqlDatabase 'Microsoft.Sql/servers/databases@2022-05-01-preview' = {
  name: sqlDatabaseName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  sku: {
    capacity: sqlDatabaseCapacity
    name: sqlDatabaseSKUName
    tier: sqlDatabaseSKUTier
  }
  parent: sqlServer
  properties: {
    catalogCollation: sqlDatabaseCollation
    collation: sqlDatabaseCollation
    isLedgerOn: false
    maxSizeBytes: sqlDatabaseMaxSizeBytes
    readScale: sqlDatabaseReadScale
    requestedBackupStorageRedundancy: sqlDatabaseBackupStorageRedundancy
    zoneRedundant: sqlDatabaseZoneRedundancyFlag
  }
}
