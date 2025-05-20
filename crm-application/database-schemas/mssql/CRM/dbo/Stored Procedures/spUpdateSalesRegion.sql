CREATE PROCEDURE [dbo].[spUpdateSalesRegion]
	@activeStatus BIT,
	@salesRegion NVARCHAR(50),
	@salesRegionId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[SalesRegion]
SET 
	[ActiveStatus] = @activeStatus,
	[SalesRegion] = @salesRegion
WHERE [SalesRegionId] = @salesRegionId