param
(
    [string]$sqlServerSAAccountPassword,
    [string]$sqlServerSysAdminAccount,
    [string]$storageAccountBlobPrefix
)

$diskFormat = 'NTFS'
$diskPartitionStyle = 'GPT'
$errorActionPreference = 'Stop'
$progressPreference = 'SilentlyContinue'
$sqlBackupDiskName = 'SQLBackup'
$sqlDataDiskName = 'SQLData'
$sqlLogDiskName = 'SQLLog'
$sqlServerSAAccountPasswordForCredential = (ConvertTo-SecureString $sqlServerSAAccountPassword -AsPlainText -Force)
$sqlServerSAAccountCredential = New-Object System.Management.Automation.PSCredential ('sa', $sqlServerSAAccountPasswordForCredential)
$sqlTempDBDiskName = 'SQLTempDB'

#Create computer setup directory
$computerSetupDirectory = 'C:\ComputerSetup'
New-Item -Path $computerSetupDirectory -ItemType Directory
Set-Location $computerSetupDirectory

#Initialise Data Disks
Initialize-Disk -Number 2 -PartitionStyle $diskPartitionStyle -PassThru | New-Volume -FileSystem $diskFormat -DriveLetter F -FriendlyName $sqlDataDiskName
Initialize-Disk -Number 3 -PartitionStyle $diskPartitionStyle -PassThru | New-Volume -FileSystem $diskFormat -DriveLetter G -FriendlyName $sqlLogDiskName
Initialize-Disk -Number 4 -PartitionStyle $diskPartitionStyle -PassThru | New-Volume -FileSystem $diskFormat -DriveLetter H -FriendlyName $sqlBackupDiskName
Initialize-Disk -Number 5 -PartitionStyle $diskPartitionStyle -PassThru | New-Volume -FileSystem $diskFormat -DriveLetter I -FriendlyName $sqlTempDBDiskName

#Turn IE Enhanced Security Configuration Off for Admins
$AdminKey = "HKLM:\SOFTWARE\Microsoft\Active Setup\Installed Components\{A509B1A7-37EF-4b3f-8CFC-4F3A74704073}"
Set-ItemProperty -Path $AdminKey -Name "IsInstalled" -Value 0 -Force
Rundll32 iesetup.dll, IEHardenLMSettings
Rundll32 iesetup.dll, IEHardenAdmin

#Set TLS to TLS 1.2 for the session
[System.Net.ServicePointManager]::SecurityProtocol = [System.Net.SecurityProtocolType]::Tls12;
 
#Download Microsoft Edge
Invoke-WebRequest -Uri "https://go.microsoft.com/fwlink/?linkid=2192449" -OutFile "$computerSetupDirectory\MicrosoftEdgeSetup.exe"

#Download Microsoft Azure Storage Explorer
Invoke-WebRequest "https://go.microsoft.com/fwlink/?linkid=2216182" -OutFile "$computerSetupDirectory\AzureStorageExplorer.exe"

#Download PowerShell Core
Invoke-WebRequest -Uri "https://github.com/PowerShell/PowerShell/releases/download/v7.3.3/PowerShell-7.3.3-win-x64.msi" -OutFile "$computerSetupDirectory\PowerShell-7.3.3-win-x64.msi"

#Download dotnet Framework 4.8
Invoke-WebRequest -Uri "https://go.microsoft.com/fwlink/?linkid=2088631" -OutFile "$computerSetupDirectory\ndp48-x86-x64-allos-enu.exe"

#Download SQL Server Management Studio
Invoke-WebRequest -Uri "https://aka.ms/ssmsfullsetup" -OutFile "SSMS-Setup-ENU.exe"

#Download SQL Server from Storage Account
Invoke-WebRequest -Uri "$storageAccountBlobPrefix/enu_sql_server_2016_developer_edition_with_service_pack_3_x64_dvd_ceaed495.iso" -OutFile "$computerSetupDirectory\enu_sql_server_2016_developer_edition_with_service_pack_3_x64_dvd_ceaed495.iso"

#Download Database Migration Assistant
Invoke-WebRequest -Uri "https://download.microsoft.com/download/C/6/3/C63D8695-CEF2-43C3-AF0A-4989507E429B/DataMigrationAssistant.msi" -OutFile "$computerSetupDirectory\DataMigrationAssistant.msi"

#Download database backup files
Invoke-WebRequest -Uri "$storageAccountBlobPrefix/Sales.bak" -OutFile "$computerSetupDirectory\Sales.bak"
Invoke-WebRequest -Uri "$storageAccountBlobPrefix/WingItAirlines2014-Bookings.bak" -OutFile "$computerSetupDirectory\WingItAirlines2014-Bookings.bak"

#Install Microsoft Edge
.\MicrosoftEdgeSetup.exe /install
Wait-Process "MicrosoftEdgeSetup"

#Install Microsoft Azure Storage Explorer
.\AzureStorageExplorer.exe /VERYSILENT /SUPPRESSMSGBOXES /NORESTART /ALLUSERS
Wait-Process "StorageExplorer"

#Install PowerShell Core
msiexec.exe /package PowerShell-7.3.3-win-x64.msi /quiet ADD_EXPLORER_CONTEXT_MENU_OPENPOWERSHELL=1 ADD_FILE_CONTEXT_MENU_RUNPOWERSHELL=1 ENABLE_PSREMOTING=0 REGISTER_MANIFEST=1 USE_MU=1 ENABLE_MU=1 ADD_PATH=1
Wait-Process "msiexec"

#Install SQL Server Management Studio
.\SSMS-Setup-ENU.exe /Install /Passive
Wait-Process "SSMS-Setup-ENU"

#Configure PowerShell
Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force
Set-PSRepository -Name PSGallery -InstallationPolicy Trusted
Install-Module SQLServer -Force

#Install dotnet Framework 4.8
.\ndp48-x86-x64-allos-enu.exe /install /quiet /norestart
Wait-Process "ndp48-x86-x64-allos-enu"

#Install SQL Server
Mount-DiskImage -ImagePath "$computerSetupDirectory\enu_sql_server_2016_developer_edition_with_service_pack_3_x64_dvd_ceaed495.iso"
Set-Location ?:\

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
/InstanceName='MSSQLSERVER' `
/PID='22222-00000-00000-00000-00000' `
/Quiet `
/SAPWD=$sqlServerSAAccountPassword `
/SecurityMode='SQL' `
/SQLBackupDir='H:\MSSQL15.MSSQLSERVER\BACKUP' `
/SQLSvcStartupType='Automatic' `
/SQLSysAdminAccounts=$sqlServerSysAdminAccount `
/SQLTempDBDir='I:\MSSQL15.MSSQLSERVER\TEMPDB' `
/SQLTempDBFileCount=8 `
/SQLTempDBFileGrowth=1024 `
/SQLTempDBFileSize=8 `
/SQLTempDBLogDir='I:\MSSQL15.MSSQLSERVER\TEMPDBLOG' `
/SQLTempDBLogFileSize=8 `
/SQLTempDBLogFileGrowth=1024 `
/SQLUserDBDir='F:\MSSQL15.MSSQLSERVER\USER_DATA' `
/SQLUserDBLogDir='G:\MSSQL15.MSSQLSERVER\USER_LOG' `
/SuppressPrivacyStatementNotice `
/TCPEnabled=1 `
/UpdateEnabled=True `
/UpdateSource='MU'

#Restore databases
Invoke-SqlCmd `
-Credential $sqlServerSAAccountCredential `
-Database 'master' `
-Query "RESTORE DATABASE [WingIt_Sales] FROM  DISK = N'C:\ComputerSetup\Sales.bak' WITH  FILE = 1, MOVE N'SalesDBData' TO N'F:\MSSQL15.MSSQLSERVER\USER_DATA\WingIt_SalesDBData.mdf',  MOVE N'SalesDBLog' TO N'G:\MSSQL15.MSSQLSERVER\USER_LOG\WingIt_SalesDBLog.ldf',  NOUNLOAD,  STATS = 5
" `
-ServerInstance $env:computername

Invoke-SqlCmd `
-Credential $sqlServerSAAccountCredential `
-Database 'master' `
-Query "RESTORE DATABASE [WingItAirlines2014-Bookings] FROM  DISK = N'C:\ComputerSetup\WingItAirlines2014-Bookings.bak' WITH  FILE = 1,  MOVE N'AdventureWorks2014_Data' TO N'F:\MSSQL15.MSSQLSERVER\USER_DATA\WingItAirlines2014-Bookings_Data.mdf',  MOVE N'AdventureWorks2014_Log' TO N'G:\MSSQL15.MSSQLSERVER\USER_LOG\WingItAirlines2014-Bookings_Log.ldf',  MOVE N'customer001-invoice' TO N'F:\MSSQL15.MSSQLSERVER\USER_DATA\customer002-invoice.jpg',  NOUNLOAD,  STATS = 5" `
-ServerInstance $env:computername

Restart-Computer