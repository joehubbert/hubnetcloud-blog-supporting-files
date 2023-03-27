targetScope = 'subscription'

param costCenter string
param environmentType string
param resourceGroupName string
param resourceLocation string

resource resourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: resourceGroupName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    environmentType: environmentType
  }
}
