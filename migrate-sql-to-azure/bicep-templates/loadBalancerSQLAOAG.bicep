param backendAddressPoolName string
param costCenter string
param environmentType string
@secure()
param frontendIPConfigurationSQLEndpointPrivateIPAddress string
@secure()
param frontendIPConfigurationWSFCEndpointPrivateIPAddress string
param loadBalancerName string
param resourceLocation string
param virtualNetworkResourceGroupName string
param virtualNetworkSubnetName string

var frontendIPConfigurationSQLEndpoint = 'frontend-ip-sql-endpoint'
var frontendIPConfigurationWSFCEndpoint = 'frontend-ip-wsfc-endpoint'
var loadBalancingRuleSQLEndpoint = 'load-balancing-rule-sql-endpoint'
var loadBalancingRuleWSFCEndpoint = 'load-balancing-rule-wsfc-endpoint'
var probeSQLEndpoint = 'probe-sql-endpoint'
var probeWSFCEndpoint = 'probe-wsfc-endpoint'

resource virtualNetworkSubnet 'Microsoft.Network/virtualNetworks/subnets@2022-05-01' existing = {
  name: virtualNetworkSubnetName
  scope: resourceGroup(virtualNetworkResourceGroupName)
}

resource loadBalancer 'Microsoft.Network/loadBalancers@2022-05-01' = {
  name: loadBalancerName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  sku: {
    name: 'Standard'
    tier: 'Regional'
  }
  properties: {
    backendAddressPools: [
      {
        name: backendAddressPoolName
        properties: {
          drainPeriodInSeconds: 5
        }
      }
    ]
    frontendIPConfigurations: [
      {
        name: frontendIPConfigurationSQLEndpoint
        properties: {
          privateIPAddress: frontendIPConfigurationSQLEndpointPrivateIPAddress
          privateIPAddressVersion: 'IPv4'
          privateIPAllocationMethod: 'Static'
          subnet: {
            id: virtualNetworkSubnet.id
          }
        }
        zones: [
          '1,2,3'
        ]
      }
      {
        name: frontendIPConfigurationWSFCEndpoint
        properties: {
          privateIPAddress: frontendIPConfigurationWSFCEndpointPrivateIPAddress
          privateIPAddressVersion: 'IPv4'
          privateIPAllocationMethod: 'Static'
          subnet: {
            id: virtualNetworkSubnet.id
          }
        }
        zones: [
          '1,2,3'
        ]
      }
    ]
    loadBalancingRules: [
      {
        name: loadBalancingRuleSQLEndpoint
        properties: {
          backendAddressPool: {
            id: resourceId('Microsoft.Network/loadBalancers/backendAddressPools', loadBalancerName, backendAddressPoolName)
          }
          backendPort: 1433
          enableFloatingIP: true
          frontendIPConfiguration: {
            id: resourceId('Microsoft.Network/loadBalancers/frontendIpConfigurations', loadBalancerName, frontendIPConfigurationSQLEndpoint)
          }
          frontendPort: 1433
          idleTimeoutInMinutes: 4
          probe: {
            id: resourceId('Microsoft.Network/loadBalancers/probes', loadBalancerName, probeSQLEndpoint)
          }
          protocol: 'TCP'
        }
      }
      {
        name: loadBalancingRuleWSFCEndpoint
        properties: {
          backendAddressPool: {
            id: resourceId('Microsoft.Network/loadBalancers/backendAddressPools', loadBalancerName, backendAddressPoolName)
          }
          backendPort: 58888
          enableFloatingIP: true
          frontendIPConfiguration: {
            id: resourceId('Microsoft.Network/loadBalancers/frontendIpConfigurations', loadBalancerName, frontendIPConfigurationWSFCEndpoint)
          }
          frontendPort: 58888
          idleTimeoutInMinutes: 4
          probe: {
            id: resourceId('Microsoft.Network/loadBalancers/probes', loadBalancerName, probeWSFCEndpoint)
          }
          protocol: 'TCP'
        }
      }
    ]
    probes: [
      {
        name: probeSQLEndpoint
        properties: {
          intervalInSeconds: 5
          port: 59999
          protocol: 'TCP'
        }
      }
      {
        name: probeWSFCEndpoint
        properties: {
          intervalInSeconds: 5
          port: 58888
          protocol: 'TCP'
        }
      }
    ]
  }
}
