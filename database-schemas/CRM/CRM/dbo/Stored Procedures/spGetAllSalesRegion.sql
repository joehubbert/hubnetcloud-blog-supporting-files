CREATE PROCEDURE [dbo].[spGetAllSalesRegion]
AS

SELECT
[SalesRegionId] AS [Sales Region Id],
[SalesRegion] AS [Sales Region]
FROM [dbo].[SalesRegion]