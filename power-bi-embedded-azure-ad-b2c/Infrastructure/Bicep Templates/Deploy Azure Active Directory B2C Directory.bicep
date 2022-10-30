param azureActiveDirectoryB2CDirectoryCountryCode string
param azureActiveDirectoryB2CDirectoryDisplayName string
param azureActiveDirectoryB2CDirectoryName string
param azureActiveDirectoryB2CDirectorySKU string
param environmentName string
param resourceLocation string

resource azureActiveDirectoryB2CDirectory 'Microsoft.AzureActiveDirectory/b2cDirectories@2021-04-01' = {
  name: azureActiveDirectoryB2CDirectoryName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
  sku: {
    name: azureActiveDirectoryB2CDirectorySKU
    tier: 'A0'
  }
  properties: {
    createTenantProperties: {
      countryCode: azureActiveDirectoryB2CDirectoryCountryCode
      displayName: azureActiveDirectoryB2CDirectoryDisplayName
    }
  }
}
