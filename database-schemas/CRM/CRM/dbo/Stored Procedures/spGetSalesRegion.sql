CREATE PROCEDURE [dbo].[spGetSalesRegion]
	@salesRegionId UNIQUEIDENTIFIER
AS

SELECT
[SalesRegionId]	AS [Sales Region Id],
[SalesRegion] AS [Sales Region]
FROM [dbo].[SalesRegion]
WHERE [SalesRegionId] = @salesRegionId