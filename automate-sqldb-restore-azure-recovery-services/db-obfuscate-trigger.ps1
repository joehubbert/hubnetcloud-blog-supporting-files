param
(
    [Parameter(Mandatory)][Array]$databaseLogicalFileArray,
    [Parameter(Mandatory)][string]$databaseName,
    [Parameter(Mandatory)][Array]$sqlStoredProcedureArray
)

Set-Location "C:\Process\DB-Obfuscate\Script"

#Retrieve Secrets
$azureBlobSASToken = Get-Content -Path 'C:\Process\DB-Obfuscate\Credential\azureBlobSASToken.txt' | ConvertTo-SecureString
$azureBlobSASToken =  [Runtime.InteropServices.Marshal]::PtrToStringAuto([Runtime.InteropServices.Marshal]::SecureStringToBSTR((($azureBlobSASToken))))
$sqlServiceCredential = Import-CliXml -Path 'C:\Process\DB-Obfuscate\Credential\sqlServiceCredential.xml'

.\db-obfuscate.ps1 `
-azureBlobSASToken $azureBlobSASToken `
-configFilePath 'C:\Process\DB-Obfuscate\Configuration\processConfig.json' `
-databaseLogicalFileArray $databaseLogicalFileArray `
-databaseName $databaseName `
-sqlServiceCredential $sqlServiceCredential `
-sqlStoredProcedureArray $sqlStoredProcedureArray