CREATE PROCEDURE [dbo].[spUpdateProductSupplier]
	@activeStatus BIT,
	@deliveryLeadTimeDays TINYINT,
	@productId UNIQUEIDENTIFIER,
	@productSupplierId UNIQUEIDENTIFIER,
	@supplierId UNIQUEIDENTIFIER,
	@supplierProductCode NVARCHAR(50) = NULL,
	@wholesalePricePerCarton MONEY = NULL,
	@wholesalePricePerPallet MONEY = NULL,
	@wholesalePricePerUnit MONEY
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[ProductSupplier]
				SET 
					[ActiveStatus] = @activeStatus,
					[DeliveryLeadTimeDays] = @deliveryLeadTimeDays,
					[ProductId] = @productId,
					[SupplierId] = @supplierId,
					[SupplierProductCode] = @supplierProductCode,
					[WholesalePricePerCarton] = @wholesalePricePerCarton,
					[WholesalePricePerPallet] = @wholesalePricePerPallet,
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