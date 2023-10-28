#Set Params
param
(
    [Parameter(Mandatory)][String]$azureBlobSASToken,
    [Parameter(Mandatory)][String]$configFilePath,
    [Parameter(Mandatory)][Array]$databaseLogicalFileArray,
    [Parameter(Mandatory)][String]$databaseName,
    [Parameter(Mandatory)][System.Management.Automation.PSCredential]$sqlServiceCredential,
    [Parameter(Mandatory)][Array]$sqlStoredProcedureArray
)

#Unpack Configuration Settings
$configurationSettings = Get-Content $configFilePath | Out-String | ConvertFrom-Json

#Set Global Variables
$azureBlobStorageContainer = $configurationSettings.azureBlobStorageContainer
$azureBlobStorageContainerURL = $configurationSettings.azureBlobStorageContainerURL
$azureBlobStorageEndpoint = $configurationSettings.azureBlobStorageEndpoint
$azureSubscriptionId = $configurationSettings.azureSubscriptionId
$azureUserManagedIdentityId = $configurationSettings.azureUserManagedIdentityId
$azureContext = (Connect-AzAccount -Identity -AccountId $azureUserManagedIdentityId).context
$azureContext = Set-AzContext -Subscription $azureSubscriptionId -DefaultProfile $azureContext
$azureRecoveryServicesVaultName = $configurationSettings.azureRecoveryServicesVaultName
$azureRecoveryServicesVaultResourceGroupName = $configurationSettings.azureRecoveryServicesVaultResourceGroupName
$azureRecoveryServicesVault = (Get-AzRecoveryServicesVault -ResourceGroupName $azureRecoveryServicesVaultResourceGroupName -Name $azureRecoveryServicesVaultName).ID
$azureBlobStorageContext = New-AzStorageContext -SasToken $azureBlobSASToken -BlobEndpoint $azureBlobStorageEndpoint
$correlationId = New-Guid
$databaseRestoreDirectory = $configurationSettings.databaseRestoreDirectory
$errorActionPreference = 'Stop'
$sourceInstance = $configurationSettings.sourceInstance
$sourceInstanceCode = $configurationSettings.sourceInstanceCode
$targetInstance = $configurationSettings.targetInstance
$targetSQLInstanceNameLocalIdentity = $configurationSettings.targetSQLInstanceNameLocalIdentity
$week = (Get-Date -UFormat %V)
$year = (Get-Date -Format yyyy)
$databaseBackupBlobName = "$year-Week-$week/$databaseName.BAK"
$databaseBackupURLPath = "$azureBlobStorageContainerURL/$databaseBackupBlobName"

#Import SQL Server PowerShell Module
#NOSQLPS
Import-Module SqlServer

#Create Logging Function
function ObfuscationLog
{
    param
    (
        [Parameter(Mandatory)][string]$operationType,
        [Parameter(Mandatory)][string]$operationMessage,
        [Parameter(Mandatory)][string]$operationOutcome
    )

    try
    {
        $query = "EXEC [dbo].[WriteObfuscationOperationLogMessage] @correlationId = '$correlationId', @databaseName = '$databaseName', @operationType = '$operationType', @operationMessage = '$operationMessage', @operationOutcome = '$operationOutcome'"
        Write-Host $query
        Invoke-SqlCmd `
        -Credential $sqlServiceCredential `
        -Database 'ObfuscationManager' `
        -Query $query `
        -ServerInstance $targetSQLInstanceNameLocalIdentity
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $outputText = "An error occured with the following message: '$exception $exceptionMessage $exceptionMessageDetail"
        Write-Host $outputText
    }
}

$outputText = "Execution of db-obfuscate.ps1 for $databaseName successfully started on $env:computername"
Write-Host $outputText
ObfuscationLog -operationType 'Script Execution Started' -operationMessage $outputText -operationOutcome 'Successful'

#Import Az PowerShell Module
try
{
    Import-Module Az
    $outputText = "The PowerShell module Az has been imported on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'PowerShell Module Import - Az' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when importing the PowerShell module Az on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'PowerShell Module Import - Az' -operationMessage $outputText -operationOutcome 'Failed'
}

#Set Restore Target Information
try
{
    $targetContainer = Get-AzRecoveryServicesBackupContainer -ContainerType 'AzureVMAppContainer' -VaultId $azureRecoveryServicesVault -FriendlyName $targetInstance
    $outputText = "The target backup container for $targetInstance was successfully retrieved from Azure Recovery Services on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Set Restore Target Information' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when retrieving the backup container for $targetInstance from Azure Recovery Services on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Set Restore Target Information' -operationMessage $outputText -operationOutcome 'Failed'
}

#Get Database Backup Item From Recovery Services Vault
try
{
    $databaseBackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType 'AzureWorkload' -WorkloadType 'MSSQL' -VaultId $azureRecoveryServicesVault | Where-Object {$_.ServerName -eq $sourceInstance} | Where-Object {$_.Name -eq ("SQLDataBase;$sourceInstanceCode;$databaseName")}
    $outputText = "Backup item $sourceInstance;$databaseName was successfully retrieved from Azure Recovery Services on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Get Database Backup Item From Recovery Services Vault' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when retrieving the backup item $sourceInstance;$databaseName from Azure Recovery Services on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Get Database Backup Item From Recovery Services Vault' -operationMessage $outputText -operationOutcome 'Failed'
}

#Get Database Backup Item Recovery Point History
try
{
    $databaseRecoveryPointHistory = Get-AzRecoveryServicesBackupRecoveryPoint -Item $databaseBackupItem -VaultId $azureRecoveryServicesVault | Where-Object {$_.RecoveryPointType -eq 'Full'}
    $outputText = "Backup item recovery point (Full Backup) for $sourceInstance;$databaseName was successfully retrieved from Azure Recovery Services on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Get Database Backup Item Recovery Point History' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when retrieving the backup item recovery point history (Full Backup) for $sourceInstance;$databaseName from Azure Recovery Services on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Get Database Backup Item Recovery Point History' -operationMessage $outputText -operationOutcome 'Failed'
}

#Get Most Recent Database Backup Item Recovery Point
try
{
    $databaseRecoveryPoint = $databaseRecoveryPointHistory | Group-Object -Property 'ItemName' | ForEach-Object {$_.Group | Sort-Object 'RecoveryPointTime' -Descending | Select-Object -First 1}
    $outputText = "The most recent backup item recovery point (Full Backup) for $sourceInstance;$databaseName was successfully retrieved on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Get Most Recent Database Backup Item Recovery Point' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when retrieving the most recent backup item recovery point (Full Backup) for $sourceInstance;$databaseName on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Get Most Recent Database Backup Item Recovery Point' -operationMessage $outputText -operationOutcome 'Failed'
}

#Generate Database Recovery Point Id Filter Variable
try
{
    $databaseRecoveryPointIdFilter = ('*' + $databaseRecoveryPoint.RecoveryPointId + '*')
    $outputText = "The recovery point filter for $sourceInstance;$databaseName was successfully created as $databaseRecoveryPointIdFilter on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Generate Database Recovery Point Id Filter Variable' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when creating the recovery point filter for $sourceInstance;$databaseName on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Generate Database Recovery Point Id Filter Variable' -operationMessage $outputText -operationOutcome 'Failed'
}

#Generate Azure Recovery Services Vault Database Backup Restore Config
try
{
    $databaseRestore = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig -RecoveryPoint $databaseRecoveryPoint -RestoreAsFiles -FilePath $databaseRestoreDirectory -VaultId $azureRecoveryServicesVault -TargetContainer $targetContainer
    $outputText = "The recovery configuration for $sourceInstance;$databaseName was successfully created on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Generate Azure Recovery Services Vault Database Backup Restore Config' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when creating the recovery configuration for $sourceInstance;$databaseName on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Generate Azure Recovery Services Vault Database Backup Restore Config' -operationMessage $outputText -operationOutcome 'Failed'
}

#Download Database Backup Item To SQL Server VM
try
{
    $backupItemOperation = Restore-AzRecoveryServicesBackupItem -WLRecoveryConfig $databaseRestore -VaultId $azureRecoveryServicesVault
    $backupItemJobId = ($backupItemOperation).JobId
    $backupItemJobArray = Get-AzRecoveryServicesBackupJob -Status InProgress -VaultId $azureRecoveryServicesVault | Where-Object {$_.JobId -eq $backupItemJobId}
    Wait-AzRecoveryServicesBackupJob -Job $backupItemJobArray -VaultId $azureRecoveryServicesVault -Timeout 10800
    $outputText = "The database $databaseName backup file was successfully downloaded to $databaseRestoreDirectory from Azure Recovery Services on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Download Database Backup Item To SQL Server VM' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when downloading the backup file for $databaseName from Azure Recovery Services on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Download Database Backup Item To SQL Server VM' -operationMessage $outputText -operationOutcome 'Failed'
}

#Get Filename Of Database Backup Item Downloaded to SQL Server VM
try
{
    $databaseBackupFileToRestore = (Get-ChildItem -Path $databaseRestoreDirectory | Where-Object {$_.Name -like $databaseRecoveryPointIdFilter} | Where-Object {$_.Name -like '*.bak'}).Name
    $outputText = "The database $databaseName backup file is $databaseBackupFileToRestore on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Get Filename Of Database Backup Item Downloaded to SQL Server VM' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when selecting the backup file for $databaseName on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Get Filename Of Database Backup Item Downloaded to SQL Server VM' -operationMessage $outputText -operationOutcome 'Failed'
}

#Get Full Path Of Database Backup Item Downloaded to SQL Server VM
try
{
    $databaseBackupFullPath = ($databaseRestoreDirectory + '\' + $databaseBackupFileToRestore)
    $outputText = "The database $databaseName backup filepath is $databaseBackupFullPath on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Get Full Path Of Database Backup Item Downloaded to SQL Server VM' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when computing the full path for the backup file for $databaseName on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Get Full Path Of Database Backup Item Downloaded to SQL Server VM' -operationMessage $outputText -operationOutcome 'Failed'
}

#Restore Database Backup Item to SQL Server Database Engine
try
{
    Restore-SqlDatabase `
    -AutoRelocateFile `
    -BackupFile $databaseBackupFullPath `
    -Credential $sqlServiceCredential `
    -Database $databaseName `
    -ServerInstance $targetSQLInstanceNameLocalIdentity
    $outputText = "The database $databaseName has been successfully restored to $targetSQLInstanceNameLocalIdentity on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Restore Database Backup Item to SQL Server Database Engine' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when restoring the database $databaseName to $targetSQLInstanceNameLocalIdentity on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Restore Database Backup Item to SQL Server Database Engine' -operationMessage $outputText -operationOutcome 'Failed'
}

#Remove Downloaded Backup Files After Restore To MSSQL Server Database Engine
try
{
    Get-ChildItem -Path $databaseRestoreDirectory | Where-Object {$_.Name -like $databaseRecoveryPointIdFilter} | Remove-Item
    $outputText = "The backup files for $databaseName have been successfully removed from $databaseRestoreDirectory on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Remove Downloaded Backup Files After Restore To MSSQL Server Database Engine' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when removing the backup files for $databaseName from $databaseRestoreDirectory on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Remove Downloaded Backup Files After Restore To MSSQL Server Database Engine' -operationMessage $outputText -operationOutcome 'Failed'
}

#Set Database Recovery Model to Simple
try
{
    Invoke-SqlCmd `
    -Credential $sqlServiceCredential `
    -Database 'master' `
    -Query "ALTER DATABASE [$databaseName] SET RECOVERY SIMPLE" `
    -ServerInstance $targetSQLInstanceNameLocalIdentity
    $outputText = "The database recovery model has been set to Simple on $databaseName"
    Write-Host $outputText
    ObfuscationLog -operationType 'Set Database Recovery Model to Simple' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when setting the database recovery model to Simple on $databaseName with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Set Database Recovery Model to Simple' -operationMessage $outputText -operationOutcome 'Failed'
}

#Disable Database Triggers
try
{
    Invoke-SqlCmd `
    -Credential $sqlServiceCredential `
    -Database $databaseName `
    -Query "DISABLE TRIGGER ALL ON DATABASE" `
    -ServerInstance $targetSQLInstanceNameLocalIdentity
    $outputText = "Triggers have been successfully disabled on $databaseName"
    Write-Host $outputText
    ObfuscationLog -operationType 'Disable Database Triggers' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when disabling triggers on the database $databaseName with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Disable Database Triggers' -operationMessage $outputText -operationOutcome 'Failed'
}

#Obfuscate Database
foreach($storedProcedure in $sqlStoredProcedureArray)
{
    try
    {
        $obfuscateScript = "DECLARE @seedA INT, @seedB INT 
        EXEC [dbo].[GetObfuscateSeed] @seedA OUTPUT, @seedB OUTPUT 
        EXEC [dbo].[$storedProcedure] @seedA, @seedB"

        Invoke-SqlCmd `
        -Credential $sqlServiceCredential `
        -Database 'ObfuscationManager' `
        -Query $obfuscateScript `
        -ServerInstance $targetSQLInstanceNameLocalIdentity
        $outputText = "$storedProcedure has been successfully executed against $databaseName"
        Write-Host $outputText
        ObfuscationLog -operationType 'Obfuscate Database' -operationMessage $outputText -operationOutcome 'Successful'

        Start-Sleep -Seconds 30
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $outputText = "An error occured when executing $storedProcedure against the database $databaseName with the following error $exception $exceptionMessage $exceptionMessageDetail."
        Write-Host $outputText
        ObfuscationLog -operationType 'Obfuscate Database' -operationMessage $outputText -operationOutcome 'Failed'
    }
}

#Enable Database Triggers
try
{
    Invoke-SqlCmd `
    -Credential $sqlServiceCredential `
    -Database $databaseName `
    -Query "ENABLE TRIGGER ALL ON DATABASE" `
    -ServerInstance $targetSQLInstanceNameLocalIdentity
    $outputText = "Triggers have been successfully enabled on $databaseName"
    Write-Host $outputText
    ObfuscationLog -operationType 'Enable Database Triggers' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when enabling triggers on the database $databaseName with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Enable Database Triggers' -operationMessage $outputText -operationOutcome 'Failed'
}

#Shrink Database Logical Files
foreach($logicalFile in $databaseLogicalFileArray)
{
    try
    {
        Invoke-SqlCmd `
        -Credential $sqlServiceCredential `
        -Database $databaseName `
        -Query "DBCC SHRINKFILE('$logicalFile', 0)" `
        -ServerInstance $targetSQLInstanceNameLocalIdentity
        $outputText = "The logical file $logicalFile has been successfully shrank on $databaseName"
        Write-Host $outputText
        ObfuscationLog -operationType 'Shrink Database Logical Files' -operationMessage $outputText -operationOutcome 'Successful'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $outputText = "An error occured when shrinking the logical file $logicalFile for $databaseName with the following error $exception $exceptionMessage $exceptionMessageDetail."
        Write-Host $outputText
        ObfuscationLog -operationType 'Shrink Database Logical Files' -operationMessage $outputText -operationOutcome 'Failed'
    }
}

#Remove Existing Backup File If Already Exists
try
{
    $ifExists = (Get-AzStorageBlob -Container $azureBlobStorageContainer -Blob $databaseBackupBlobName -Context $azureBlobStorageContext -ErrorAction SilentlyContinue)
    if($ifExists)
    {
        Remove-AzStorageBlob -Container $azureBlobStorageContainer -Blob $databaseBackupBlobName -Context $azureBlobStorageContext
        $outputText = "$databaseBackupBlobName was successfully removed."
        Write-Host $outputText
        ObfuscationLog -operationType 'Remove Existing Backup Files' -operationMessage $outputText -operationOutcome 'Successful'
    }
    else
    {
        $outputText = "$databaseBackupBlobName was not present in the storage account."
        Write-Host $outputText
        ObfuscationLog -operationType 'Remove Existing Backup Files' -operationMessage $outputText -operationOutcome 'No Action'
    }
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when attempting to remove $databaseBackupBlobName for $databaseName with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Remove Existing Backup Files' -operationMessage $outputText -operationOutcome 'Failed'
}

#Backup Obfuscated Database to Azure Blob Storage
try
{
    Backup-SqlDatabase `
    -BackupFile $databaseBackupURLPath `
    -BlockSize 65536 `
    -Credential $sqlServiceCredential `
    -Database $databaseName `
    -MaxTransferSize 4194304 `
    -ServerInstance $targetSQLInstanceNameLocalIdentity
    $outputText = "The database $databaseName has been successfully backed up to $databaseBackupURLPath on $env:computername"
    Write-Host $outputText
    ObfuscationLog -operationType 'Backup Obfuscated Database to Azure Blob Storage' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when backing up the database $databaseName to $databaseBackupURLPath on $env:computername with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Backup Obfuscated Database to Azure Blob Storage' -operationMessage $outputText -operationOutcome 'Failed'
}

#Drop Database
try
{
    Invoke-SqlCmd `
    -Credential $sqlServiceCredential `
    -Database 'master' `
    -Query "ALTER DATABASE [$databaseName] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [$databaseName]" `
    -ServerInstance $targetSQLInstanceNameLocalIdentity
    $outputText = "The database $databaseName has been successfully dropped"
    Write-Host $outputText
    ObfuscationLog -operationType 'Drop Database' -operationMessage $outputText -operationOutcome 'Successful'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $outputText = "An error occured when dropping the database $databaseName with the following error $exception $exceptionMessage $exceptionMessageDetail."
    Write-Host $outputText
    ObfuscationLog -operationType 'Drop Database' -operationMessage $outputText -operationOutcome 'Failed'
}

$outputText = "Execution of db-obfuscate.ps1 for $databaseName successfully completed on $env:computername"
Write-Host $outputText
ObfuscationLog -operationType 'Script Execution Completed' -operationMessage $outputText -operationOutcome 'Successful'