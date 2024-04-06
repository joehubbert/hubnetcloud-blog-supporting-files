CREATE VIEW [dbo].[vwAirport]
AS
SELECT 
[Airport_Id] AS [Airport Id],
[Airport_Code] AS [Airport Code],
[Airport_Name] AS [Airport Name],
[Airport_City] AS [Airport City],
[Airport_Region] AS [Airport Region],
[Airport_Country] AS [Airport Country],
[Airport_Continent] AS [Airport Continent],
[Airport_Geo_Location] AS [Airport Geographic Location],
[Is_Primary_Hub] AS [Primary Hub],
[Short_Haul_Route_Service] AS [Short Haul Route Service],
[Medium_Haul_Route_Service] AS [Medium Haul Route Service],
[Long_Haul_Route_Service] AS [Long Haul Route Service]
FROM [dbo].[Airport]