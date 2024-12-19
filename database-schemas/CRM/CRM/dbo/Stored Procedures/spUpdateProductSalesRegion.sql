CREATE PROCEDURE [dbo].[spUpdateProductSalesRegion]
	@activeStatus BIT,
	@productId UNIQUEIDENTIFIER,
	@productSalesRegionId UNIQUEIDENTIFIER,
	@salesRegionId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[ProductSalesRegion]
SET
	[ActiveStatus] = @activeStatus,
	[ProductId] = @productId,
	[SalesRegionId] = @salesRegionId
WHERE [ProductSalesRegionId] = @productSalesRegionId