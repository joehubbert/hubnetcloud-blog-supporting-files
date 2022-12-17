param costCenter string
param environmentType string
param logAnalyticsWorkspaceName string
param resourceLocation string

resource logAnalyticsWorkspace 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
  name: logAnalyticsWorkspaceName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  properties: {
    features: {
      disableLocalAuth: false
      enableDataExport: true
      immediatePurgeDataOn30Days: false
    }
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
    retentionInDays: 30
    sku: {
      name: 'PerGB2018'
    }
  }
}
