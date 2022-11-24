CREATE TABLE [dbo].[Airport]
(
	[Airport_Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Airport_Code] NCHAR(5) NOT NULL,
	[Airport_Name] NVARCHAR(100) NOT NULL,
	[Airport_City] NVARCHAR(50) NOT NULL,
	[Airport_Region] NVARCHAR(50) NOT NULL,
	[Airport_Country] NVARCHAR(50) NOT NULL,
	[Airport_Continent] NVARCHAR(50) NOT NULL,
	[Airport_Geo_Location] GEOGRAPHY NOT NULL,
	[Is_Primary_Hub] BIT NOT NULL,
	[Short_Haul_Route_Service] BIT NOT NULL,
	[Medium_Haul_Route_Service] BIT NOT NULL,
	[Long_Haul_Route_Service] BIT NOT NULL
)