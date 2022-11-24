CREATE VIEW [dbo].[vwRoute]
AS 
SELECT 
[Route_Id],
[Route_Number],
[Departure_Airport_Id],
[Destination_Airport_Id],
[Route_Distance_Nautical_Miles],
CASE WHEN [Route_Distance_Nautical_Miles] < 700 THEN 'Short-Haul' WHEN [Route_Distance_Nautical_Miles] >= 700 AND [Route_Distance_Nautical_Miles] < 3000 THEN 'Medium Haul' WHEN [Route_Distance_Nautical_Miles] > 3000 THEN 'Long-Haul' ELSE 'Unknown' END AS [Route_Type]
FROM [dbo].[Route]