param environmentName string
param resourceLocation string
param userManagedIdentityName string

resource userManagedIdentity 'Microsoft.ManagedIdentity/userAssignedIdentities@2022-01-31-preview' = {
  name: userManagedIdentityName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
}
