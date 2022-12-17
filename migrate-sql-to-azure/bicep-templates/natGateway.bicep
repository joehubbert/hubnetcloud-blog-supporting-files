param costCenter string
param environmentType string
param natGatewayName string
param publicIPAddressName string
param resourceLocation string

resource publicIPAddress 'Microsoft.Network/publicIPAddresses@2022-05-01' existing = {
  name: publicIPAddressName
}

resource natGateway 'Microsoft.Network/natGateways@2022-05-01' = {
  name: natGatewayName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  sku: {
    name: 'Standard'
  }
  properties: {
    idleTimeoutInMinutes: 4
    publicIpAddresses: [
      {
        id: publicIPAddress.id
      }
    ]
  }
  zones: [
  ]
}
