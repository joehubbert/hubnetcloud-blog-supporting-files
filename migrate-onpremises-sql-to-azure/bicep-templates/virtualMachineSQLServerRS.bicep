@description('QUA, DEV, PRD')
param environmentCode string
@allowed(['Non-Production','Production'])
@description('Non-Production, Production')
param environmentDescription string
@allowed(['NP','PRD'])
@description('NP = Non-Production | PRD = Production')
param environmentType string
@secure()
param networkInterfaceCardIPAddress string
param resourceGroupManagement string
param resourceGroupNetworking string
param resourceLocation string
@description('e.g. NDS01')
param subscriptionCode string
@secure()
param virtualMachineAdminPassword string
@secure()
param virtualMachineAdminUsername string
param virtualMachineMaintenanceConfigurationName string
param virtualMachineName string
param virtualMachineSize string
param virtualNetworkName string
param virtualNetworkSubnetName string

resource virtualMachineMaintenanceConfiguration 'Microsoft.Maintenance/maintenanceConfigurations@2022-07-01-preview' existing = {
  name: virtualMachineMaintenanceConfigurationName
  scope: resourceGroup(resourceGroupManagement)
}

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' existing = {
  name: virtualNetworkName
  scope: resourceGroup(resourceGroupNetworking)
}

resource virtualMachineNetworkInterfaceCardSubnet 'Microsoft.Network/virtualNetworks/subnets@2022-05-01' existing = {
  name: virtualNetworkSubnetName
  parent: virtualNetwork
}

resource virtualMachineNetworkInterfaceCard 'Microsoft.Network/networkInterfaces@2022-05-01' = {
  name: '${virtualMachineName}-nic-01'
  location: resourceLocation
  tags: {
    associatedResource: virtualMachineName
    environmentCode: environmentCode
    environmentDescription: environmentDescription
    environmentType: environmentType
    resourceLocation: resourceLocation
    subscriptionCode: subscriptionCode
  }
  properties: {
    enableAcceleratedNetworking: true
    enableIPForwarding: false
    ipConfigurations: [
      {
        name: '${virtualMachineName}-nic-01-configuration'
        properties: {
          primary: true
          privateIPAddress: networkInterfaceCardIPAddress
          privateIPAddressVersion: 'IPv4'
          privateIPAllocationMethod: 'Static'
          subnet: {
            id: virtualMachineNetworkInterfaceCardSubnet.id
          }
        }
      }
    ]
    nicType: 'Standard'
  }
}

resource virtualMachine 'Microsoft.Compute/virtualMachines@2022-08-01' = {
  name: virtualMachineName
  location: resourceLocation
  tags: {
    environmentCode: environmentCode
    environmentDescription: environmentDescription
    environmentType: environmentType
    resourceLocation: resourceLocation
    subscriptionCode: subscriptionCode
  }
  properties: {
    additionalCapabilities: {
      hibernationEnabled: false
      ultraSSDEnabled: false
    }
    diagnosticsProfile: {
      bootDiagnostics: {
        enabled: true
      }
    }
    hardwareProfile: {
      vmSize: virtualMachineSize
    }
    licenseType: 'Windows_Server'
    networkProfile: {
      networkInterfaces: [
        {
          id: virtualMachineNetworkInterfaceCard.id
          properties: {
            deleteOption: 'Delete'
            primary: true
          }
        }
      ]
    }
    osProfile: {
      adminPassword: virtualMachineAdminPassword
      adminUsername: virtualMachineAdminUsername
      allowExtensionOperations: true
      computerName: virtualMachineName
      windowsConfiguration: {
        enableAutomaticUpdates: true
        enableVMAgentPlatformUpdates: true
        patchSettings: {
          assessmentMode: 'AutomaticByPlatform'
          automaticByPlatformSettings: {
            rebootSetting: 'IfRequired'
          }
          enableHotpatching: false
          patchMode: 'AutomaticByPlatform'
        }
        provisionVMAgent: true
        timeZone: 'UTC'
      }
    }
    priority: 'Regular'
    securityProfile: {
      encryptionAtHost: true
    }
    storageProfile: {
      dataDisks: [
        {
          createOption: 'Empty'
          deleteOption: 'Detach'
          diskSizeGB: 32
          caching: 'ReadOnly'
          lun: 0
          managedDisk: {
            storageAccountType: 'StandardSSD_LRS'
          }
          name: '${virtualMachineName}-sql-data-disk'
        }
        {
          createOption: 'Empty'
          deleteOption: 'Detach'
          diskSizeGB: 32
          caching: 'None'
          lun: 1
          managedDisk: {
            storageAccountType: 'StandardSSD_LRS'
          }
          name: '${virtualMachineName}-sql-log-disk'
        }
        {
          createOption: 'Empty'
          deleteOption: 'Detach'
          diskSizeGB: 32
          caching: 'None'
          lun: 2
          managedDisk: {
            storageAccountType: 'StandardSSD_LRS'
          }
          name: '${virtualMachineName}-sql-backup-disk'
        }
        {
          createOption: 'Empty'
          deleteOption: 'Detach'
          diskSizeGB: 128
          caching: 'None'
          lun: 3
          managedDisk: {
            storageAccountType: 'StandardSSD_LRS'
          }
          name: '${virtualMachineName}-sql-tempdb-disk'
        }
      ]
      imageReference: {
        offer: 'WindowsServer'
        publisher: 'MicrosoftWindowsServer'
        sku: '2022-datacenter-azure-edition'
        version: 'latest'
      }
      osDisk: {
        createOption: 'FromImage'
        deleteOption: 'Detach'
        diskSizeGB: 128
        caching: 'ReadWrite'
        managedDisk: {
          storageAccountType: 'StandardSSD_LRS'
        }
        name: '${virtualMachineName}-os-disk'
        osType: 'Windows'
      }
    }
  }
}

resource virtualMachineMaintenanceConfigurationAssignment 'Microsoft.Maintenance/configurationAssignments@2022-07-01-preview' = {
  name: '${virtualMachineName}-maintenance-configuration-assignment'
  location: resourceLocation
  scope: virtualMachine
  properties: {
    maintenanceConfigurationId: virtualMachineMaintenanceConfiguration.id
  }
}
