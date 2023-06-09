New-Item -Path 'C:\' -Name 'Process' -ItemType 'Directory'
New-Item -Path 'C:\Process' -Name 'DB-Restore' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Restore' -Name 'Configuration' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Restore' -Name 'Credential' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Restore' -Name 'Log' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Restore' -Name 'Script' -ItemType 'Directory'

$azureRecoveryServicesVaultName = Read-Host "Azure Recovery Services Vault Name"

$azureRecoveryServicesVaultResourceGroupName = Read-Host "Azure Recovery Services Vault Resource Group Name"

$azureSubscriptionId = Read-Host -AsSecureString "Azure Subscription Id"
$azureSubscriptionId | Export-CliXml -Path 'C:\Process\DB-Restore\Credential\azureSubscriptionId.xml'

$azureUserManagedIdentityId = Read-Host -AsSecureString "Azure User Managed Identity Id"
$azureUserManagedIdentityId | Export-CliXml -Path 'C:\Process\DB-Restore\Credential\azureUserManagedIdentityId.xml'

$databaseRestoreDirectory = Read-Host "Database Restore Directory"

$sourceInstance = Read-Host "Source Instance"

$sqlServiceCredential = Get-Credential
$sqlServiceCredential | Export-CliXml -Path 'C:\Process\DB-Restore\Credential\sqlServiceCredential.xml'

$targetInstance = Read-Host "Target Instance"

$targetSQLInstanceNameLocalIdentity = Read-Host "Target SQL Instance Name Local Identity"

$configurationSettings = @{
'azureRecoveryServicesVaultName' = $azureRecoveryServicesVaultName
'azureRecoveryServicesVaultResourceGroupName' = $azureRecoveryServicesVaultResourceGroupName
'databaseRestoreDirectory' = $databaseRestoreDirectory
'sourceInstance' = $sourceInstance
'targetInstance' = $targetInstance
'targetSQLInstanceNameLocalIdentity' = $targetSQLInstanceNameLocalIdentity
}

$configurationSettingsFile = $configurationSettings | ConvertTo-Json
New-Item -Path 'C:\Process\DB-Restore\Configuration' -Name 'processConfig.json' -ItemType File -Value $configurationSettingsFile