CREATE PROCEDURE [dbo].[spUpdateProductSupplier]
	@activeStatus BIT,
	@productId UNIQUEIDENTIFIER,
	@productSupplierId UNIQUEIDENTIFIER,
	@supplierId UNIQUEIDENTIFIER,
	@wholesalePricePerUnit MONEY
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[ProductSupplier]
				SET 
					[ActiveStatus] = @activeStatus,
					[ProductId] = @productId,
					[SupplierId] = @supplierId,
					[WholesalePricePerUnit] = @wholesalePricePerUnit
				WHERE [ProductSupplierId] = @productSupplierId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END