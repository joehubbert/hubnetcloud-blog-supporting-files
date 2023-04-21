param
(
    [string]$sqlServerSAAccountPassword,
    [string]$sqlServerSQLAuthBreakglassPassword,
    [string]$sqlServerSQLAuthBreakglassUsername,
    [string]$sqlServerSysAdminAccount,
    [string]$storageAccountBlobPrefix
)

$computerSetupDirectory = 'C:\ComputerSetup\Install'
$computerSetupLogDirectory = 'C:\ComputerSetup\Logs'
$diskFormat = 'NTFS'
$diskPartitionStyle = 'GPT'
$errorActionPreference = 'Stop'
$progressPreference = 'SilentlyContinue'
$scriptLogFileName = 'configureDemoServer-Log.txt'
$scriptLogPath = "$computerSetupLogDirectory\$scriptLogFileName"
$sqlBackupDiskName = 'SQLBackup'
$sqlDataDiskName = 'SQLData'
$sqlLogDiskName = 'SQLLog'
$sqlServerInstanceName = 'MSSQLSERVER'
$sqlServerLocalIdentity = 'NT SERVICE\MSSQLSERVER'
$sqlServerSAAccountPasswordForCredential = (ConvertTo-SecureString $sqlServerSAAccountPassword -AsPlainText -Force)
$sqlServerSAAccountCredential = New-Object System.Management.Automation.PSCredential ('sa', $sqlServerSAAccountPasswordForCredential)
$sqlServerSQLAuthBreakglassPasswordForCredential = (ConvertTo-SecureString $sqlServerSQLAuthBreakglassPassword -AsPlainText -Force)
$sqlServerSQLAuthBreakglassCredential = New-Object System.Management.Automation.PSCredential ($sqlServerSQLAuthBreakglassUsername, $sqlServerSQLAuthBreakglassPasswordForCredential)
$sqlTempDBDiskName = 'SQLTempDB'
$webClient = New-Object net.webclient

#Create Script Log File
try
{
    $currentTimestamp = Get-Date
    New-Item -Path $computerSetupLogDirectory -Name $scriptLogFileName -ItemType File -Value "Script log file created at $currentTimestamp." -Force
}
catch
{
    Write-Host "Unable to create log file $scriptLogPath."
}

#Initialise Data Disks
try
{
    Initialize-Disk -Number 2 -PartitionStyle $diskPartitionStyle -PassThru | New-Volume -FileSystem $diskFormat -DriveLetter F -FriendlyName $sqlDataDiskName
    $currentTimestamp = Get-Date
    $outputText = "The data disk $sqlDataDiskName has been successfully initialised on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when initialising $sqlDataDiskName on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

try
{
    Initialize-Disk -Number 3 -PartitionStyle $diskPartitionStyle -PassThru | New-Volume -FileSystem $diskFormat -DriveLetter G -FriendlyName $sqlLogDiskName
    $currentTimestamp = Get-Date
    $outputText = "The data disk $sqlLogDiskName has been successfully initialised on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when initialising $sqlLogDiskName on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

try
{
    Initialize-Disk -Number 4 -PartitionStyle $diskPartitionStyle -PassThru | New-Volume -FileSystem $diskFormat -DriveLetter H -FriendlyName $sqlBackupDiskName
    $currentTimestamp = Get-Date
    $outputText = "The data disk $sqlBackupDiskName has been successfully initialised on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when initialising $sqlBackupDiskName on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

try
{
    Initialize-Disk -Number 5 -PartitionStyle $diskPartitionStyle -PassThru | New-Volume -FileSystem $diskFormat -DriveLetter I -FriendlyName $sqlTempDBDiskName
    $currentTimestamp = Get-Date
    $outputText = "The data disk $sqlTempDBDiskName has been successfully initialised on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when initialising $sqlTempDBDiskName on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Turn IE Enhanced Security Configuration Off for Admins
try
{
    $AdminKey = "HKLM:\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A7-37EF-4b3f-8CFC-4F3A74704073}"
    Set-ItemProperty -Path $AdminKey -Name "IsInstalled" -Value 0 -Force
    Rundll32 iesetup.dll, IEHardenLMSettings
    Rundll32 iesetup.dll, IEHardenAdmin
     $currentTimestamp = Get-Date
    $outputText = "The IE Enhanced Security Configuration has been successfully disabled on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when disabling IE Enhanced Security Configuration on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

Set-Location $computerSetupDirectory

#Download Microsoft Azure Storage Explorer
try
{
    $webClient.DownloadFile("https://go.microsoft.com/fwlink/?linkid=2216182", "$computerSetupDirectory\AzureStorageExplorer.exe")
    $currentTimestamp = Get-Date
    $outputText = "Azure Data Explorer has been successfully downloaded to $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when downloading Azure Storage Explorer to $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Download PowerShell Core
try
{
    $webClient.DownloadFile("https://github.com/PowerShell/PowerShell/releases/download/v7.2.10/PowerShell-7.2.10-win-x64.msi", "$computerSetupDirectory\PowerShell-7.2.10-win-x64.msi")
    $currentTimestamp = Get-Date
    $outputText = "PowerShell Core has been successfully downloaded to $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when downloading PowerShell Core to $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Download SQL Server Management Studio
try
{
    $webClient.DownloadFile("https://aka.ms/ssmsfullsetup", "$computerSetupDirectory\SSMS-Setup-ENU.exe")
    $currentTimestamp = Get-Date
    $outputText = "SQL Server Management Studio has been successfully downloaded to $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when downloading SQL Server Management Studio to $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Download SQL Server from Storage Account
try
{
    $webClient.DownloadFile("$storageAccountBlobPrefix/enu_sql_server_2016_developer_edition_with_service_pack_3_x64_dvd_ceaed495.iso", "$computerSetupDirectory\enu_sql_server_2016_developer_edition_with_service_pack_3_x64_dvd_ceaed495.iso")
    $currentTimestamp = Get-Date
    $outputText = "The SQL Server 2016 ISO file has been successfully downloaded to $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when downloading the SQL Server 2016 ISO file to $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Download SQL Server 2016 Cumulative Update
try
{
    $webClient.DownloadFile("https://download.microsoft.com/download/4/1/d/41d10f6a-58dd-43ee-ad2a-cb2c3a6148ff/SQLServer2016-KB5021129-x64.exe", "$computerSetupDirectory\SQLServer2016-KB5021129-x64.exe")
    $currentTimestamp = Get-Date
    $outputText = "The SQL Server 2016 Cumulative Update has been successfully downloaded to $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when downloading SQL Server 2016 Cumulative to $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Download Database Migration Assistant
try
{
    $webClient.DownloadFile("https://download.microsoft.com/download/C/6/3/C63D8695-CEF2-43C3-AF0A-4989507E429B/DataMigrationAssistant.msi", "$computerSetupDirectory\DataMigrationAssistant.msi")
    $currentTimestamp = Get-Date
    $outputText = "Database Migration Assistant has been successfully downloaded to $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when downloading Data Migration Assistant to $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Download database backup files
try
{
    $webClient.DownloadFile("$storageAccountBlobPrefix/Sales.bak", "$computerSetupDirectory\Sales.bak")
    $currentTimestamp = Get-Date
    $outputText = "The Sales database backup file has been successfully downloaded to $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when downloading the Sales database backup file to $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

try
{
    $webClient.DownloadFile("$storageAccountBlobPrefix/WingItAirlines2014-Bookings.bak", "$computerSetupDirectory\WingItAirlines2014-Bookings.bak")
    $currentTimestamp = Get-Date
    $outputText = "The WingIt Airlines Bookings database backup file has been successfully downloaded to $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when downloading the WingIt Airlines Bookings database backup file to $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Install Microsoft Azure Storage Explorer
try
{
    .\AzureStorageExplorer.exe /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /ALLUSERS
    Wait-Process 'AzureStorageExplorer'
    $currentTimestamp = Get-Date
    $outputText = "Azure Data Explorer has been successfully installed on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when installing Azure Data Explorer on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Install PowerShell Core
try
{
    msiexec.exe /package PowerShell-7.2.10-win-x64.msi /quiet ADD_EXPLORER_CONTEXT_MENU_OPENPOWERSHELL=1 ADD_FILE_CONTEXT_MENU_RUNPOWERSHELL=1 ENABLE_PSREMOTING=0 REGISTER_MANIFEST=1 USE_MU=1 ENABLE_MU=1 ADD_PATH=1
    Wait-Process 'msiexec'
    $currentTimestamp = Get-Date
    $outputText = "PowerShell Core has been successfully installed on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when installing PowerShell Core on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Install SQL Server Management Studio
try
{
    .\SSMS-Setup-ENU.exe /Install /Passive
    Wait-Process 'SSMS-Setup-ENU'
    $currentTimestamp = Get-Date
    $outputText = "SQL Server Management Studio has been successfully installed on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when installing SQL Server Management Studio on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Install Database Migration Assistant
try
{
    msiexec.exe /package DataMigrationAssistant.msi /quiet
    Wait-Process 'msiexec'
    $currentTimestamp = Get-Date
    $outputText = "Database Migration Assistant has been successfully installed on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when installing Data Migration Assistant on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Install SQL Server
try
{
    $diskMount = (Mount-DiskImage -ImagePath "$computerSetupDirectory\enu_sql_server_2016_developer_edition_with_service_pack_3_x64_dvd_ceaed495.iso")
    Set-Location ((Get-DiskImage -DevicePath $diskMount.DevicePath | Get-Volume).DriveLetter + ':\')
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when trying to mount the SQL Server 2016 ISO file on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

try
{
    .\setup.exe `
    /Action=Install `
    /AgtSvcStartupType='Automatic' `
    /BrowserSvcStartupType='Disabled' `
    /Features='SQLENGINE' `
    /FilestreamLevel=3 `
    /FilestreamShareName='Filestream' `
    /ENU `
    /IAcceptSQLServerLicenseTerms `
    /IndicateProgress `
    /InstanceName=$sqlServerInstanceName `
    /PID='22222-00000-00000-00000-00000' `
    /Quiet `
    /SAPWD=$sqlServerSAAccountPassword `
    /SecurityMode='SQL' `
    /SQLBackupDir='H:\MSSQL13.MSSQLSERVER\BACKUP' `
    /SQLSvcStartupType='Automatic' `
    /SQLSysAdminAccounts=$sqlServerSysAdminAccount `
    /SQLTempDBDir='I:\MSSQL13.MSSQLSERVER\TEMPDB' `
    /SQLTempDBFileCount=8 `
    /SQLTempDBFileGrowth=1024 `
    /SQLTempDBFileSize=8 `
    /SQLTempDBLogDir='I:\MSSQL13.MSSQLSERVER\TEMPDBLOG' `
    /SQLTempDBLogFileSize=8 `
    /SQLTempDBLogFileGrowth=1024 `
    /SQLUserDBDir='F:\MSSQL13.MSSQLSERVER\USER_DATA' `
    /SQLUserDBLogDir='G:\MSSQL13.MSSQLSERVER\USER_LOG' `
    /SuppressPrivacyStatementNotice `
    /TCPEnabled=1 `
    /UpdateEnabled=True `
    /UpdateSource='MU'

    $currentTimestamp = Get-Date
    $outputText = "SQL Server 2016 has been successfully installed on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when installing SQL Server 2016 on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Install SQL Server 2016 Latest Cumulative Update
try
{
    Set-Location $computerSetupDirectory
    .\SQLServer2016-KB5021129-x64.exe /X:$computerSetupDirectory\SQLServer2016-KB5021129
    Wait-Process "SQLServer2016-KB5021129-x64"
    Set-Location $computerSetupDirectory\SQLServer2016-KB5021129
    .\setup.exe `
    /action=patch `
    /IAcceptSQLServerLicenseTerms `
    /instancename=$sqlServerInstanceName `
    /quiet
    Set-Location $computerSetupDirectory
    Remove-Item -LiteralPath $computerSetupDirectory\SQLServer2016-KB5021129 -Force -Recurse
    $currentTimestamp = Get-Date
    $outputText = "SQL Server 2016 Cumulative Update has been successfully installed on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when installing the SQL Server 2016 Cumulative Update on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"    
}

#Install NuGet Provider
try
{
    Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force
    $currentTimestamp = Get-Date
    $outputText = "PowerShell NuGet Package provider has been successfully installed on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when installing PowerShell NuGet Package provider on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}


#Set PSGallery Trusted
try
{
    Set-PSRepository -Name PSGallery -InstallationPolicy Trusted
    $currentTimestamp = Get-Date
    $outputText = "PSGallery has been set to be trusted on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when setting PSGallery to be trusted on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Install DBATools PowerShell module
try
{
    Install-Module DBATools -Force
    $currentTimestamp = Get-Date
    $outputText = "PowerShell DBATools module has been successfully installed on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when installing PowerShell DBATools module on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Install SQLServer PowerShell module
try
{
    Install-Module SQLServer -Force
    $currentTimestamp = Get-Date
    $outputText = "PowerShell SQLServer module has been successfully installed on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when installing PowerShell SQLServer module on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Assign permissions to SQL Server Service account to $computerSetupDirectory
try
{
    $acl = Get-Acl $computerSetupDirectory
    $permissionsToAdd = New-Object System.Security.AccessControl.FileSystemAccessRule($sqlServerLocalIdentity, "FullControl", "ContainerInherit, ObjectInherit", "None", "Allow")
    $acl.SetAccessRule($permissionsToAdd)
    Set-Acl $computerSetupDirectory $acl
    $currentTimestamp = Get-Date
    $outputText = "$computerSetupDirectory has had permissions granted to $sqlServerLocalIdentity on $env:computername at $currentTimestamp"
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when assigning permissions to $sqlServerLocalIdentity in $computerSetupDirectory on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

Import-Module DBATools

#Create SQLAuth Breakglass Login
try
{
    New-DbaLogin `
    -Login $sqlServerSQLAuthBreakglassUsername `
    -SecurePassword $sqlServerSQLAuthBreakglassPasswordForCredential `
    -SqlCredential $sqlServerSAAccountCredential `
    -SqlInstance $env:computername
    $currentTimestamp = Get-Date
    $outputText = "The SQL Auth Breakglass login has been successfully created on the SQL instance $sqlServerInstanceName on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when creating the SQL Auth Breakglass login on the SQL instance $sqlServerInstanceName on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Add SQLAuth Breakglass Login to sysadmin role
try
{
    Add-DbaServerRoleMember `
    -Login $sqlServerSQLAuthBreakglassUsername `
    -ServerRole sysadmin `
    -SqlCredential $sqlServerSAAccountCredential `
    -SqlInstance $env:computername `
    -Confirm:$false
    $currentTimestamp = Get-Date
    $outputText = "The SQL Auth Breakglass login has been added as a member of the sysadmin role on the SQL instance $sqlServerInstanceName on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when addoing the SQL Auth Breakglass login as a member of sysadmin on the SQL instance $sqlServerInstanceName on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Disable sa Login
try
{
    Set-DbaLogin `
    -Disable `
    -Login 'sa' `
    -SqlCredential $sqlServerSQLAuthBreakglassCredential `
    -SqlInstance $env:computername
    $currentTimestamp = Get-Date
    $outputText = "The sa login has been successfully disabled on the SQL instance $sqlServerInstanceName on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when disabling the sa login on the SQL instance $sqlServerInstanceName on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}

#Restore databases
try
{
    Restore-DbaDatabase `
    -DatabaseName 'WingIt_Sales' `
    -Path "$computerSetupDirectory\Sales.bak" `
    -SqlCredential $sqlServerSQLAuthBreakglassCredential `
    -SqlInstance $env:computername `
    -UseDestinationDefaultDirectories
    $currentTimestamp = Get-Date
    $outputText = "The WingIt_Sales database has been successfully restored on the SQL instance $sqlServerInstanceName on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when restoring the WingIt_Sales database to the SQL instance $sqlServerInstanceName on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"    
}

try
{
    Restore-DbaDatabase `
    -DatabaseName 'WingItAirlines2014-Bookings' `
    -Path "$computerSetupDirectory\WingItAirlines2014-Bookings.bak" `
    -SqlCredential $sqlServerSQLAuthBreakglassCredential `
    -SqlInstance $env:computername `
    -UseDestinationDefaultDirectories
    $currentTimestamp = Get-Date
    $outputText = "The WingItAirlines2014-Bookings database has been successfully restored on the SQL instance $sqlServerInstanceName on $env:computername at $currentTimestamp."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"
}
catch
{
    $errorMessage = $_.Exception.Message
    $currentTimestamp = Get-Date
    $outputText = "An error occured when restoring the WingItAirlines2014-Bookings database to the SQL instance $sqlServerInstanceName on $env:computername at $currentTimestamp with the following error '$errorMessage'."
    Write-Host $outputText
    Add-Content -Path $scriptLogPath "`n$outputText"    
}

$currentTimestamp = Get-Date
$outputText = "Execution of configureDemoServer.ps1 successfully completed on $env:computername at $currentTimestamp. A server reboot will be triggered immediately."
Write-Host $outputText
Add-Content -Path $scriptLogPath "`n$outputText"

Restart-Computer -Force