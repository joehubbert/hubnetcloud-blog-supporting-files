param environmentName string
param privateDNSZoneName string
param resourceLocation string

resource privateDNSZone 'Microsoft.Network/privateDnsZones@2020-06-01' = {
  name: privateDNSZoneName
  location: resourceLocation
  tags: {
    environment: environmentName
  }
}
