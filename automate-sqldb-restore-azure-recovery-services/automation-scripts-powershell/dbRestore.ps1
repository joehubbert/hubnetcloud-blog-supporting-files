#Set Params
param
(
    [Parameter(Mandatory)][String]$configFilePath,
    [Parameter(Mandatory)][Array]$databaseScope,
    [Parameter(Mandatory)][System.Management.Automation.PSCredential]$sqlServiceCredential,
    [Parameter(Mandatory)][String]$triggerType
)

#Unpack Configuration Settings
$configurationSettings = Get-Content $configFilePath | Out-String | ConvertFrom-Json

#Set Global Variables
$azureSubscriptionId = $configurationSettings.azureSubscriptionId
$azureUserManagedIdentityId = $configurationSettings.azureUserManagedIdentityId
$azureRecoveryServicesVaultName = $configurationSettings.azureRecoveryServicesVaultName
$azureRecoveryServicesVaultResourceGroupName = $configurationSettings.azureRecoveryServicesVaultResourceGroupName
$databaseRestoreDirectory = $configurationSettings.databaseRestoreDirectory
$logDirectory = ('C:\Process\DB-Restore\Log')
$logTimeFilter = (Get-Date).AddDays(-45)
$scriptLogFileName = ('dbrestore-'+ (Get-Date -Format "yyyy-MM-dd-HH-mm") + "-$triggerType-Log.txt")
$scriptLogPath = "$logDirectory\$scriptLogFileName"
$sourceInstance = $configurationSettings.sourceInstance
$sourceInstanceCode = $configurationSettings.sourceInstanceCode
$targetInstance = $configurationSettings.targetInstance
$targetSQLInstanceNameLocalIdentity = $configurationSettings.targetSQLInstanceNameLocalIdentity

#Create Log File
$currentTimestamp = Get-Date
New-Item -Path $logDirectory -Name $scriptLogFileName -ItemType File -Value "Script log file created at $currentTimestamp for '$triggerType' schedule." -Force

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
    $database = $using:database
    $databaseRestoreDirectory = $using:databaseRestoreDirectory
    $logDirectory = $using:logDirectory
    $scriptLogPath = $using:scriptLogPath
    $sourceInstance = $using:sourceInstance
    $sourceInstanceCode = $using:sourceInstanceCode
    $sqlServiceCredential = $using:sqlServiceCredential
    $targetInstance = $using:targetInstance
    $targetSQLInstanceNameLocalIdentity = $using:targetSQLInstanceNameLocalIdentity
    
    #Set Restore Target Information
    try
    {
        $targetContainer = Get-AzRecoveryServicesBackupContainer -ContainerType 'AzureVMAppContainer' -VaultId $azureRecoveryServicesVault -FriendlyName $targetInstance
        $currentTimestamp = Get-Date
        $outputText = "The target backup container for '$targetInstance' was successfully retrieved from Azure Recovery Services on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when retrieving the backup container for '$targetInstance' from Azure Recovery Services on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    #Download backup item from Recovery Services Vault
    try
    {
        $databaseBackupItem = Get-AzRecoveryServicesBackupItem -BackupManagementType 'AzureWorkload' -WorkloadType 'MSSQL' -VaultId $azureRecoveryServicesVault | Where-Object {$_.ServerName -eq $sourceInstance} | Where-Object {$_.Name -eq ("SQLDataBase;$sourceInstanceCode;$database")}
        $currentTimestamp = Get-Date
        $outputText = "Backup item '$sourceInstance;$database' was successfully retrieved from Azure Recovery Services on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when retrieving the backup item '$sourceInstance;$database' from Azure Recovery Services on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    try
    {
        $databaseRecoveryPointHistory = Get-AzRecoveryServicesBackupRecoveryPoint -Item $databaseBackupItem -VaultId $azureRecoveryServicesVault | Where-Object {$_.RecoveryPointType -eq 'Full'}
        $currentTimestamp = Get-Date
        $outputText = "Backup item recovery point (Full Backup) for '$sourceInstance;$database' was successfully retrieved from Azure Recovery Services on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when retrieving the backup item recovery point history (Full Backup) for '$sourceInstance;$database' from Azure Recovery Services on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    try
    {
        $databaseRecoveryPoint = $databaseRecoveryPointHistory | Group-Object -Property 'ItemName' | ForEach-Object {$_.Group | Sort-Object 'RecoveryPointTime' -Descending | Select-Object -First 1}
        $currentTimestamp = Get-Date
        $outputText = "The most recent backup item recovery point (Full Backup) for '$sourceInstance;$database' was successfully retrieved on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when retrieving the most recent backup item recovery point (Full Backup) for '$sourceInstance;$database' on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    try
    {
        $databaseRecoveryPointIdFilter = ('*' + $databaseRecoveryPoint.RecoveryPointId + '*')
        $currentTimestamp = Get-Date
        $outputText = "The recovery point filter for '$sourceInstance;$database' was successfully created as $databaseRecoveryPointIdFilter on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when creating the recovery point filter for '$sourceInstance;$database' on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    try
    {
        $databaseRestore = Get-AzRecoveryServicesBackupWorkloadRecoveryConfig -RecoveryPoint $databaseRecoveryPoint -RestoreAsFiles -FilePath $databaseRestoreDirectory -VaultId $azureRecoveryServicesVault -TargetContainer $targetContainer
        $currentTimestamp = Get-Date
        $outputText = "The recovery configuration for '$sourceInstance;$database' was successfully created on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when creating the recovery configuration for '$sourceInstance;$database' on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    try
    {
        $backupItemOperation = Restore-AzRecoveryServicesBackupItem -WLRecoveryConfig $databaseRestore -VaultId $azureRecoveryServicesVault
        $backupItemJobId = ($backupItemOperation).JobId
        $backupItemJobArray = Get-AzRecoveryServicesBackupJob -Status InProgress -VaultId $azureRecoveryServicesVault | Where-Object {$_.JobId -eq $backupItemJobId}
        Wait-AzRecoveryServicesBackupJob -Job $backupItemJobArray -VaultId $azureRecoveryServicesVault -Timeout 10800
        $currentTimestamp = Get-Date
        $outputText = "The database '$database' backup file was successfully downloaded to '$databaseRestoreDirectory' from Azure Recovery Services on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when downloading the backup file for '$database' from Azure Recovery Services on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    #Restore backup file to Database Engine
    
    try
    {
        $databaseBackupFileToRestore = (Get-ChildItem -Path $databaseRestoreDirectory | Where-Object {$_.Name -like $databaseRecoveryPointIdFilter} | Where-Object {$_.Name -like '*.bak'}).Name
        $currentTimestamp = Get-Date
        $outputText = "The database '$database' backup file is '$databaseBackupFileToRestore' on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when selecting the backup file for '$database' on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    try
    {
        $databaseBackupFullPath = ($databaseRestoreDirectory + '\' + $databaseBackupFileToRestore)
        $currentTimestamp = Get-Date
        $outputText = "The database '$database' backup filepath is '$databaseBackupFullPath' on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when computing the full path for the backup file for '$database' on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    try
    {
        Import-Module DBATools
        $currentTimestamp = Get-Date
        $outputText = "The PowerShell module 'DBATools' has been imported on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when importing the PowerShell module 'DBATools' on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    try
    {
        Restore-DbaDatabase `
        -DatabaseName $database `
        -Path $databaseBackupFullPath `
        -SqlCredential $sqlServiceCredential `
        -SqlInstance $targetSQLInstanceNameLocalIdentity `
        -UseDestinationDefaultDirectories
        $currentTimestamp = Get-Date
        $outputText = "The database '$database' has been successfully restored to '$targetSQLInstanceNameLocalIdentity' on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $errorMessageDetail = $_.Exception.InnerException.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when restoring the database '$database' to '$targetSQLInstanceNameLocalIdentity' on $env:computername at $currentTimestamp with the following error '$errorMessage $errorMessageDetail'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }

    #Remove backup files
    try
    {
        Get-ChildItem -Path $databaseRestoreDirectory | Where-Object {$_.Name -like $databaseRecoveryPointIdFilter} | Remove-Item
        $currentTimestamp = Get-Date
        $outputText = "The backup files for '$database' have been successfully removed from '$databaseRestoreDirectory' on $env:computername at $currentTimestamp."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
    catch
    {
        $errorMessage = $_.Exception.Message
        $currentTimestamp = Get-Date
        $outputText = "An error occured when removing the backup files for '$database' from '$databaseRestoreDirectory' on $env:computername at $currentTimestamp with the following error '$errorMessage'."
        Write-Host $outputText
        Add-Content -Path $scriptLogPath "`n$outputText"
    }
  }
}

Get-Job | Wait-job | Remove-Job

#Cleardown historic logs older than defined in $logTimeFilter
try
{
    Get-ChildItem -Path $logDirectory -Force | Where-Object {$_.LastWriteTime -lt $logTimeFilter} | Remove-Item
    $currentTimestamp = Get-Date
    $outputText = "Historic logs have been successfully removed from '$logDirectory' on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when removing historic logs from '$logDirectory' on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

$currentTimestamp = Get-Date
$outputText = "Execution of dbRestore.ps1 using the '$triggerType' configuration successfully completed on $env:computername at $currentTimestamp."
Write-Host $outputText
Add-Content -Path $scriptLogPath "`n$outputText"
