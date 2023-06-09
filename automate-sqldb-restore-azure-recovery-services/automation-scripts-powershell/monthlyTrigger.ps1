Set-Location "C:\Process\DB-Restore\Script"

#Retrieve Secrets
$azureSubscriptionId = Import-CliXml -Path 'C:\Process\DB-Restore\Credential\azureSubscriptionId.xml'
$azureUserManagedIdentityId = Import-CliXml -Path 'C:\Process\DB-Restore\Credential\azureUserManagedIdentityId.xml'
$sqlServiceCredential = Import-CliXml -Path 'C:\Process\DB-Restore\Credential\sqlServiceCredential.xml'

.\dbRestore.ps1 `
-azureSubscriptionId $azureSubscriptionId `
-azureUserManagedIdentityId $azureUserManagedIdentityId `
-configFilePath 'C:\Process\DB-Restore\Configuration\processConfig.json' `
-scheduleType 'Monthly' `
-sqlServiceCredential $sqlServiceCredential