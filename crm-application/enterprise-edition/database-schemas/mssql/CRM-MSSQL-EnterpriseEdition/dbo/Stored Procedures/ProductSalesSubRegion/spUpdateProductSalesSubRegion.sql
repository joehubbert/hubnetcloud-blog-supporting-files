CREATE PROCEDURE [dbo].[spUpdateProductSalesSubRegion]
	@activeStatus BIT,
	@productId UNIQUEIDENTIFIER,
	@productSalesSubRegionId UNIQUEIDENTIFIER,
	@salesSubRegionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[ProductSalesSubRegion]
			SET
				[ActiveStatus] = @activeStatus,
				[ProductId] = @productId,
				[SalesSubRegionId] = @salesSubRegionId
			WHERE [ProductSalesSubRegionId] = @productSalesSubRegionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END