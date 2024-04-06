CREATE VIEW [dbo].[vwFlightSchedule]
AS
SELECT
[Flight_Schedule_Id] AS [Flight Schedule Id],
[Route_Id] AS [Route Id],
[Airplane_Id] AS [Airplane Id],
[Scheduled_DateTime_Departure_UTC] AS [Schedule DateTime of Departure (UTC)],
[Scheduled_DateTime_Arrival_UTC] AS [Schedule DateTime of Arrival (UTC)],
[Scheduled_Flight_Duration] AS [Scheduled Flight Duration],
CAST([Scheduled_DateTime_Departure_UTC] AS DATE) AS [Scheduled Date of Departure]
FROM [dbo].[FlightSchedule]