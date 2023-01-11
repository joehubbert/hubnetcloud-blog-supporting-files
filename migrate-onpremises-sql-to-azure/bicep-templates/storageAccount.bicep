param blobPrivateDNSZoneName string
@description('QUA, DEV, PRD')
param environmentCode string
@allowed(['Non-Production','Production'])
@description('Non-Production, Production')
param environmentDescription string
@allowed(['NP','PRD'])
@description('NP = Non-Production | PRD = Production')
param environmentType string
@secure()
param managementSubscriptionId string //DSS
param managementSubscriptionPrivateDNSZoneResourceGroup string //DSS
param resourceGroupNetworking string
param resourceLocation string
param storageAccountName string
@description('e.g. NDS01')
param subscriptionCode string
param virtualNetworkPrivateEndpointSubnetName string
param virtualNetworkName string
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

resource storageAccount 'Microsoft.Storage/storageAccounts@2022-05-01' = {
  name: storageAccountName
  location: resourceLocation
  tags: {
    environmentCode: environmentCode
    environmentDescription: environmentDescription
    environmentType: environmentType
    resourceLocation: resourceLocation
    subscriptionCode: subscriptionCode
  }
  sku: {
    name: 'Standard_RAGZRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
    allowBlobPublicAccess: false
    allowCrossTenantReplication: true
    allowSharedKeyAccess: true
    defaultToOAuthAuthentication: false
    dnsEndpointType: 'Standard'
    encryption: {
      keySource: 'Microsoft.Storage'
      requireInfrastructureEncryption: true
      services: {
        blob: {
          enabled: true
          keyType: 'Account'
        }
        file: {
          enabled: true
          keyType: 'Account'
        }
        queue: {
          enabled: true
          keyType: 'Account'
        }
        table: {
          enabled: true
          keyType: 'Account'
        }
      }
    }
    isHnsEnabled: false
    isLocalUserEnabled: false
    isNfsV3Enabled: false
    isSftpEnabled: false
    keyPolicy: {
      keyExpirationPeriodInDays: 45
    }
    largeFileSharesState: 'Disabled'
    minimumTlsVersion: 'TLS1_2'
    networkAcls: {
      bypass: 'Logging'
      defaultAction: 'Deny'
      ipRules: [
        {
          action: 'Allow'
          value: whitestonePublicIPAddress
        }
      ]
    }
    publicNetworkAccess: 'Enabled'
    supportsHttpsTrafficOnly: true
  }
}

resource storageAccountBlobServices 'Microsoft.Storage/storageAccounts/blobServices@2022-05-01' = {
  name: 'default'
  parent: storageAccount
  properties: {
    containerDeleteRetentionPolicy: {
      allowPermanentDelete: true
      days: 45
      enabled: true
    }
    deleteRetentionPolicy: {
      allowPermanentDelete: true
      days: 45
      enabled: true
    }
    isVersioningEnabled: false
    lastAccessTimeTrackingPolicy: {
      blobType: [
        'blockBlob'
      ]
      enable: true
      name: 'AccessTimeTracking'
      trackingGranularityInDays: 1
    }
    restorePolicy: {
      days: 45
      enabled: false
    }
  }
}

resource cloudWitnessStorageContainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = {
  name: 'msft-cloud-witness'
  parent: storageAccountBlobServices
  properties: {
    metadata: {}
    publicAccess: 'None'
  }
}

resource staticBackupsStorageContainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = {
  name: 'db-static-backups'
  parent: storageAccountBlobServices
  properties: {
    metadata: {}
    publicAccess: 'None'
  }
}

resource privateEndpoint 'Microsoft.Network/privateEndpoints@2022-05-01' = {
  name: '${storageAccountName}-blob-pep'
  dependsOn: [
    storageAccount
  ]
  location: resourceLocation
  tags: {
    associatedResource: storageAccountName
    environmentCode: environmentCode
    environmentDescription: environmentDescription
    environmentType: environmentType
    resourceLocation: resourceLocation
  }
  properties: {
    customNetworkInterfaceName: '${storageAccountName}-blob-pep-nic'
    privateLinkServiceConnections: [
      {
        name: '${storageAccountName}-privateLinkServiceConnection'
        properties: {
          groupIds: [
            'blob'
          ]
          privateLinkServiceId: resourceId('Microsoft.Storage/storageAccounts', storageAccountName)
        }
      }
    ]
    subnet: {
      id: privateEndpointSubnet.id
    }
  }
}

resource privateEndpointDNSZoneGroup 'Microsoft.Network/privateEndpoints/privateDnsZoneGroups@2022-05-01' = {
  name: blobPrivateDNSZoneName
  parent: privateEndpoint
  properties: {
    privateDnsZoneConfigs: [
      {
        name: 'BlobDNSConfig'
        properties: {
          privateDnsZoneId: resourceId(managementSubscriptionId, managementSubscriptionPrivateDNSZoneResourceGroup, 'Microsoft.Network/privateDnsZones', blobPrivateDNSZoneName)
        }
      }
    ]
  }
}
