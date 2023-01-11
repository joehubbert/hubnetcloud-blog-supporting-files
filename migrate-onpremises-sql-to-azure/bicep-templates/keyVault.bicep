@secure()
param azureActiveDirectoryTenantId string
@description('QUA, DEV, PRD')
param environmentCode string
@allowed(['Non-Production','Production'])
@description('Non-Production, Production')
param environmentDescription string
@allowed(['NP','PRD'])
@description('NP = Non-Production | PRD = Production')
param environmentType string
param keyVaultName string
param managementSubscriptionId string //DSS
param managementSubscriptionPrivateDNSZoneResourceGroup string
param resourceGroupNetworking string
param resourceLocation string
@description('e.g. NDS01')
param subscriptionCode string
param vaultPrivateDNSZoneName string
param virtualNetworkName string
param virtualNetworkPrivateEndpointSubnetName string
@secure()
param whitestonePublicIPAddress string

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' existing = {
  name: virtualNetworkName
  scope: resourceGroup(resourceGroupNetworking)
}

resource privateEndpointSubnet 'Microsoft.Network/virtualNetworks/subnets@2022-05-01' existing = {
  name: virtualNetworkPrivateEndpointSubnetName
  parent: virtualNetwork
}

resource keyVault 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: keyVaultName
  location: resourceLocation
  tags: {
    environmentCode: environmentCode
    environmentDescription: environmentDescription
    environmentType: environmentType
    resourceLocation: resourceLocation
    subscriptionCode: subscriptionCode
  }
  properties: {
    createMode: 'default'
    enabledForDeployment: true
    enabledForDiskEncryption: true
    enabledForTemplateDeployment: true
    enablePurgeProtection: true
    enableRbacAuthorization: true
    enableSoftDelete: true
    networkAcls: {
      bypass: 'AzureServices'
      defaultAction: 'Deny'
      ipRules: [
        {
          value: whitestonePublicIPAddress
        }
      ]
    }
    publicNetworkAccess: 'Enabled'
    sku: {
      family: 'A'
      name: 'standard'
    }
    softDeleteRetentionInDays: 45
    tenantId: azureActiveDirectoryTenantId
  }
}

resource privateEndpoint 'Microsoft.Network/privateEndpoints@2022-05-01' = {
  name: '${keyVaultName}-vault-pep'
  dependsOn: [
    keyVault
  ]
  location: resourceLocation
  tags: {
    associatedResource: keyVaultName
    environmentCode: environmentCode
    environmentDescription: environmentDescription
    environmentType: environmentType
    resourceLocation: resourceLocation
  }
  properties: {
    customNetworkInterfaceName: '${keyVaultName}-vault-pep-nic'
    privateLinkServiceConnections: [
      {
        name: '${keyVaultName}-privateLinkServiceConnection'
        properties: {
          groupIds: [
            'vault'
          ]
          privateLinkServiceId: resourceId('Microsoft.KeyVault/vaults', keyVaultName)
        }
      }
    ]
    subnet: {
      id: privateEndpointSubnet.id
    }
  }
}

resource privateEndpointDNSZoneGroup 'Microsoft.Network/privateEndpoints/privateDnsZoneGroups@2022-05-01' = {
  name: vaultPrivateDNSZoneName
  parent: privateEndpoint
  properties: {
    privateDnsZoneConfigs: [
      {
        name: 'VaultDNSConfig'
        properties: {
          privateDnsZoneId: resourceId(managementSubscriptionId, managementSubscriptionPrivateDNSZoneResourceGroup, 'Microsoft.Network/privateDnsZones', vaultPrivateDNSZoneName)
        }
      }
    ]
  }
}
