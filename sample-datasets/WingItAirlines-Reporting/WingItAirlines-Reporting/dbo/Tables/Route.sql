CREATE TABLE [dbo].[Route]
(
	[Route_Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Route_Number] AS (CONCAT(CASE WHEN LEN([Route_Id]) = 1 THEN 'WA00' WHEN LEN([Route_Id]) = 2 THEN 'WA0' ELSE 'WA' END, [Route_Id])),
	[Departure_Airport_Id] INT NOT NULL,
	[Destination_Airport_Id] INT NOT NULL,
	[Route_Distance_Nautical_Miles] AS ([dbo].[CalculateRouteDistance]([Departure_Airport_Id],[Destination_Airport_Id]))
)
GO

ALTER TABLE [dbo].[Route]
ADD CONSTRAINT [FK_Route_Airport_Departure_Airport]
FOREIGN KEY([Departure_Airport_Id])
REFERENCES [dbo].[Airport] ([Airport_Id])
GO

ALTER TABLE [dbo].[Route]
ADD CONSTRAINT [FK_Route_Airport_Arrival_Airport]
FOREIGN KEY([Destination_Airport_Id])
REFERENCES [dbo].[Airport] ([Airport_Id])
GO

ALTER TABLE [dbo].[Route]
ADD CONSTRAINT [CC_Route_Depature_Arrival_Must_Be_Distinct]
CHECK ([Departure_Airport_Id] != [Destination_Airport_Id])
GO