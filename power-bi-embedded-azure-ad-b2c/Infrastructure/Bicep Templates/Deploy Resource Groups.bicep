param applicationResourceGroupName string
param dataResourceGroupName string
param environmentName string
param managementResourceGroupName string
param networkResourceGroupName string
param resourceLocation string

targetScope = 'subscription'

resource deployApplicationResourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: applicationResourceGroupName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
}

resource deployDataResourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: dataResourceGroupName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
}

resource deployManagementResourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: managementResourceGroupName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
}

resource deployNetworkResourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: networkResourceGroupName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
}
