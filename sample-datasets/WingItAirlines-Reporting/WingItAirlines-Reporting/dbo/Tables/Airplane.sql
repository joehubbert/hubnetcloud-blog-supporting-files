CREATE TABLE [dbo].[Airplane]
(
	[Airplane_Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Airplane_Manufacturer] NVARCHAR(20) NOT NULL,
	[Airplane_Model] NVARCHAR(20) NOT NULL,
	[Airplane_Country_Of_Registration] NVARCHAR(50) NOT NULL,
	[Airplane_Date_Of_Registration] DATE NOT NULL,
	[Airplane_Registration] NVARCHAR(10) NOT NULL,
	[Airplane_Engine] NVARCHAR(50) NOT NULL,
	[Airplane_Engine_Type] NVARCHAR(10) NOT NULL,
	[Airplane_Cruise_Speed_Knots] SMALLINT NOT NULL,
	[Airplane_Range_Nautical_Miles] SMALLINT NOT NULL,
	[Is_Short_Haul_Compatible] BIT NOT NULL,
	[Is_Medium_Haul_Compatible] BIT NOT NULL,
	[Is_Long_Haul_Compatible] BIT NOT NULL,
	[Economy_Class_Seat_Count] SMALLINT NOT NULL,
	[Premium_Economy_Class_Seat_Count] SMALLINT NOT NULL,
	[Business_Class_Seat_Count] SMALLINT NOT NULL,
	[Cargo_Capacity_Tonnes] TINYINT NOT NULL
)