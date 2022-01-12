##Run if Az PowerShell module is not already installed
Install-Module Az -AllowClobber 

##Run if Az PowerShell module is already installed but update check is required 
Update-Module Az

Import-Module Az

Connect-AzAccount

$resourceGroup = '<The same resource group that we have been using so far>' 
$serverName = $resourceGroup + '-sql' 
$databaseName = 'reportingDatabase' 
$location = '<The same location all the other resources have been deployed to e.g. uksouth>' 

## currentUser is needed so we are able to login with our current user with Azure Active Directory authentication 
$currentUser = (Get-AzContext).Account 

$publicIpAddress = (Invoke-WebRequest -uri 'https://api.ipify.org/').Content

##You'll be prompted to enter a username and password that will be stored in this variable as a secure string 
$sqlAdminCredential = Get-Credential

New-AzSqlServer -ServerName $serverName -SqlAdministratorCredentials $sqlAdminCredential -Location $location -ServerVersion '12.0' -PublicNetworkAccess 'enabled' -MinimalTlsVersion '1.2' -ExternalAdminName $currentUser -ResourceGroupName $resourceGroup

New-AzSqlServerFirewallRule -FirewallRuleName 'AllowMyAccess' -StartIpAddress $publicIpAddress -EndIpAddress $publicIpAddress -ServerName $serverName -ResourceGroupName $resourceGroup

##Only run if using a public endpoint for your SQL server 
New-AzSqlServerFirewallRule -AllowAllAzureServices 'AllowMyAccess' -ServerName $serverName -ResourceGroupName $resourceGroup

##The bytesize shown is 2GB which at the time of writing is the smallest Azure SQL Database offering in the Basic series of the DTU pricing model 
New-AzSqlDatabase -DatabaseName $databaseName -ResourceGroupName $resourceGroup -ServerName $serverName -BackupStorageRedundancy 'Local' -Edition 'Basic' -LicenseType 'BasePrice' -MaxSizeBytes 2147483648