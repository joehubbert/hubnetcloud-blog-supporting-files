param costCenter string
param currentTimestamp string = utcNow('u')
param environmentType string
param maintenanceConfigurationName string
param resourceLocation string

resource maintenanceConfiguration 'Microsoft.Maintenance/maintenanceConfigurations@2022-07-01-preview' = {
  name: maintenanceConfigurationName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  properties: {
    installPatches: {
      rebootSetting: 'IfRequired'
      linuxParameters: {
        classificationsToInclude: [
          'Critical'
          'Security'
        ]
      }
      windowsParameters: {
        classificationsToInclude: [
          'Critical'
          'Security'
          'UpdateRollup'
          'FeaturePack'
          'ServicePack'
          'Definition'
          'Tools'
          'Updates'
        ]
      }
    }
    maintenanceScope: 'Guest'
    maintenanceWindow: {
      duration: '02:00'
      recurEvery: 'Month Second Wednesday'
      startDateTime: currentTimestamp
      timeZone: 'UTC'
    }
  }
}
