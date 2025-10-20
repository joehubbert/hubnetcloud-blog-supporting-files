CREATE PROCEDURE [dbo].[spCreateSupplierOrderLineItem]
	@productId UNIQUEIDENTIFIER,
	@supplierId UNIQUEIDENTIFIER,
	@supplierOrderId UNIQUEIDENTIFIER,
	@supplierOrderLineItemId UNIQUEIDENTIFIER OUTPUT,
	@wholesaleCartonQuantity INT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierOrderLineItemTemp
			(
				[SupplierOrderId] UNIQUEIDENTIFIER NOT NULL,
				[ProductId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #SupplierOrderLineItemTemp
			(
				[SupplierOrderId],
				[ProductId]
			)
			VALUES
			(
				@supplierOrderId,
				@productId
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[SupplierOrderLineItem] SOLI
				INNER JOIN #SupplierOrderLineItemTemp SOLIT ON SOLI.[SupplierOrderId] = SOLIT.[SupplierOrderId]
				AND SOLI.[ProductId] = SOLIT.[ProductId]
				WHERE SOLI.[SupplierOrderId] = SOLIT.[SupplierOrderId]
				AND SOLI.[ProductId] = SOLIT.[ProductId]
			)
			THROW 50000, 'Supplier Order Line Item already exists, please update the existing record.', 1;
			ELSE
			BEGIN TRY
			-- Declare variables to hold product and productsupplier information
			DECLARE @discontinuedError NVARCHAR(100)
			DECLARE @lineItemTotal MONEY
			DECLARE @productSupplierId UNIQUEIDENTIFIER
			DECLARE @productSupplierWholesalePricePerUnit MONEY
			DECLARE @wholesaleReorderFlag BIT
			DECLARE @wholesaleUnitQuantityPerCarton INT

			-- Retrieve product information
			SELECT @wholesaleReorderFlag = [WholesaleReorderFlag],
			@wholesaleUnitQuantityPerCarton = [WholesaleUnitQuantityPerCarton]
			FROM [dbo].[Product]
			WHERE [ProductId] = @productId;

			-- If the product is discontinued, raise an error
			IF @wholesaleReorderFlag = 0
			BEGIN
				SET @discontinuedError = 'The product is discontinued. It is not possible to get new stock';
				THROW 50001, @discontinuedError, 1;
			END

			-- Retrieve supplier product information
			SELECT @productSupplierId = [ProductSupplierId],
			@productSupplierWholesalePricePerUnit = [WholesalePricePerUnit]
			FROM [dbo].[ProductSupplier]
			WHERE [ProductId] = @productId
			AND [SupplierId] = @supplierId;

			-- Calculate the total line item price
			SET @lineItemTotal = @wholesaleCartonQuantity * @productSupplierWholesalePricePerUnit * @wholesaleUnitQuantityPerCarton;

			CREATE TABLE #SupplierOrderLineItemTempOutput
			(
				[SupplierOrderLineItemId] UNIQUEIDENTIFIER NOT NULL
			);

			-- Insert the new supplierOrder line item into the SupplierOrderLineItem table
			INSERT INTO [dbo].[SupplierOrderLineItem]
			(
				[SupplierOrderId],
				[ProductId],
				[WholesaleCartonQuantity],
				[WholesalePricePerUnit],
				[LineItemTotal]
			)
			OUTPUT INSERTED.[SupplierOrderLineItemId] INTO #SupplierOrderLineItemTempOutput
			SELECT
				[SupplierOrderId],
				[ProductId],
				@wholesaleCartonQuantity,
				@productSupplierWholesalePricePerUnit,
				@lineItemTotal
			FROM #SupplierOrderLineItemTemp

			SET @supplierOrderLineItemId = (SELECT [SupplierOrderLineItemId] FROM #SupplierOrderLineItemTempOutput)

			DECLARE @supplierOrderLineItemStatusId UNIQUEIDENTIFIER
			SELECT @supplierOrderLineItemStatusId = [SupplierOrderLineItemStatusId] FROM [dbo].[SupplierOrderLineItemStatus] WHERE [SupplierOrderLineItemStatus] = 'Pending'

			EXEC [dbo].[spCreateSupplierOrderLineItemStatusHistory]
				@supplierOrderLineItemId = @supplierOrderLineItemId,
				@supplierOrderLineItemStatusId = @supplierOrderLineItemStatusId

			END TRY
			BEGIN CATCH
			-- Handle any errors that occur during the transaction
			DECLARE @ErrorMessage NVARCHAR(4000);
			DECLARE @ErrorSeverity INT;
			DECLARE @ErrorState INT;

			SELECT 
				@ErrorMessage = ERROR_MESSAGE(),
				@ErrorSeverity = ERROR_SEVERITY(),
				@ErrorState = ERROR_STATE();

			-- Rethrow the error to the caller
			THROW @ErrorSeverity, @ErrorMessage, @ErrorState
			END CATCH

			DROP TABLE #SupplierOrderLineItemTemp
			DROP TABLE #SupplierOrderLineItemTempOutput

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END