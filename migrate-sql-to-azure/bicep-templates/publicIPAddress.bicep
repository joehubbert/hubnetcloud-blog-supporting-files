param costCenter string
param environmentType string
param publicIPAddressName string
param resourceLocation string

resource publicIPAddress 'Microsoft.Network/publicIPAddresses@2022-05-01' = {
  name: publicIPAddressName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  sku: {
    name: 'Standard'
    tier: 'Regional'
  }
  properties: {
    deleteOption: 'detach'
    idleTimeoutInMinutes: 4
    publicIPAddressVersion: 'IPv4'
    publicIPAllocationMethod: 'Static'
  }
  zones: [
  ]
}
