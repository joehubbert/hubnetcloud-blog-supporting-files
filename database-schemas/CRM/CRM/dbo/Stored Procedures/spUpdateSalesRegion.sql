CREATE PROCEDURE [dbo].[spUpdateSalesRegion]
	@salesRegion NVARCHAR(50),
	@salesRegionId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[SalesRegion]
SET 
	[SalesRegion] = @salesRegion
WHERE [SalesRegionId] = @salesRegionId