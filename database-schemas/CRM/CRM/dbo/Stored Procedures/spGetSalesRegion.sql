CREATE PROCEDURE [dbo].[spGetSalesRegion]
	@salesRegionId UNIQUEIDENTIFIER
AS

SELECT
[Sales Region Id],
[Sales Region]
FROM [dbo].[vwSalesRegion]
WHERE [Sales Region Id] = @salesRegionId