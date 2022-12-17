@secure()
param azureActiveDirectoryTenantId string
param costCenter string
param keyVaultName string
param environmentType string
param resourceLocation string

var keyVaultPrivateEndpointName = '${keyVaultName}-private-endpoint'

resource keyVault 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: keyVaultName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  properties: {
    createMode: 'default'
    enabledForDeployment: true
    enabledForDiskEncryption: true
    enabledForTemplateDeployment: true
    enablePurgeProtection: true
    enableRbacAuthorization: true
    enableSoftDelete: true
    networkAcls: {
      bypass: 'AzureServices'
      defaultAction: 'Allow'
    }
    publicNetworkAccess: 'Enabled'
    sku: {
      family: 'A'
      name: 'standard'
    }
    softDeleteRetentionInDays: 7
    tenantId: azureActiveDirectoryTenantId
  }
}

resource keyVaultPrivateEndpoint 'Microsoft.KeyVault/vaults/privateEndpointConnections@2022-07-01' = {
  name: keyVaultPrivateEndpointName
  parent: keyVault
  properties: {
    privateEndpoint: {}
  }
}

resource keyVaultRBACAssignment 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: 'string'
  scope: keyVault
  properties: {
    condition: 'string'
    conditionVersion: 'string'
    delegatedManagedIdentityResourceId: 'string'
    description: 'string'
    principalId: 'string'
    principalType: 'string'
    roleDefinitionId: 'string'
  }
}
