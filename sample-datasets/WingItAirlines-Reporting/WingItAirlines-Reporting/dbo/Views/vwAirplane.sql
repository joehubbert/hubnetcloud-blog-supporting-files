CREATE VIEW [dbo].[vwAirplane]
AS
SELECT 
	[Airplane_Id] AS [Airplane Id],
	[Airplane_Manufacturer] AS [Airline Manufacturer],
	[Airplane_Model] AS [Airplane Model],
	[Airplane_Country_Of_Registration] AS [Airplane Country of Registration],
	[Airplane_Date_Of_Registration] AS [Airplane Date of Registration],
	[Airplane_Registration] AS [Airplane Registration],
	[Airplane_Engine] AS [Airplane Engine],
	[Airplane_Engine_Type] AS [Airplane Engine Type],
	[Airplane_Cruise_Speed_Knots] AS [Airplane Cruise Speed (Knots)],
	[Airplane_Range_Nautical_Miles] AS [Airplane Range (Nautical Miles)],
	[Is_Short_Haul_Compatible] AS [Short Haul Compatible],
	[Is_Medium_Haul_Compatible] AS [Medium Haul Compatible],
	[Is_Long_Haul_Compatible] AS [Long Haul Compatible],
	[Economy_Class_Seat_Count] AS [Economy Class Seat Count],
	[Premium_Economy_Class_Seat_Count] AS [Premium Economy Class Seat Count],
	[Business_Class_Seat_Count] AS [Business Class Seat Count],
	[Cargo_Capacity_Tonnes] AS [Cargo Capacity (Tonnes)]
FROM [dbo].[Airplane]
