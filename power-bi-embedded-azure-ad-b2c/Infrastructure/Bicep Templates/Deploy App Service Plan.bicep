param appServicePlanName string
param appServicePlanSKUFamily string
param appServicePlanSKUName string
param appServicePlanSKUSize string
param environmentName string
param resourceLocation string

resource appServicePlan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: appServicePlanName
  location: resourceLocation
  tags: {
    enivronment: environmentName
  }
  sku: {
    capacity: 1
    family: appServicePlanSKUFamily
    locations: [
      resourceLocation
    ]
    name: appServicePlanSKUName
    size: appServicePlanSKUSize
  }
  kind: 'app'
  properties: {
    elasticScaleEnabled: false
    hyperV: false
    isSpot: false
    isXenon: false
    maximumElasticWorkerCount: 1
    perSiteScaling: true
    reserved: false
    targetWorkerCount: 0
    targetWorkerSizeId: 0
    zoneRedundant: false
  }
}
