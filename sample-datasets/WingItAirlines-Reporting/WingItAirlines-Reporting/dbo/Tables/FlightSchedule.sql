CREATE TABLE [dbo].[FlightSchedule]
(
	[Flight_Schedule_Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Route_Id] INT NOT NULL,
	[Airplane_Id] INT NOT NULL,
	[Scheduled_Date_Time_Of_Departure_UTC] DATETIME2 NOT NULL,
	[Scheduled_Date_Time_Of_Arrival_UTC] DATETIME2 NOT NULL,
	[Scheduled_Flight_Duration] TIME NOT NULL,
)
GO

ALTER TABLE [dbo].[FlightSchedule]
ADD CONSTRAINT [FK_FlightSchedule_Route]
FOREIGN KEY([Route_Id])
REFERENCES [dbo].[Route] ([Route_Id])
GO

ALTER TABLE [dbo].[FlightSchedule]
ADD CONSTRAINT [FK_FlightSchedule_Airplane]
FOREIGN KEY([Airplane_Id])
REFERENCES [dbo].[Airplane] ([Airplane_Id])
GO