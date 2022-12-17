@secure()
param destinationVirtualNetworkAddressSpace string
param destinationVirtualNetworkName string
param destinationVirtualNetworkResourceGroup string
@secure()
param sourceVirtualNetworkAddressSpace string
param sourceVirtualNetworkName string

resource sourceVirtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' existing = {
  name: sourceVirtualNetworkName
}

resource destinationVirtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' existing = {
  name: destinationVirtualNetworkName
  scope: resourceGroup(destinationVirtualNetworkResourceGroup)
}

resource sourceToDestinationVirtualNetworkPeering 'Microsoft.Network/virtualNetworks/virtualNetworkPeerings@2022-05-01' = {
  name: '${sourceVirtualNetworkName}-${destinationVirtualNetworkName}-peering'
  parent: sourceVirtualNetwork
  properties: {
    allowForwardedTraffic: true
    allowGatewayTransit: true
    allowVirtualNetworkAccess: true
    doNotVerifyRemoteGateways: true
    remoteAddressSpace: {
      addressPrefixes: [
        sourceVirtualNetworkAddressSpace
      ]
    }
    remoteVirtualNetwork: {
      id: destinationVirtualNetwork.id
    }
    remoteVirtualNetworkAddressSpace: {
      addressPrefixes: [
        destinationVirtualNetworkAddressSpace
      ]
    }
    useRemoteGateways: true
  }
}
