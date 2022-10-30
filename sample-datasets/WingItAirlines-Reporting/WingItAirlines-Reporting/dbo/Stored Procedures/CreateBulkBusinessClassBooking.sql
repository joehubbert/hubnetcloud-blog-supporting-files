CREATE PROCEDURE [dbo].[CreateBulkBusinessClassBooking]

AS

SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
SET LOCK_TIMEOUT 10000;

DECLARE @agencyUserId INT
DECLARE @amountOfBookingsToCreate INT
DECLARE @businessClassCapacity FLOAT
DECLARE @economyClassCapacity FLOAT
DECLARE @flightScheduleDateTime DATETIME2
DECLARE @flightScheduleIdCounter BIGINT
DECLARE @flightsToBook TABLE(
[Flight_Schedule_Id] BIGINT,
[Route_Id] INT,
[Airplane_Id] INT,
[Scheduled_Date_Time_Of_Departure_UTC] DATETIME2
)
DECLARE @premiumEconomyClassCapacity FLOAT
DECLARE @routeToBook INT
DECLARE @ticketTypeToBook INT

INSERT INTO @flightsToBook
SELECT
[Flight_Schedule_Id],
[Route_Id],
[Airplane_Id],
[Scheduled_Date_Time_Of_Departure_UTC]
FROM [dbo].[FlightSchedule]

SET @flightScheduleIdCounter = (SELECT MAX([Flight_Schedule_Id]) AS [Flight_Schedule_Id] FROM @flightsToBook)

WHILE @flightScheduleIdCounter >= 1

BEGIN
SET @flightScheduleDateTime = (
SELECT [Scheduled_Date_Time_Of_Departure_UTC] 
FROM @flightsToBook
WHERE [Flight_Schedule_Id] = @flightScheduleIdCounter
)
SET @routeToBook = (
SELECT [Route_Id]
FROM @flightsToBook
WHERE [Flight_Schedule_Id] = @flightScheduleIdCounter
)

SET @agencyUserId = (
SELECT TOP 1 AU.[Agency_User_Id]
FROM [dbo].[AgencyUser] AU
INNER JOIN [dbo].[Agency] A ON AU.[Agency_Id] = A.[Agency_Id]
WHERE A.[Agency_Name] = 'Christopher Columbus'
)

--Book 80% of the business class capacity
SET @amountOfBookingsToCreate = (
SELECT SUM(A.[Business_Class_Seat_Count]/100 * 0.8) AS [Bookings_To_Create]
FROM [dbo].[Airplane] A 
INNER JOIN @flightsToBook FTB ON A.[Airplane_Id] = FTB.[Airplane_Id]
WHERE FTB.[Flight_Schedule_Id] = @flightScheduleIdCounter
)

SET @ticketTypeToBook = (
SELECT [Ticket_Type_Id]
FROM [dbo].[TicketType]
WHERE [Ticket_Type] = 'Business Class'
)

WHILE @amountOfBookingsToCreate > 0
BEGIN 
EXEC [dbo].[CreateBooking] @agencyUserId = @agencyUserId, @routeId = @routeToBook, @ticketTypeId = @ticketTypeToBook, @travelDateTime = @flightScheduleDateTime
SET @amountOfBookingsToCreate = @amountOfBookingsToCreate - 1
END

SET @flightScheduleIdCounter = @flightScheduleIdCounter - 1
END