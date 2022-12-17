param publicAccessType string
param storageAccountContainerName string
param storageAccountName string

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-05-01' existing = {
  name: storageAccountName
}

resource storageAccountBlobServices 'Microsoft.Storage/storageAccounts/blobServices@2022-09-01' existing = {
  name: 'default'
  parent: storageAccount
}

resource storageAccountContainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = {
  name: storageAccountContainerName
  parent: storageAccountBlobServices
  properties: {
    publicAccess: publicAccessType
  }
}
