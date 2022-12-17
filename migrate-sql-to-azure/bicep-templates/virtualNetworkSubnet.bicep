param natGatewayName string
param natGatewayResourceGroupName string
param networkSecurityGroupName string
param networkSecurityGroupResourceGroupName string
param virtualNetworkName string
@secure()
param virtualNetworkSubnetAddressSpace string
param virtualNetworkSubnetName string

resource natGateway 'Microsoft.Network/natGateways@2022-05-01' existing = {
  name: natGatewayName
  scope: resourceGroup(natGatewayResourceGroupName)
}

resource networkSecurityGroup 'Microsoft.Network/networkSecurityGroups@2022-07-01' existing = {
  name: networkSecurityGroupName
  scope: resourceGroup(networkSecurityGroupResourceGroupName)
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
    natGateway: {
      id: natGateway.id
    }
    networkSecurityGroup: {
      id: networkSecurityGroup.id
    }
  }
}
