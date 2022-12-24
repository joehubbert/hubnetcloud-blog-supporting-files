param networkSecurityGroupName string
param virtualNetworkName string
@secure()
param virtualNetworkSubnetAddressSpace string
param virtualNetworkSubnetName string


resource networkSecurityGroup 'Microsoft.Network/networkSecurityGroups@2022-07-01' existing = {
  name: networkSecurityGroupName
}

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' existing = {
  name: virtualNetworkName
}

resource virtualNetworkSubnet 'Microsoft.Network/virtualNetworks/subnets@2022-05-01' = {
  name: virtualNetworkSubnetName
  parent: virtualNetwork
  properties: {
    addressPrefix: virtualNetworkSubnetAddressSpace
    addressPrefixes: [
      virtualNetworkSubnetAddressSpace
    ]
    networkSecurityGroup: {
      id: networkSecurityGroup.id
    }
  }
}
