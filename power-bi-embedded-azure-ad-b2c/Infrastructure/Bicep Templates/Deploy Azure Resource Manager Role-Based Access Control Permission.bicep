param keyVaultName string
param managementResourceGroup string
param userManagedIdentityName string

resource keyVault 'Microsoft.KeyVault/vaults@2022-07-01' existing = {
  name: keyVaultName
}

resource userManagedIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2022-01-31-preview' existing = {
  name: userManagedIdentityName
  scope: resourceGroup(managementResourceGroup)
}

resource addKeyVaultSecretsOfficerPermissions 'Microsoft.Authorization/roleAssignments@2022-04-01' = {
  name: 'string'
  scope: keyVault
  properties: {
    principalId: userManagedIdentity.id
    principalType: 'ServicePrincipal'
    roleDefinitionId: 'b86a8fe4-44ce-4948-aee5-eccb2c155cd7'
  }
}
