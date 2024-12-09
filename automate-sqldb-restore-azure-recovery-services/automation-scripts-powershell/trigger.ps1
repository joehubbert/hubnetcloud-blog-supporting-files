param
(
    [Parameter(Mandatory)][ValidateSet('AdHoc','Daily','Weekly','Monthly')][string]$triggerType
)

#Retrieve Required Secrets
$sqlServiceCredential = Import-CliXml -Path 'C:\Process\DB-Restore\Credential\sqlServiceCredential.xml'

#Databases To Restore
$dailyDatabases = @('AdventureWorks2022', 'WideWorldImporters')
$monthlyDatabases = @('WingItAirlinesReporting')
$weeklyDatabases = @('AccountingDB', 'SalesDB')

#Define Log History to Keep
$logHistoryToKeepInDays = -45

if($triggerType -eq 'AdHoc')
{
    $wshell = New-Object -ComObject wscript.shell
    do
    {
        $adHocDatabases += Read-Host "Database Name"
        $response = $wshell.popup("Do you want to add more databases to be restored?",0,"More Databases?",4)
        if($response -eq 6)
        {
            $continue = $true
        }
        else
        {
            $continue = $false
        }
    }
    while($continue -eq $true)
}

switch ($triggerType) {
    'AdHoc'
    {
        C:\Process\DB-Restore\Script\dbRestore.ps1 `
        -configFilePath 'C:\Process\DB-Restore\Configuration\processConfig.json' `
        -databaseScope $adHocDatabases `
        -logHistoryToKeepInDays $logHistoryToKeepInDays `
        -sqlServiceCredential $sqlServiceCredential `
        -triggerType 'AdHoc'
    }
    'Daily'
    {
        C:\Process\DB-Restore\Script\dbRestore.ps1 `
        -configFilePath 'C:\Process\DB-Restore\Configuration\processConfig.json' `
        -databaseScope $dailyDatabases `
        -logHistoryToKeepInDays $logHistoryToKeepInDays `
        -sqlServiceCredential $sqlServiceCredential `
        -triggerType 'Daily'
    }
    'Monthly'
    {
        C:\Process\DB-Restore\Script\dbRestore.ps1 `
        -configFilePath 'C:\Process\DB-Restore\Configuration\processConfig.json' `
        -databaseScope $monthlyDatabases `
        -logHistoryToKeepInDays $logHistoryToKeepInDays `
        -sqlServiceCredential $sqlServiceCredential `
        -triggerType 'Monthly'
    }
    'Weekly'
    {
        C:\Process\DB-Restore\Script\dbRestore.ps1 `
        -configFilePath 'C:\Process\DB-Restore\Configuration\processConfig.json' `
        -databaseScope $weeklyDatabases `
        -logHistoryToKeepInDays $logHistoryToKeepInDays `
        -sqlServiceCredential $sqlServiceCredential `
        -triggerType 'Weekly'
    }
}