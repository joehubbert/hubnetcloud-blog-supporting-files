@secure()
param bastionSubnetAddressSpace string
param bastionSubnetName string
param costCenter string
param environmentType string
param networkSecurityGroupName string
@secure()
param privateEndpointSubnetAddressSpace string
param privateEndpointSubnetName string
param resourceLocation string
@secure()
param sqlVMSubnetAddressSpace string
param sqlVMSubnetName string
@secure()
param virtualMachineSubnetAddressSpace string
param virtualMachineSubnetName string
@secure()
param virtualNetworkAddressSpace string
@secure()
param virtualNetworkDNSServerAPrivateIPAddress string
@secure()
param virtualNetworkDNSServerBPrivateIPAddress string
param virtualNetworkName string

resource networkSecurityGroup 'Microsoft.Network/networkSecurityGroups@2022-07-01' existing = {
  name: networkSecurityGroupName
}

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' = {
  name: virtualNetworkName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    environmentType: environmentType
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
    subnets: [
      {
        name: bastionSubnetName
        properties: {
          addressPrefix: bastionSubnetAddressSpace
          addressPrefixes: [
            bastionSubnetAddressSpace
          ]
        }
      }
      {
        name: sqlVMSubnetName
        properties: {
          addressPrefix: sqlVMSubnetAddressSpace
          addressPrefixes: [
            sqlVMSubnetAddressSpace
          ]
          networkSecurityGroup: {
            id: networkSecurityGroup.id
          }
        }
      }
      {
        name: virtualMachineSubnetName
        properties: {
          addressPrefix: virtualMachineSubnetAddressSpace
          addressPrefixes: [
            virtualMachineSubnetAddressSpace
          ]
          networkSecurityGroup: {
            id: networkSecurityGroup.id
          }
        }
      }
      {
        name: privateEndpointSubnetName
        properties: {
          addressPrefix: privateEndpointSubnetAddressSpace
          addressPrefixes: [
            privateEndpointSubnetAddressSpace
          ]
        }
      }
    ]
  }
}
