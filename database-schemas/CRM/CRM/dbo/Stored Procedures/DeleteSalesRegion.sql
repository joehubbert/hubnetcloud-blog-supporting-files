CREATE PROCEDURE [dbo].[DeleteSalesRegion]
	@salesRegionId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[SalesRegion]
WHERE [SalesRegionId] = @salesRegionId