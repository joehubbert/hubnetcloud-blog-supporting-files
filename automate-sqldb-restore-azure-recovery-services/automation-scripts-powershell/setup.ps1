New-Item -Path 'C:\' -Name 'Process' -ItemType 'Directory'
New-Item -Path 'C:\Process' -Name 'DB-Restore' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Restore' -Name 'Configuration' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Restore' -Name 'Credential' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Restore' -Name 'Log' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Restore' -Name 'Script' -ItemType 'Directory'

$azureRecoveryServicesVaultName = Read-Host "Azure Recovery Services Vault Name"
$azureRecoveryServicesVaultResourceGroupName = Read-Host "Azure Recovery Services Vault Resource Group Name"
$azureSubscriptionId = Read-Host "Azure Subscription Id"
$azureUserManagedIdentityId = Read-Host "Azure User Managed Identity Id"
$databaseRestoreDirectory = Read-Host "Database Restore Directory"
$dbmsManagementDatabase = Read-Host "DBMS Management Database"
$sourceInstance = Read-Host "Source Instance"
$sourceInstanceCode = Read-Host "Source Instance Code"
$sqlServiceCredential = Get-Credential
$sqlServiceCredential | Export-CliXml -Path 'C:\Process\DB-Restore\Credential\sqlServiceCredential.xml'
$targetInstance = Read-Host "Target Instance"
$targetSQLInstanceNameLocalIdentity = Read-Host "Target SQL Instance Name Local Identity"

$configurationSettings = @{
'azureRecoveryServicesVaultName' = $azureRecoveryServicesVaultName
'azureRecoveryServicesVaultResourceGroupName' = $azureRecoveryServicesVaultResourceGroupName
'azureSubscriptionId' = $azureSubscriptionId
'azureUserManagedIdentityId' = $azureUserManagedIdentityId
'databaseRestoreDirectory' = $databaseRestoreDirectory
'dbmsManagementDatabase' = $dbmsManagementDatabase
'sourceInstance' = $sourceInstance
'sourceInstanceCode' = $sourceInstanceCode
'targetInstance' = $targetInstance
'targetSQLInstanceNameLocalIdentity' = $targetSQLInstanceNameLocalIdentity
}

$configurationSettingsFile = $configurationSettings | ConvertTo-Json
New-Item -Path 'C:\Process\DB-Restore\Configuration' -Name 'processConfig.json' -ItemType File -Value $configurationSettingsFile