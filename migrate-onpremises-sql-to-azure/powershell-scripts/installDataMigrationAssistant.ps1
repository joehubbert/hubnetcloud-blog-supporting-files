$computerSetupDirectory = 'C:\ComputerSetup\Install'
Set-Location $computerSetupDirectory

#Install Database Migration Assistant
msiexec.exe /package DataMigrationAssistant.msi /quiet
Wait-Process "msiexec"

Restart-Computer