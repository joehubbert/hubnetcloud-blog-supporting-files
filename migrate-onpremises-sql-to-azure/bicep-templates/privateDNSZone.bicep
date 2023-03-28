param costCenter string
param environmentType string
param privateDNSZoneName string
param resourceLocation string
param virtualNetworkName string

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' existing = {
  name: virtualNetworkName
}

resource privateDNSZone 'Microsoft.Network/privateDnsZones@2020-06-01' = {
  name: privateDNSZoneName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    environmentType: environmentType
  }
}

resource privateDNSZoneVirtualNetworkLink 'Microsoft.Network/privateDnsZones/virtualNetworkLinks@2020-06-01' = {
  name: '${privateDNSZoneName}-to-${virtualNetworkName}'
  location: resourceLocation
  tags: {
    costCenter: costCenter
    environmentType: environmentType
  }
  parent: privateDNSZone
  properties: {
    registrationEnabled: false
    virtualNetwork: {
      id: virtualNetwork.id
    }
  }
}
