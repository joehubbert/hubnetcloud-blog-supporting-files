param bastionName string
param bastionScaleUnits int
param bastionSKU string
param costCenter string
param environmentType string
param publicIPAddressName string
param resourceLocation string
param virtualNetworkName string
param virtualNetworkSubnetName string

resource publicIPAddress 'Microsoft.Network/publicIPAddresses@2022-05-01' existing = {
  name: publicIPAddressName
}

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' existing = {
  name: virtualNetworkName
}

resource virtualNetworkSubnet 'Microsoft.Network/virtualNetworks/subnets@2022-05-01' existing = {
  name: virtualNetworkSubnetName
  parent: virtualNetwork
}

resource bastionHost 'Microsoft.Network/bastionHosts@2022-05-01' = {
  name: bastionName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    environmentType: environmentType
  }
  sku: {
    name: bastionSKU
  }
  properties: {
    disableCopyPaste: false
    enableFileCopy: true
    enableIpConnect: true
    enableShareableLink: true
    enableTunneling: true
    ipConfigurations: [
      {
        name: 'bastion-ip-configuration'
        properties: {
          privateIPAllocationMethod: 'Dynamic'
          publicIPAddress: {
            id: publicIPAddress.id
          }
          subnet: {
            id: virtualNetworkSubnet.id
          }
        }
      }
    ]
    scaleUnits: bastionScaleUnits
  }
}
