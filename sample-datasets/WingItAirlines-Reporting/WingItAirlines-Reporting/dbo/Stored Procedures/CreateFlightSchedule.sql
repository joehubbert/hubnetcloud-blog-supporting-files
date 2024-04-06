CREATE PROCEDURE [dbo].[CreateFlightSchedule]
@startDate DATE,
@endDate DATE
AS

--Set the loop date
DECLARE @loopDate DATE
SET @loopDate = @startDate

--Define the schema of the temp table for loading scheduled flights
CREATE TABLE #newFlights (
[Route_Id] INT NOT NULL,
[Airplane_Id] INT NOT NULL,
[Scheduled_DateTime_Departure_UTC] DATETIME2 NOT NULL, 
[Scheduled_Flight_Duration] TIME NOT NULL,
[Scheduled_DateTime_Arrival_UTC] AS (CAST(DATEADD(SECOND,(DATEPART(HOUR, [Scheduled_Flight_Duration]) * 3600 + DATEPART(MINUTE, [Scheduled_Flight_Duration]) * 60 + DATEPART(SECOND, [Scheduled_Flight_Duration])), [Scheduled_DateTime_Departure_UTC]) AS DATETIME2))
)

WHILE @loopDate < @endDate
BEGIN

INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (3,50, CAST(CONCAT(@loopDate, ' ',  '08:50:00') AS DATETIME2), '10:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (4,50, CAST(CONCAT(@loopDate, ' ',  '19:50:00') AS DATETIME2), '10:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (69,51, CAST(CONCAT(@loopDate, ' ',  '09:00:00') AS DATETIME2), '10:15:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (70,51, CAST(CONCAT(@loopDate, ' ',  '20:15:00') AS DATETIME2), '10:15:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (25,52, CAST(CONCAT(@loopDate, ' ',  '10:00:00') AS DATETIME2), '09:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (26,52, CAST(CONCAT(@loopDate, ' ',  '13:50:00') AS DATETIME2), '09:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (64,53, CAST(CONCAT(@loopDate, ' ',  '01:15:00') AS DATETIME2), '09:45:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (63,53, CAST(CONCAT(@loopDate, ' ',  '12:00:00') AS DATETIME2), '09:45:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (77,54, CAST(CONCAT(@loopDate, ' ',  '09:15:00') AS DATETIME2), '09:35:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (78,54, CAST(CONCAT(@loopDate, ' ',  '19:50:00') AS DATETIME2), '09:35:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (7,14, CAST(CONCAT(@loopDate, ' ',  '10:40:00') AS DATETIME2), '09:35:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (8,14, CAST(CONCAT(@loopDate, ' ',  '21:15:00') AS DATETIME2), '09:35:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (79,55, CAST(CONCAT(@loopDate, ' ',  '10:30:00') AS DATETIME2), '08:55:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (80,55, CAST(CONCAT(@loopDate, ' ',  '20:20:00') AS DATETIME2), '08:55:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (33,7, CAST(CONCAT(@loopDate, ' ',  '20:30:00') AS DATETIME2), '05:40:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (34,7, CAST(CONCAT(@loopDate, ' ',  '03:10:00') AS DATETIME2), '05:40:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (72,8, CAST(CONCAT(@loopDate, ' ',  '09:00:00') AS DATETIME2), '05:35:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (71,8, CAST(CONCAT(@loopDate, ' ',  '15:30:00') AS DATETIME2), '05:35:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (104,40, CAST(CONCAT(@loopDate, ' ',  '08:30:00') AS DATETIME2), '05:05:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (103,40, CAST(CONCAT(@loopDate, ' ',  '14:35:00') AS DATETIME2), '05:05:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (27,9, CAST(CONCAT(@loopDate, ' ',  '23:00:00') AS DATETIME2), '04:55:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (28,9, CAST(CONCAT(@loopDate, ' ',  '02:50:00') AS DATETIME2), '04:55:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (56,41, CAST(CONCAT(@loopDate, ' ',  '17:00:00') AS DATETIME2), '04:45:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (55,41, CAST(CONCAT(@loopDate, ' ',  '11:15:00') AS DATETIME2), '04:45:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (29,10, CAST(CONCAT(@loopDate, ' ',  '22:00:00') AS DATETIME2), '04:45:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (30,10, CAST(CONCAT(@loopDate, ' ',  '03:45:00') AS DATETIME2), '04:45:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (67,11, CAST(CONCAT(@loopDate, ' ',  '22:05:00') AS DATETIME2), '04:25:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (68,11, CAST(CONCAT(@loopDate, ' ',  '03:30:00') AS DATETIME2), '04:25:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (23,42, CAST(CONCAT(@loopDate, ' ',  '13:00:00') AS DATETIME2), '04:15:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (24,42, CAST(CONCAT(@loopDate, ' ',  '17:15:00') AS DATETIME2), '04:15:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (60,20, CAST(CONCAT(@loopDate, ' ',  '18:45:00') AS DATETIME2), '04:10:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (59,20, CAST(CONCAT(@loopDate, ' ',  '23:55:00') AS DATETIME2), '04:10:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (49,43, CAST(CONCAT(@loopDate, ' ',  '12:30:00') AS DATETIME2), '04:05:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (50,43, CAST(CONCAT(@loopDate, ' ',  '16:10:00') AS DATETIME2), '04:05:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (43,44, CAST(CONCAT(@loopDate, ' ',  '13:45:00') AS DATETIME2), '03:55:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (44,44, CAST(CONCAT(@loopDate, ' ',  '18:45:00') AS DATETIME2), '03:55:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (47,45, CAST(CONCAT(@loopDate, ' ',  '12:15:00') AS DATETIME2), '04:00:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (48,45, CAST(CONCAT(@loopDate, ' ',  '16:45:00') AS DATETIME2), '04:00:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (21,21, CAST(CONCAT(@loopDate, ' ',  '14:00:00') AS DATETIME2), '03:55:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (22,21, CAST(CONCAT(@loopDate, ' ',  '18:25:00') AS DATETIME2), '03:55:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (45,22, CAST(CONCAT(@loopDate, ' ',  '11:15:00') AS DATETIME2), '03:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (46,22, CAST(CONCAT(@loopDate, ' ',  '18:25:00') AS DATETIME2), '03:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (37,23, CAST(CONCAT(@loopDate, ' ',  '13:20:00') AS DATETIME2), '03:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (1,23, CAST(CONCAT(@loopDate, ' ',  '15:35:00') AS DATETIME2), '03:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (2,24, CAST(CONCAT(@loopDate, ' ',  '19:00:00') AS DATETIME2), '03:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (38,24, CAST(CONCAT(@loopDate, ' ',  '17:40:00') AS DATETIME2), '03:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (54,25, CAST(CONCAT(@loopDate, ' ',  '15:00:00') AS DATETIME2), '03:40:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (53,25, CAST(CONCAT(@loopDate, ' ',  '23:20:00') AS DATETIME2), '03:40:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (105,26, CAST(CONCAT(@loopDate, ' ',  '17:00:00') AS DATETIME2), '03:25:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (106,26, CAST(CONCAT(@loopDate, ' ',  '19:10:00') AS DATETIME2), '03:25:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (109,27, CAST(CONCAT(@loopDate, ' ',  '16:00:00') AS DATETIME2), '03:20:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (110,27, CAST(CONCAT(@loopDate, ' ',  '20:55:00') AS DATETIME2), '03:20:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (39,28, CAST(CONCAT(@loopDate, ' ',  '11:00:00') AS DATETIME2), '03:00:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (40,28, CAST(CONCAT(@loopDate, ' ',  '19:50:00') AS DATETIME2), '03:00:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (81,29, CAST(CONCAT(@loopDate, ' ',  '09:00:00') AS DATETIME2), '02:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (82,29, CAST(CONCAT(@loopDate, ' ',  '14:30:00') AS DATETIME2), '02:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (74,18, CAST(CONCAT(@loopDate, ' ',  '06:30:00') AS DATETIME2), '02:45:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (73,18, CAST(CONCAT(@loopDate, ' ',  '12:20:00') AS DATETIME2), '02:45:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (51,30, CAST(CONCAT(@loopDate, ' ',  '11:00:00') AS DATETIME2), '02:40:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (52,30, CAST(CONCAT(@loopDate, ' ',  '09:45:00') AS DATETIME2), '02:40:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (111,31, CAST(CONCAT(@loopDate, ' ',  '19:00:00') AS DATETIME2), '02:35:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (112,31, CAST(CONCAT(@loopDate, ' ',  '14:10:00') AS DATETIME2), '02:35:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (20,1, CAST(CONCAT(@loopDate, ' ',  '18:00:00') AS DATETIME2), '02:25:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (19,1, CAST(CONCAT(@loopDate, ' ',  '22:05:00') AS DATETIME2), '02:25:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (95,32, CAST(CONCAT(@loopDate, ' ',  '15:30:00') AS DATETIME2), '02:20:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (96,32, CAST(CONCAT(@loopDate, ' ',  '20:55:00') AS DATETIME2), '02:20:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (115,33, CAST(CONCAT(@loopDate, ' ',  '19:45:00') AS DATETIME2), '02:15:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (116,33, CAST(CONCAT(@loopDate, ' ',  '18:20:00') AS DATETIME2), '02:15:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (9,2, CAST(CONCAT(@loopDate, ' ',  '14:00:00') AS DATETIME2), '02:15:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (10,2, CAST(CONCAT(@loopDate, ' ',  '22:30:00') AS DATETIME2), '02:15:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (35,3, CAST(CONCAT(@loopDate, ' ',  '12:45:00') AS DATETIME2), '02:05:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (36,3, CAST(CONCAT(@loopDate, ' ',  '16:45:00') AS DATETIME2), '02:05:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (87,34, CAST(CONCAT(@loopDate, ' ',  '08:30:00') AS DATETIME2), '02:10:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (88,34, CAST(CONCAT(@loopDate, ' ',  '15:20:00') AS DATETIME2), '02:10:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (123,35, CAST(CONCAT(@loopDate, ' ',  '17:15:00') AS DATETIME2), '02:05:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (124,35, CAST(CONCAT(@loopDate, ' ',  '11:10:00') AS DATETIME2), '02:05:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (94,36, CAST(CONCAT(@loopDate, ' ',  '13:30:00') AS DATETIME2), '01:55:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (93,36, CAST(CONCAT(@loopDate, ' ',  '19:50:00') AS DATETIME2), '01:55:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (57,37, CAST(CONCAT(@loopDate, ' ',  '14:45:00') AS DATETIME2), '01:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (58,37, CAST(CONCAT(@loopDate, ' ',  '15:55:00') AS DATETIME2), '01:50:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (5,38, CAST(CONCAT(@loopDate, ' ',  '17:30:00') AS DATETIME2), '01:40:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (6,38, CAST(CONCAT(@loopDate, ' ',  '17:05:00') AS DATETIME2), '01:40:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (89,39, CAST(CONCAT(@loopDate, ' ',  '11:00:00') AS DATETIME2), '01:40:00')
INSERT INTO #newFlights ([Route_Id], [Airplane_Id], [Scheduled_DateTime_Departure_UTC], [Scheduled_Flight_Duration]) VALUES (90,39, CAST(CONCAT(@loopDate, ' ',  '19:40:00') AS DATETIME2), '01:40:00')

MERGE INTO [dbo].[FlightSchedule] AS DEST
USING #newFlights AS SRC
ON DEST.[Route_Id] = SRC.[Route_Id]
AND DEST.[Airplane_Id] = SRC.[Airplane_Id]
AND DEST.[Scheduled_DateTime_Departure_UTC] = SRC.[Scheduled_DateTime_Departure_UTC]
AND DEST.[Scheduled_DateTime_Arrival_UTC] = SRC.[Scheduled_DateTime_Arrival_UTC]
AND DEST.[Scheduled_Flight_Duration] = SRC.[Scheduled_Flight_Duration]
WHEN NOT MATCHED BY TARGET
THEN
INSERT
(
	[Route_Id],
	[Airplane_Id],
	[Scheduled_DateTime_Departure_UTC],
	[Scheduled_DateTime_Arrival_UTC],
	[Scheduled_Flight_Duration]
)
VALUES
(
	SRC.[Route_Id],
	SRC.[Airplane_Id],
	SRC.[Scheduled_DateTime_Departure_UTC],
	SRC.[Scheduled_DateTime_Arrival_UTC],
	SRC.[Scheduled_Flight_Duration]
)
;

TRUNCATE TABLE #newFlights

SET @loopDate = DATEADD(DAY, 1, @loopDate)
END