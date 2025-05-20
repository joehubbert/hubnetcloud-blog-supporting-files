CREATE PROCEDURE [dbo].[spUpdateSalesSubRegion]
	@activeStatus BIT,
	@salesRegionId UNIQUEIDENTIFIER,
	@salesSubRegion NVARCHAR(50),
	@salesSubRegionId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[SalesSubRegion]
SET 
	[ActiveStatus] = @activeStatus,
	[SalesRegionId] = @salesRegionId,
	[SalesSubRegion] = @salesSubRegion
WHERE [SalesSubRegionId] = @salesSubRegionId