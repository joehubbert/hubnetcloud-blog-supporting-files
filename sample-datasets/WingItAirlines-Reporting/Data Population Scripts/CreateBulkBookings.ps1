$databaseName = 'WingItAirlines-Reporting'
$sqlServerCredential = Get-Credential

function Get-RandomDateBetween{
    [Cmdletbinding()]
    param(
        [parameter(Mandatory=$True)][DateTime]$StartDate,
        [parameter(Mandatory=$True)][DateTime]$EndDate
        )

    process{
       return Get-Random -Minimum $StartDate.Ticks -Maximum $EndDate.Ticks | Get-Date -Format "dd/MM/yyyy HH:mm:ss"
    }
}

function Get-RandomTimeBetween{
       [Cmdletbinding()]
      param(
          [parameter(Mandatory=$True)][string]$StartTime,
          [parameter(Mandatory=$True)][string]$EndTime
          )
      begin{
          $minuteTimeArray = @("00","15","30","45")
      }    
      process{
          $rangeHours = @($StartTime.Split(":")[0],$EndTime.Split(":")[0])
          $hourTime = Get-Random -Minimum $rangeHours[0] -Maximum $rangeHours[1]
          $minuteTime = "00"
          if($hourTime -ne $rangeHours[0] -and $hourTime -ne $rangeHours[1]){
              $minuteTime = Get-Random $minuteTimeArray
              return "${hourTime}:${minuteTime}"
          }
          elseif ($hourTime -eq $rangeHours[0]) { # hour is the same as the start time so we ensure the minute time is higher
              $minuteTime = $minuteTimeArray | ?{ [int]$_ -ge [int]$StartTime.Split(":")[1] } | Get-Random # Pick the next quarter
              #If there is no quarter available (eg 09:50) we jump to the next hour (10:00)
              return (.{If(-not $minuteTime){ "${[int]hourTime+1}:00" }else{ "${hourTime}:${minuteTime}" }})               
           
          }else { # hour is the same as the end time
              #By sorting the array, 00 will be pick if no close hour quarter is found
              $minuteTime = $minuteTimeArray | Sort-Object -Descending | ?{ [int]$_ -le [int]$EndTime.Split(":")[1] } | Get-Random
              return "${hourTime}:${minuteTime}"
          }
      }
  }

$businessClassAgencyUser = `
Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-Query "SELECT TOP 1`
AU.[Agency_User_Id] `
FROM [dbo].[AgencyUser] AU  `
INNER JOIN [dbo].[Agency] A ON AU.[Agency_Id] = A.[Agency_Id] `
WHERE A.[Agency_Name] = 'Christopher Columbus' "`
-ServerInstance $env:COMPUTERNAME 

$businessClassAgencyUser = $businessClassAgencyUser.Agency_User_Id
Write-Host "The Business Class Agency User is: $businessClassAgencyUser"

$businessClassTicketType = `
Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-Query "SELECT `
[Ticket_Type_Id] `
FROM [dbo].[TicketType]  `
WHERE [Ticket_Type] = 'Business Class' "`
-ServerInstance $env:COMPUTERNAME 

$businessClassTicketType = $businessClassTicketType.Ticket_Type_Id
Write-Host "The Business Class Ticket Type is: $businessClassTicketType"

$economyClassAgencyUser = `
Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-Query "SELECT TOP 1`
AU.[Agency_User_Id] `
FROM [dbo].[AgencyUser] AU  `
INNER JOIN [dbo].[Agency] A ON AU.[Agency_Id] = A.[Agency_Id] `
WHERE A.[Agency_Name] = 'Sunchasers Ltd' "`
-ServerInstance $env:COMPUTERNAME 

$economyClassAgencyUser = $economyClassAgencyUser.Agency_User_Id
Write-Host "The Economy Class Agency User is: $economyClassAgencyUser"

$economyClassTicketType = `
Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-Query "SELECT `
[Ticket_Type_Id] `
FROM [dbo].[TicketType]  `
WHERE [Ticket_Type] = 'Economy Class' "`
-ServerInstance $env:COMPUTERNAME 

$economyClassTicketType = $economyClassTicketType.Ticket_Type_Id
Write-Host "The Economy Class Ticket Type is: $economyClassTicketType"

$flightSchedule = `
Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-OutputAs DataTables `
-Query "SELECT `
[Flight_Schedule_Id] `
FROM [dbo].[FlightSchedule]" `
-ServerInstance $env:COMPUTERNAME

$premiumEconomyClassAgencyUser = `
Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-Query "SELECT TOP 1`
AU.[Agency_User_Id] `
FROM [dbo].[AgencyUser] AU  `
INNER JOIN [dbo].[Agency] A ON AU.[Agency_Id] = A.[Agency_Id] `
WHERE A.[Agency_Name] = 'Suntours Vacaction LLC' "`
-ServerInstance $env:COMPUTERNAME 

$premiumEconomyClassAgencyUser = $premiumEconomyClassAgencyUser.Agency_User_Id
Write-Host "The Premium Economy Class Agency User is: $premiumEconomyClassAgencyUser"

$premiumEconomyClassTicketType = `
Invoke-Sqlcmd `
-Credential $sqlServerCredential `
-Database $databaseName `
-Query "SELECT `
[Ticket_Type_Id] `
FROM [dbo].[TicketType]  `
WHERE [Ticket_Type] = 'Premium Economy Class' "`
-ServerInstance $env:COMPUTERNAME 

$premiumEconomyClassTicketType = $premiumEconomyClassTicketType.Ticket_Type_Id
Write-Host "The Premium Economy Class Ticket Type is: $premiumEconomyClassTicketType"

foreach($flight in $flightSchedule.Flight_Schedule_Id)
{
    $airplaneFlight = `
    Invoke-SqlCmd `
    -Credential $sqlServerCredential `
    -Database $databaseName `
    -Query "SELECT `
    [Airplane_Id] `
    FROM [dbo].[FlightSchedule] `
    WHERE [Flight_Schedule_Id] = $flight" `
    -ServerInstance $env:COMPUTERNAME

    $airplaneFlight = $airplaneFlight.Airplane_Id
    Write-Host "The airplane for the flight is $airplaneFlight"

    $dateTimeFlight = `
    Invoke-SqlCmd `
    -Credential $sqlServerCredential `
    -Database $databaseName `
    -Query "SELECT `
    [Scheduled_Date_Time_Of_Departure_UTC] `
    FROM [dbo].[FlightSchedule] `
    WHERE [Flight_Schedule_Id] = $flight" `
    -ServerInstance $env:COMPUTERNAME

    $dateTimeFlight = $dateTimeFlight.Scheduled_Date_Time_Of_Departure_UTC
    Write-Host "The datetime for flight departure is $dateTimeFlight"

    $routeToBook = `
    Invoke-SqlCmd `
    -Credential $sqlServerCredential `
    -Database $databaseName `
    -Query "SELECT `
    [Route_Id] `
    FROM [dbo].[FlightSchedule] `
    WHERE [Flight_Schedule_Id] = $flight" `
    -ServerInstance $env:COMPUTERNAME

    $routeToBook = $routeToBook.Route_Id
    Write-Host "The route for the flight is $routeToBook"

    $businessClassBookingsCapacityUtilisation = Get-Random -Minimum 0.65 -Maximum 1
    $businessClassBookingsCapacityUtilisationRounded = [Math]::Round($businessClassBookingsCapacityUtilisation, 2)

    $businessClassBookingsToCreate = `
    Invoke-SqlCmd `
    -Credential $sqlServerCredential `
    -Database $databaseName `
    -Query "SELECT `
    CAST(ROUND([Business_Class_Seat_Count] * $businessClassBookingsCapacityUtilisationRounded, 0) AS INT) AS [Bookings_To_Create] `
    FROM [dbo].[Airplane] `
    WHERE [Airplane_Id] = $airplaneFlight" `
    -ServerInstance $env:COMPUTERNAME

    $businessClassBookingsToCreate = $businessClassBookingsToCreate.Bookings_To_Create
    Write-Host "$businessClassBookingsToCreate booking(s) will be created for this flight in Business Class"

    $economyClassBookingsCapacityUtilisation = Get-Random -Minimum 0.65 -Maximum 1
    $economyClassBookingsCapacityUtilisationRounded = [Math]::Round($economyClassBookingsCapacityUtilisation, 2)

    $economyClassBookingsToCreate = `
    Invoke-SqlCmd `
    -Credential $sqlServerCredential `
    -Database $databaseName `
    -Query "SELECT `
    CAST(ROUND([Economy_Class_Seat_Count] * $economyClassBookingsCapacityUtilisationRounded, 0) AS INT) AS [Bookings_To_Create] `
    FROM [dbo].[Airplane] `
    WHERE [Airplane_Id] = $airplaneFlight" `
    -ServerInstance $env:COMPUTERNAME

    $economyClassBookingsToCreate = $economyClassBookingsToCreate.Bookings_To_Create
    Write-Host "$economyClassBookingsToCreate booking(s) will be created for this flight in Economy Class"

    $premiumEconomyClassBookingsCapacityUtilisation = Get-Random -Minimum 0.65 -Maximum 1
    $premiumEconomyClassBookingsCapacityUtilisationRounded = [Math]::Round($premiumEconomyClassBookingsCapacityUtilisation, 2)

    $premiumEconomyClassBookingsToCreate = `
    Invoke-SqlCmd `
    -Credential $sqlServerCredential `
    -Database $databaseName `
    -Query "SELECT `
    CAST(ROUND([Premium_Economy_Class_Seat_Count] * $premiumEconomyClassBookingsCapacityUtilisationRounded, 0) AS INT) AS [Bookings_To_Create] `
    FROM [dbo].[Airplane] `
    WHERE [Airplane_Id] = $airplaneFlight" `
    -ServerInstance $env:COMPUTERNAME

    $premiumEconomyClassBookingsToCreate = $premiumEconomyClassBookingsToCreate.Bookings_To_Create
    Write-Host "$premiumEconomyClassBookingsToCreate booking(s) will be created for this flight in Premium Economy Class"

        while($businessClassBookingsToCreate -gt 0)
        {
            $dateOfBooking = Get-RandomDateBetween -StartDate $dateTimeFlight.AddDays(-272) -EndDate $dateTimeFlight.AddDays(-1)
            $dateOfBooking = [Datetime]::ParseExact($dateOfBooking, 'dd/MM/yyyy HH:mm:ss', $null)
            $timeOfBooking = Get-RandomTimeBetween -StartTime "08:00" -EndTime "18:00"
            $timeOfBooking = [System.Timespan]::Parse($timeOfBooking)
          
            [datetime]$dateTimeTicketSale = $dateOfBooking.Add($timeOfBooking)
            Write-Host "The timestamp of the booking is: $dateTimeTicketSale"

            Invoke-SqlCmd `
            -Credential $sqlServerCredential `
            -Database $databaseName `
            -Query " `
            DECLARE @ticketSaleDateTime DATETIME2 `
            SET @ticketSaleDateTime = (SELECT CAST('$dateTimeTicketSale' AS DATETIME2)) `
            DECLARE @travelDateTime DATETIME2 `
            SET @travelDateTime = (SELECT CAST('$dateTimeFlight' AS DATETIME2)) `
            `
            EXEC [dbo].[CreateBooking] @agencyUserId = $businessClassAgencyUser, `
            @routeId = $routeToBook, `
            @ticketSaleDateTime = @ticketSaleDateTime, `
            @ticketTypeId = $businessClassTicketType, `
            @travelDateTime = @travelDateTime" `
            -ServerInstance $env:COMPUTERNAME

            $businessClassBookingsToCreate = $businessClassBookingsToCreate - 1
            Write-Host "There are $businessClassBookingsToCreate more Business Class bookings to create for flight_schedule $flight"
        }

        while($economyClassBookingsToCreate -gt 0)
        {
            $dateOfBooking = Get-RandomDateBetween -StartDate $dateTimeFlight.AddDays(-272) -EndDate $dateTimeFlight.AddDays(-1)
            $dateOfBooking = [Datetime]::ParseExact($dateOfBooking, 'dd/MM/yyyy HH:mm:ss', $null)
            $timeOfBooking = Get-RandomTimeBetween -StartTime "08:00" -EndTime "18:00"
            $timeOfBooking = [System.Timespan]::Parse($timeOfBooking)
          
            [datetime]$dateTimeTicketSale = $dateOfBooking.Add($timeOfBooking)
            Write-Host "The timestamp of the booking is: $dateTimeTicketSale"

            Invoke-SqlCmd `
            -Credential $sqlServerCredential `
            -Database $databaseName `
            -Query " `
            DECLARE @ticketSaleDateTime DATETIME2 `
            SET @ticketSaleDateTime = (SELECT CAST('$dateTimeTicketSale' AS DATETIME2)) `
            DECLARE @travelDateTime DATETIME2 `
            SET @travelDateTime = (SELECT CAST('$dateTimeFlight' AS DATETIME2)) `
            `
            EXEC [dbo].[CreateBooking] @agencyUserId = $economyClassAgencyUser, `
            @routeId = $routeToBook, `
            @ticketSaleDateTime = @ticketSaleDateTime, `
            @ticketTypeId = $economyClassTicketType, `
            @travelDateTime = @travelDateTime" `
            -ServerInstance $env:COMPUTERNAME

            $economyClassBookingsToCreate = $economyClassBookingsToCreate -1
            "There are $economyClassBookingsToCreate more Economy Class bookings to create for flight_schedule $flight"
        }            

        while($premiumEconomyClassBookingsToCreate -gt 0)
        {
            $dateOfBooking = Get-RandomDateBetween -StartDate $dateTimeFlight.AddDays(-272) -EndDate $dateTimeFlight.AddDays(-1)
            $dateOfBooking = [Datetime]::ParseExact($dateOfBooking, 'dd/MM/yyyy HH:mm:ss', $null)
            $timeOfBooking = Get-RandomTimeBetween -StartTime "08:00" -EndTime "18:00"
            $timeOfBooking = [System.Timespan]::Parse($timeOfBooking)
          
            [datetime]$dateTimeTicketSale = $dateOfBooking.Add($timeOfBooking)
            Write-Host "The timestamp of the booking is: $dateTimeTicketSale"

            Invoke-SqlCmd `
            -Credential $sqlServerCredential `
            -Database $databaseName `
            -Query " `
            DECLARE @ticketSaleDateTime DATETIME2 `
            SET @ticketSaleDateTime = (SELECT CAST('$dateTimeTicketSale' AS DATETIME2)) `
            DECLARE @travelDateTime DATETIME2 `
            SET @travelDateTime = (SELECT CAST('$dateTimeFlight' AS DATETIME2)) `
            `
            EXEC [dbo].[CreateBooking] @agencyUserId = $premiumEconomyClassAgencyUser, `
            @routeId = $routeToBook, `
            @ticketSaleDateTime = @ticketSaleDateTime, `
            @ticketTypeId = $premiumEconomyClassTicketType, `
            @travelDateTime = @travelDateTime" `
            -ServerInstance $env:COMPUTERNAME

            $premiumEconomyClassBookingsToCreate = $premiumEconomyClassBookingsToCreate -1
            "There are $premiumEconomyClassBookingsToCreate more Premium Economy Class bookings to create for flight_schedule $flight"
        }            

    Write-Host "All bookings have been created for flight_schedule $flight"
}