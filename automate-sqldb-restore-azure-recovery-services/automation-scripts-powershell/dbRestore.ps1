#Set Params
param
(
    [Parameter(Mandatory)][string]$configFilePath,
    [Parameter(Mandatory)][array]$databaseScope,
    [Parameter(Mandatory)][int]$logHistoryToKeepInDays,
    [Parameter(Mandatory)][System.Management.Automation.PSCredential]$sqlServiceCredential,
    [Parameter(Mandatory)][string]$triggerType
)

#Unpack Configuration Settings
$configurationSettings = Get-Content $configFilePath | Out-String | ConvertFrom-Json

#Set Global Variables
$azureSubscriptionId = $configurationSettings.azureSubscriptionId
$azureUserManagedIdentityId = $configurationSettings.azureUserManagedIdentityId
$azureRecoveryServicesVaultName = $configurationSettings.azureRecoveryServicesVaultName
$azureRecoveryServicesVaultResourceGroupName = $configurationSettings.azureRecoveryServicesVaultResourceGroupName
$databaseRestoreDirectory = $configurationSettings.databaseRestoreDirectory
$dbmsManagementDatabase = $configurationSettings.dbmsManagementDatabase
$jobId = New-Guid
$jobType = 'PowerShell Script'
$operationType = 'Database Restore'
$sourceInstance = $configurationSettings.sourceInstance
$sourceInstanceCode = $configurationSettings.sourceInstanceCode
$targetInstance = $configurationSettings.targetInstance
$targetSQLInstanceNameLocalIdentity = $configurationSettings.targetSQLInstanceNameLocalIdentity

#Create Logging Function
function AddOperationLog
{
    param
    (
        [Parameter(Mandatory)][guid]$correlationId,
        [Parameter(Mandatory)][string]$databaseName,
        [Parameter(Mandatory)][string]$operationMessage,
        [Parameter(Mandatory)][string]$operationOutcome
    )

    try
    {
        $AddOperationLogQuery = "EXEC [dbo].[AddOperationLogMessage] @correlationId = '$correlationId', @databaseName = '$databaseName', @jobCadence = '$global:jobCadence', @jobId = '$global:jobId', @jobType = '$global:jobType', @operationType = '$global:operationType', @operationMessage = '$operationMessage', @operationOutcome = '$operationOutcome'"
        Write-Output $AddOperationLogQuery
        Invoke-DbaQuery `
        -Database $dbmsManagementDatabase `
        -Query $AddOperationLogQuery `
        -SqlCredential $sqlServiceCredential `
        -SqlInstance $targetSQLInstanceNameLocalIdentity
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $outputText = "An error occured with the OperationLog function with the following exception: '$exception $exceptionMessage $exceptionMessageDetail"
        Write-Output $outputText
    }
}

#Iterate through each database and start background job for each
foreach($database in $databaseScope)
{
    Start-Job -Name "$database - Database Restore" -ScriptBlock {

    $azureUserManagedIdentityId = $using:azureUserManagedIdentityId
    $azureSubscriptionId = $using:azureSubscriptionId
    $azureContext = (Connect-AzAccount -Identity -AccountId $azureUserManagedIdentityId).context
    $azureContext = Set-AzContext -Subscription $azureSubscriptionId -DefaultProfile $azureContext
    $azureRecoveryServicesVaultName = $using:azureRecoveryServicesVaultName
    $azureRecoveryServicesVaultResourceGroupName = $using:azureRecoveryServicesVaultResourceGroupName
    $azureRecoveryServicesVault = (Get-AzRecoveryServicesVault -ResourceGroupName $azureRecoveryServicesVaultResourceGroupName -Name $azureRecoveryServicesVaultName).ID
    $correlationId = New-Guid
    $database = $using:database
    $databaseRestoreDirectory = $using:databaseRestoreDirectory
    $sourceInstance = $using:sourceInstance
    $sourceInstanceCode = $using:sourceInstanceCode
    $sqlServiceCredential = $using:sqlServiceCredential
    $targetInstance = $using:targetInstance
    $targetSQLInstanceNameLocalIdentity = $using:targetSQLInstanceNameLocalIdentity

    #Create Restore Trace Log
    try
    {
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage 'Restore trace log created' -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "Failure creating restore trace log on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Import DBATools Module
    try
    {
        Import-Module DBATools
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage 'DBATools PowerShell module imported' -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "Failure importing DBATools PowerShell module on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Set Az Recovery Services Restore Target Backup Container
    try
    {
        $targetContainer = Get-AzRecoveryServicesBackupContainer -ContainerType 'AzureVMAppContainer' -VaultId $azureRecoveryServicesVault -FriendlyName $targetInstance
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage 'Restore Az Recovery Services Backup target container set' -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "Failure setting target Az Recovery Services Backup target container on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Get backup item from Azure Recovery Services Target Container
    try
    {
        $databaseBackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType 'AzureWorkload' -WorkloadType 'MSSQL' -VaultId $azureRecoveryServicesVault | Where-Object {$_.ServerName -eq $sourceInstance} | Where-Object {$_.Name -eq ("SQLDataBase;$sourceInstanceCode;$database")}
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "Backup item '$sourceInstance;$database' was successfully retrieved from Azure Recovery Services" -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "An error occured when retrieving the backup item '$sourceInstance;$database' from Azure Recovery Services on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Get a list of recovery points for the database where the recovery point type is Full
    try
    {
        $databaseRecoveryPointHistory = Get-AzRecoveryServicesBackupRecoveryPoint -Item $databaseBackupItem -VaultId $azureRecoveryServicesVault | Where-Object {$_.RecoveryPointType -eq 'Full'}
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "Backup item recovery point (Full Backup) for '$sourceInstance;$database' was successfully retrieved from Azure Recovery Services" -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "An error occured when retrieving the backup item recovery point history (Full Backup) for '$sourceInstance;$database' from Azure Recovery Services on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Filter $databaseRecoveryPointHistory to get the most recent recovery point
    try
    {
        $databaseRecoveryPoint = $databaseRecoveryPointHistory | Group-Object -Property 'ItemName' | ForEach-Object {$_.Group | Sort-Object 'RecoveryPointTime' -Descending | Select-Object -First 1}
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "The most recent backup item recovery point (Full Backup) for '$sourceInstance;$database' was successfully retrieved" -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "An error occured when retrieving the most recent backup item recovery point (Full Backup) for '$sourceInstance;$database' on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Create recovery point filter
    try
    {
        $databaseRecoveryPointIdFilter = ('*' + $databaseRecoveryPoint.RecoveryPointId + '*')
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "The recovery point filter for '$sourceInstance;$database' was successfully created as $databaseRecoveryPointIdFilter" -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "An error occured when creating the recovery point filter for '$sourceInstance;$database' on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Create recovery configuration for the database restore instance
    try
    {
        $databaseRestore = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig -RecoveryPoint $databaseRecoveryPoint -RestoreAsFiles -FilePath $databaseRestoreDirectory -VaultId $azureRecoveryServicesVault -TargetContainer $targetContainer
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "The recovery configuration for '$sourceInstance;$database' was successfully created" -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "An error occured when creating the recovery configuration for '$sourceInstance;$database' on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Download backup file from Azure Recovery Services
    try
    {
        $backupItemOperation = Restore-AzRecoveryServicesBackupItem -WLRecoveryConfig $databaseRestore -VaultId $azureRecoveryServicesVault
        $backupItemJobId = ($backupItemOperation).JobId
        $backupItemJobArray = Get-AzRecoveryServicesBackupJob -Status InProgress -VaultId $azureRecoveryServicesVault | Where-Object {$_.JobId -eq $backupItemJobId}
        Wait-AzRecoveryServicesBackupJob -Job $backupItemJobArray -VaultId $azureRecoveryServicesVault -Timeout 10800
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "The database '$database' backup file was successfully downloaded to '$databaseRestoreDirectory' from Azure Recovery Services" -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "An error occured when downloading the backup file for '$database' from Azure Recovery Services on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Get the name of the .BAK file to restore
    try
    {
        $databaseBackupFileToRestore = (Get-ChildItem -Path $databaseRestoreDirectory | Where-Object {$_.Name -like $databaseRecoveryPointIdFilter} | Where-Object {$_.Name -like '*.bak'}).Name
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "The database '$database' backup file is '$databaseBackupFileToRestore'" -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "An error occured when selecting the backup file for '$database' on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Compute full file path for the backup file
    try
    {
        $databaseBackupFullPath = ($databaseRestoreDirectory + '\' + $databaseBackupFileToRestore)
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "The database '$database' backup filepath is '$databaseBackupFullPath'" -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "An error occured when computing the full path for the backup file for '$database' on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Restore the database
    try
    {
        Restore-DbaDatabase `
        -DatabaseName $database `
        -Path $databaseBackupFullPath `
        -SqlCredential $sqlServiceCredential `
        -SqlInstance $targetSQLInstanceNameLocalIdentity `
        -UseDestinationDefaultDirectories `
        -WithReplace $true
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "The database '$database' has been successfully restored to '$targetSQLInstanceNameLocalIdentity'" -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "An error occured when restoring the database '$database' to '$targetSQLInstanceNameLocalIdentity' on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }

    #Remove backup files
    try
    {
        Get-ChildItem -Path $databaseRestoreDirectory | Where-Object {$_.Name -like $databaseRecoveryPointIdFilter} | Remove-Item
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "The backup files for '$database' have been successfully removed from '$databaseRestoreDirectory'" -operationOutcome 'Success'
    }
    catch
    {
        $exception = $_.Exception
        $exceptionMessage = $_.Exception.Message
        $exceptionMessageDetail = $_.Exception.InnerException.Message
        $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
        AddOperationLog -correlationId $correlationId -databaseName $database -operationMessage "An error occured when removing the backup files for '$database' from '$databaseRestoreDirectory' on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
    }
  }
}

Get-Job | Wait-job | Remove-Job

#Remove historic logs
try
{
    $correlationId = New-Guid
    $RemoveHistoricLogsQuery = "EXEC [dbo].[RemoveStaleOperationLogMessage] @historyToKeep = $logHistoryToKeepInDays, @operationType = '$operationType'"
    Write-Output $RemoveHistoricLogsQuery
    Invoke-DbaQuery `
    -Database $dbmsManagementDatabase `
    -Query $RemoveHistoricLogsQuery `
    -SqlCredential $sqlServiceCredential `
    -SqlInstance $targetSQLInstanceNameLocalIdentity
    AddOperationLog -correlationId $correlationId -databaseName $dbmsManagementDatabase -operationMessage "Operational Logs for $operationType successfully purged for logs older than $logHistoryToKeepInDays days" -operationOutcome 'Success'
}
catch
{
    $exception = $_.Exception
    $exceptionMessage = $_.Exception.Message
    $exceptionMessageDetail = $_.Exception.InnerException.Message
    $fullException = $exception + $exceptionMessage + $exceptionMessageDetail
    AddOperationLog -correlationId $correlationId -databaseName $dbmsManagementDatabase -operationMessage "An error occured when removing the backup files for '$database' from '$databaseRestoreDirectory' on $env:computername with the following exception: $fullException" -operationOutcome 'Failure'
}

#Complete trace log
$correlationId = New-Guid
AddOperationLog -correlationId $correlationId -databaseName $dbmsManagementDatabase -operationMessage "Execution of dbRestore.ps1 using the '$triggerType' configuration completed on $env:computername." -operationOutcome 'Information'