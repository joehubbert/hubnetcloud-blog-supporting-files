param environmentName string
param resourceLocation string
param virtualNetworkAddressSpace string
param virtualNetworkName string
param virtualNetworkPrivateEndpointSubnetAddressSpace string
param virtualNetworkPrivateEndpointSubnetName string

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' = {
  name: virtualNetworkName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
  properties: {
    addressSpace: {
      addressPrefixes: [
        virtualNetworkAddressSpace
      ]
    }
    enableDdosProtection: false
    enableVmProtection: false
    encryption: {
      enabled: true
      enforcement: 'AllowUnencrypted'
    }
    subnets: [
      {
        name: virtualNetworkPrivateEndpointSubnetName
        properties: {
          addressPrefix: virtualNetworkPrivateEndpointSubnetAddressSpace
        }
      }
    ]
  }
}
