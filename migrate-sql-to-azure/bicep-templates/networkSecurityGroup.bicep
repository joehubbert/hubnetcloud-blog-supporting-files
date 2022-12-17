param costCenter string
param environmentType string
param networkSecurityGroupName string
param resourceLocation string

resource networkSecurityGroup 'Microsoft.Network/networkSecurityGroups@2022-05-01' = {
  name: networkSecurityGroupName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  properties: {
    flushConnection: true
  }
}
