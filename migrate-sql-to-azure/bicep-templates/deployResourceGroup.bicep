targetScope = 'subscription'

param costCenter string
param environmentType string
param resourceGroupName string
param resourceLocation string

module demoResourceGroup 'resourceGroup.bicep' = {
  name: 'deployDemoResourceGroup'
  params: {
    costCenter: costCenter
    environmentType: environmentType
    resourceGroupName: resourceGroupName
    resourceLocation: resourceLocation
  }
}
