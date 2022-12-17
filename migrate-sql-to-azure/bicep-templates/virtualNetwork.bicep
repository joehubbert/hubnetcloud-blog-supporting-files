param costCenter string
param environmentType string
param resourceLocation string
@secure()
param virtualNetworkAddressSpace string
@secure()
param virtualNetworkDNSServerAPrivateIPAddress string
@secure()
param virtualNetworkDNSServerBPrivateIPAddress string
param virtualNetworkName string

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' = {
  name: virtualNetworkName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  properties: {
    addressSpace: {
      addressPrefixes: [
        virtualNetworkAddressSpace
      ]
    }
    dhcpOptions: {
      dnsServers: [
        virtualNetworkDNSServerAPrivateIPAddress
        virtualNetworkDNSServerBPrivateIPAddress
      ]
    }
  }
}
