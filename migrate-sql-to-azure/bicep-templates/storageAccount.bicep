param costCenter string
param environmentType string
param resourceLocation string
param storageAccountName string

var storageAccountPrivateEndpointName = '${storageAccountName}-private-endpoint'

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-05-01' = {
  name: storageAccountName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  sku: {
    name: 'Standard_ZRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
    allowBlobPublicAccess: true
    allowCrossTenantReplication: true
    allowedCopyScope: 'PrivateLink'
    allowSharedKeyAccess: true
    defaultToOAuthAuthentication: true
    dnsEndpointType: 'Standard'
    isHnsEnabled: false
    isLocalUserEnabled: false
    isNfsV3Enabled: false
    isSftpEnabled: false
    largeFileSharesState: 'Disabled'
    minimumTlsVersion: 'TLS1_2'
    networkAcls: {
      bypass: 'AzureServices'
      defaultAction: 'Deny'
    }
    publicNetworkAccess: 'Enabled'
    supportsHttpsTrafficOnly: true
  }
}

resource storageAccountBlobServices 'Microsoft.Storage/storageAccounts/blobServices@2022-05-01' = {
  name: 'default'
  parent: storageAccount
  properties: {
    automaticSnapshotPolicyEnabled: false
    containerDeleteRetentionPolicy: {
      allowPermanentDelete: true
      days: 7
      enabled: true
    }
    deleteRetentionPolicy: {
      allowPermanentDelete: true
      days: 7
      enabled: true
    }
    isVersioningEnabled: false
  }
}

resource storageAccountPrivateEndpoint 'Microsoft.Storage/storageAccounts/privateEndpointConnections@2022-05-01' = {
  name: storageAccountPrivateEndpointName
  parent: storageAccount
  properties: {
    privateEndpoint: {}
    privateLinkServiceConnectionState: {
      actionRequired: 'None'
      description: 'Auto-Approved as part of deployment'
      status: 'string'
    }
  }
}
