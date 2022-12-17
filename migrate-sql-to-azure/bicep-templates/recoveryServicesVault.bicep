param costCenter string
param environmentType string
param recoveryServicesVaultName string
param resourceLocation string

var backupPolicySQLDB = 'sql-backup-policy'
var backupPolicyVM = 'vm-backup-policy'

resource recoveryServicesVault 'Microsoft.RecoveryServices/vaults@2022-09-30-preview' = {
  name: recoveryServicesVaultName
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  sku: {
    name: 'RS0'
    tier: 'Standard'
  }
  properties: {
    monitoringSettings: {
      azureMonitorAlertSettings: {
        alertsForAllJobFailures: 'Enabled'
      }
    }
    publicNetworkAccess: 'Enabled'
  }
}

resource sqlDBBackupPolicy 'Microsoft.RecoveryServices/vaults/backupPolicies@2022-09-01-preview' = {
  name: backupPolicySQLDB
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  parent: recoveryServicesVault
  properties: {
    backupManagementType: 'AzureWorkload'
    makePolicyConsistent: true
    settings: {
      isCompression: true
      issqlcompression: true
      timeZone: 'UTC'
    }
    subProtectionPolicy: [
      {
          policyType: 'Full'
          schedulePolicy: {
              schedulePolicyType: 'SimpleSchedulePolicy'
              scheduleRunFrequency: 'Daily'
              scheduleRunTimes: [
                  '2022-12-17T21:00:00Z'
              ]
              scheduleWeeklyFrequency: 0
          }
          retentionPolicy: {
              retentionPolicyType: 'LongTermRetentionPolicy'
              dailySchedule: {
                  retentionTimes: [
                      '2022-12-17T21:00:00Z'
                  ]
                  retentionDuration: {
                      count: 7
                      durationType: 'Days'
                  }
              }
              weeklySchedule: {
                  daysOfTheWeek: [
                      'Sunday'
                  ]
                  retentionTimes: [
                      '2022-12-17T21:00:00Z'
                  ]
                  retentionDuration: {
                      count: 4
                      durationType: 'Weeks'
                  }
              }
              monthlySchedule: {
                  retentionScheduleFormatType: 'Weekly'
                  retentionScheduleWeekly: {
                      daysOfTheWeek: [
                          'Sunday'
                      ]
                      weeksOfTheMonth: [
                          'First'
                      ]
                  }
                  retentionTimes: [
                      '2022-12-17T21:00:00Z'
                  ]
                  retentionDuration: {
                      count: 12
                      durationType: 'Months'
                  }
              }
              yearlySchedule: {
                  retentionScheduleFormatType: 'Weekly'
                  monthsOfYear: [
                      'July'
                  ]
                  retentionScheduleWeekly: {
                      daysOfTheWeek: [
                          'Sunday'
                      ]
                      weeksOfTheMonth: [
                          'Last'
                      ]
                  }
                  retentionTimes: [
                      '2022-12-17T21:00:00Z'
                  ]
                  retentionDuration: {
                      count: 2
                      durationType: 'Years'
                  }
              }
          }
      }
      {
          policyType: 'Log'
          schedulePolicy: {
              schedulePolicyType: 'LogSchedulePolicy'
              scheduleFrequencyInMins: 15
          }
          retentionPolicy: {
              retentionPolicyType: 'SimpleRetentionPolicy'
              retentionDuration: {
                  count: 7
                  durationType: 'Days'
              }
          }
      }
  ]
  }
}


resource vmBackupPolicy 'Microsoft.RecoveryServices/vaults/backupPolicies@2022-03-01' = {
  name: backupPolicyVM
  location: resourceLocation
  tags: {
    costCenter: costCenter
    enivronmentType: environmentType
  }
  parent: recoveryServicesVault
  properties: {
    backupManagementType: 'AzureIaasVM'
    instantRPDetails: {
      azureBackupRGNamePrefix: 'vmbackup'
    }
    instantRpRetentionRangeInDays: 2
    policyType: 'V2'
    retentionPolicy: {
      retentionPolicyType: 'LongTermRetentionPolicy'
      dailySchedule: {
        retentionDuration: {
          count: 31
          durationType: 'Days'
        }
        retentionTimes: [
          '2022-10-21T02:00:00+00:00'
        ]
      }
      monthlySchedule: {
        retentionDuration: {
          count: 12
          durationType: 'Months'
        }
        retentionScheduleDaily: {
          daysOfTheMonth: [
            {
              date: 1
              isLast: false
            }
          ]
        }
        retentionScheduleFormatType: 'Daily'
        retentionTimes: [
          '2022-10-21T02:00:00+00:00'
        ]
      }
      yearlySchedule: {
        monthsOfYear: [
          'July'
        ]
        retentionDuration: {
          count: 2
          durationType: 'Years'
        }
        retentionScheduleDaily: {
          daysOfTheMonth: [
            {
              date: 1
              isLast: false
            }
          ]
        }
        retentionScheduleFormatType: 'Daily'
        retentionTimes: [
          '2022-10-21T02:00:00+00:00'
        ]
      }
    }
    schedulePolicy: {
      schedulePolicyType: 'SimpleSchedulePolicyV2'
      scheduleRunFrequency: 'Daily'
      dailySchedule: {
        scheduleRunTimes: [
          '2022-10-21T02:00:00+00:00'
        ]
      }
    }
    timeZone: 'UTC'
  }
}
