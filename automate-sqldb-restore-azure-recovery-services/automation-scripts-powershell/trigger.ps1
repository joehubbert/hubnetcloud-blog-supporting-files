param
(
    [Parameter(Mandatory)][ValidateSet('AdHoc','Daily','Monthly')][string]$triggerType
)

#Retrieve Required Secrets
$sqlServiceCredential = Import-CliXml -Path 'C:\Process\DB-Restore\Credential\sqlServiceCredential.xml'

#Databases To Restore
$dailyDatabases = @('AdventureWorks2022', 'WideWorldImporters')
$monthlyDatabases = @('WingItAirlinesReporting')

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
        -triggerType 'AdHoc' `
        -sqlServiceCredential $sqlServiceCredential
    }
    'Daily'
    {
        C:\Process\DB-Restore\Script\dbRestore.ps1 `
        -configFilePath 'C:\Process\DB-Restore\Configuration\processConfig.json' `
        -databaseScope $dailyDatabases `
        -triggerType 'Daily' `
        -sqlServiceCredential $sqlServiceCredential
    }
    'Monthly'
    {
        C:\Process\DB-Restore\Script\dbRestore.ps1 `
        -configFilePath 'C:\Process\DB-Restore\Configuration\processConfig.json' `
        -databaseScope $monthlyDatabases `
        -triggerType 'Monthly' `
        -sqlServiceCredential $sqlServiceCredential        
    }
}