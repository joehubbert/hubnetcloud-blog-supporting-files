param costCenter string
param environmentType string
param resourceLocation string
@secure()
param virtualMachineAdminUsername string
@secure()
param virtualMachineAdminPassword string
param virtualMachineName string
@secure()
param virtualMachinePrivateIPAddress string
param virtualMachineSize string
param virtualNetworkName string
param virtualNetworkSubnetName string

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2022-05-01' existing = {
  name: virtualNetworkName
}

resource virtualNetworkSubnet 'Microsoft.Network/virtualNetworks/subnets@2022-05-01' existing = {
  name: virtualNetworkSubnetName
  parent: virtualNetwork
}

resource virtualMachineNetworkInterfaceCard 'Microsoft.Network/networkInterfaces@2022-05-01' = {
  name: '${virtualMachineName}-nic-01'
  location: resourceLocation
  tags: {
    associatedResource: virtualMachineName
    environmentType: environmentType
    resourceLocation: resourceLocation
  }
  properties: {
    enableAcceleratedNetworking: true
    enableIPForwarding: false
    ipConfigurations: [
      {
        name: '${virtualMachineName}-nic-01-configuration'
        properties: {
          primary: true
          privateIPAddress: virtualMachinePrivateIPAddress
          privateIPAddressVersion: 'IPv4'
          privateIPAllocationMethod: 'Static'
          subnet: {
            id: virtualNetworkSubnet.id
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
    costCenter: costCenter
    environmentType: environmentType
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
    licenseType: 'Windows-Server'
    networkProfile: {
      networkInterfaces: [
        {
          id: virtualMachineNetworkInterfaceCard.id
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
    storageProfile: {
      dataDisks: [
        {
          caching: 'ReadOnly'
          createOption: 'Empty'
          deleteOption: 'Detach'
          detachOption: 'ForceDetach'
          diskSizeGB: 32
          lun: 0
          managedDisk: {
            storageAccountType: 'StandardSSD_LRS'
          }
          name: '${virtualMachineName}-SQL-Data-Disk'
        }
        {
          caching: 'None'
          createOption: 'Empty'
          deleteOption: 'Detach'
          detachOption: 'ForceDetach'
          diskSizeGB: 32
          lun: 0
          managedDisk: {
            storageAccountType: 'StandardSSD_LRS'
          }
          name: '${virtualMachineName}-SQL-Log-Disk'
        }
        {
          caching: 'None'
          createOption: 'Empty'
          deleteOption: 'Detach'
          detachOption: 'ForceDetach'
          diskSizeGB: 32
          lun: 0
          managedDisk: {
            storageAccountType: 'StandardSSD_LRS'
          }
          name: '${virtualMachineName}-SQL-Log-TempDB'
        }
        {
          caching: 'None'
          createOption: 'Empty'
          deleteOption: 'Detach'
          detachOption: 'ForceDetach'
          diskSizeGB: 32
          lun: 0
          managedDisk: {
            storageAccountType: 'StandardSSD_LRS'
          }
          name: '${virtualMachineName}-SQL-Log-Backup'
        }
      ]
      imageReference: {
        offer: 'WindowsServer'
        publisher: 'MicrosoftWindowsServer'
        sku: '2012-r2-datacenter-gensecond'
        version: 'latest'
      }
      osDisk: {
        caching: 'ReadWrite'
        createOption: 'fromImage'
        deleteOption: 'Detach'
        diskSizeGB: 127
        managedDisk: {
          storageAccountType: 'StandardSSD_LRS'
        }
        name: '${virtualMachineName}-OS-Disk'
        osType: 'Windows'
        writeAcceleratorEnabled: false
      }
    }
  }
}
