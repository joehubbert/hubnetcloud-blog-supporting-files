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
param virtualNetworkSubnetName string

resource virtualNetworkSubnet 'Microsoft.Network/virtualNetworks/subnets@2022-05-01' existing = {
  name: virtualNetworkSubnetName
}

resource networkInterfaceCard 'Microsoft.Network/networkInterfaces@2022-05-01' = {
  name: '${virtualMachineName}-nic-001'
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  properties: {
    enableAcceleratedNetworking: true
    ipConfigurations: [
      {
        name: '${virtualMachineName}-nic-001-ip-configuration'
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
    enivronmentType: environmentType
  }
  properties: {
    additionalCapabilities: {
      hibernationEnabled: true
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
      networkApiVersion: '2020-11-01'
      networkInterfaces: [
        {
          id: networkInterfaceCard.id
        }
      ]
    }
    osProfile: {
      adminPassword: virtualMachineAdminUsername
      adminUsername: virtualMachineAdminPassword
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
          enableHotpatching: true
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
