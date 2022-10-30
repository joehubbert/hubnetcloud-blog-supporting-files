param environmentName string
@secure()
param powerBIEmbeddedResourceAdministrator string
param powerBIEmbeddedResourceName string
param powerBIEmbeddedResourceSKUCapacity int
param powerBIEmbeddedResourceSKUName string
param resourceLocation string

resource powerBIEmbedded 'Microsoft.PowerBIDedicated/capacities@2021-01-01' = {
  name: powerBIEmbeddedResourceName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
  sku: {
    capacity: powerBIEmbeddedResourceSKUCapacity
    name: powerBIEmbeddedResourceSKUName
    tier: 'PBIE_Azure'
  }
  properties: {
    administration: {
      members: [
        powerBIEmbeddedResourceAdministrator
      ]
    }
    mode: 'Gen2'
  }
}
