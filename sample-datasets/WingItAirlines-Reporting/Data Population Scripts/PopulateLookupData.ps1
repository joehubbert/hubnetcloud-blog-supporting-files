$databaseName = 'WingItAirlines-Reporting'
$sqlServerCredential = Get-Credential

Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-InputFile '.\AgencyCreation.sql' `
-ServerInstance $env:COMPUTERNAME

Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-InputFile '.\AgencyUserCreation.sql' `
-ServerInstance $env:COMPUTERNAME

Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-InputFile '.\AgencyCommissionCreation.sql' `
-ServerInstance $env:COMPUTERNAME

Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-InputFile '.\AirplaneCreation.sql' `
-ServerInstance $env:COMPUTERNAME

Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-InputFile '.\AirportCreation.sql' `
-ServerInstance $env:COMPUTERNAME

Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-InputFile '.\PassengerFareRateCreation.sql' `
-ServerInstance $env:COMPUTERNAME

Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-InputFile '.\TicketStatusCreation.sql' `
-ServerInstance $env:COMPUTERNAME

Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-InputFile '.\TicketTypeCreation.sql' `
-ServerInstance $env:COMPUTERNAME

Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-InputFile '.\RouteCreation.sql' `
-ServerInstance $env:COMPUTERNAME

Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-Query "EXEC [dbo].[CreateFlightSchedule] @startDate = '01 JAN 2015', @endDate = '31 DEC 2022'" `
-ServerInstance $env:COMPUTERNAME 