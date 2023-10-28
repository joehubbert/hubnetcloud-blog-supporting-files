New-Item -Path 'C:\' -Name 'Process' -ItemType 'Directory'
New-Item -Path 'C:\Process' -Name 'DB-Obfuscate' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Obfuscate' -Name 'Configuration' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Obfuscate' -Name 'Credential' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Obfuscate' -Name 'Log' -ItemType 'Directory'
New-Item -Path 'C:\Process\DB-Obfuscate' -Name 'Script' -ItemType 'Directory'

$azureBlobSASToken = Read-Host "Azure Blob Storage SAS Token"
$azureBlobSASToken | ConvertTo-SecureString -AsPlainText -Force | ConvertFrom-SecureString | Set-Content -Path 'C:\Process\DB-Obfuscate\Credential\azureBlobSASToken.txt'
$azureBlobStorageContainer = Read-Host "Azure Blob Storage Container"
$azureBlobStorageContainerURL = Read-Host "Azure Blob Storage Container URL"
$azureBlobStorageEndpoint = Read-Host "Azure Blob Storage Endpoint"
$azureRecoveryServicesVaultName = Read-Host "Azure Recovery Services Vault Name"
$azureRecoveryServicesVaultResourceGroupName = Read-Host "Azure Recovery Services Vault Resource Group Name"
$azureSubscriptionId = Read-Host "Azure Subscription Id"
$azureUserManagedIdentityId = Read-Host "Azure User Managed Identity Id"
$databaseRestoreDirectory = Read-Host "Database Restore Directory"
$sourceInstance = Read-Host "Source Instance"
$sourceInstanceCode = Read-Host "Source Instance Code"
$sqlServiceCredential = Get-Credential
$sqlServiceCredential | Export-CliXml -Path 'C:\Process\DB-Obfuscate\Credential\sqlServiceCredential.xml'
$targetInstance = Read-Host "Target Instance"
$targetSQLInstanceNameLocalIdentity = Read-Host "Target SQL Instance Name Local Identity"

$configurationSettings = @{
'azureBlobStorageContainer' = $azureBlobStorageContainer
'azureBlobStorageContainerURL' = $azureBlobStorageContainerURL
'azureBlobStorageEndpoint' = $azureBlobStorageEndpoint
'azureRecoveryServicesVaultName' = $azureRecoveryServicesVaultName
'azureRecoveryServicesVaultResourceGroupName' = $azureRecoveryServicesVaultResourceGroupName
'azureSubscriptionId' = $azureSubscriptionId
'azureUserManagedIdentityId' = $azureUserManagedIdentityId
'databaseRestoreDirectory' = $databaseRestoreDirectory
'sourceInstance' = $sourceInstance
'sourceInstanceCode' = $sourceInstanceCode
'targetInstance' = $targetInstance
'targetSQLInstanceNameLocalIdentity' = $targetSQLInstanceNameLocalIdentity
}

$configurationSettingsFile = $configurationSettings | ConvertTo-Json
New-Item -Path 'C:\Process\DB-Obfuscate\Configuration' -Name 'processConfig.json' -ItemType File -Value $configurationSettingsFile