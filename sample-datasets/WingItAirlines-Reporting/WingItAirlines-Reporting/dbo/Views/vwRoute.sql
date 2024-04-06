CREATE VIEW [dbo].[vwRoute]
AS 
SELECT 
R.[Route_Id] AS [Route Id],
R.[Route_Number] AS [Route Number],
R.[Departure_Airport_Id] AS [Departure Airport Id],
DEPA.[Airport_Name] AS [Departure Airport Name],
R.[Destination_Airport_Id] AS [Destination Airport Id],
DESA.[Airport_Name] AS [Destination Airport Name],
CONCAT(DEPA.[Airport_Name],' - ',DESA.[Airport_Name]) AS [Route Name],
R.[Route_Distance_Nautical_Miles] AS [Route Distance Nautical Miles],
CASE WHEN R.[Route_Distance_Nautical_Miles] < 700 THEN 'Short-Haul' 
WHEN R.[Route_Distance_Nautical_Miles] >= 700 AND [Route_Distance_Nautical_Miles] < 3000 THEN 'Medium Haul' 
WHEN [Route_Distance_Nautical_Miles] > 3000 THEN 'Long-Haul' 
ELSE 'Unknown' END AS [Route Type]
FROM [dbo].[Route] R
INNER JOIN [dbo].[Airport] DEPA ON R.[Departure_Airport_Id] = DEPA.[Airport_Id]
INNER JOIN [dbo].[Airport] DESA ON R.[Destination_Airport_Id] = DESA.[Airport_Id]