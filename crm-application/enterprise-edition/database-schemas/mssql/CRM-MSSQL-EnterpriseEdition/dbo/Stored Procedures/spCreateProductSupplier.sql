CREATE PROCEDURE [dbo].[spCreateProductSupplier]
	@activeStatus BIT,
	@productId UNIQUEIDENTIFIER,
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

			CREATE TABLE #ProductSupplierTemp
			(
				[ProductId] UNIQUEIDENTIFIER NOT NULL,
				[SupplierId] UNIQUEIDENTIFIER NOT NULL,
				[WholesalePricePerCarton] MONEY NULL,
				[WholesalePricePerPallet] MONEY NULL,
				[WholesalePricePerUnit] MONEY NOT NULL,
				[SupplierProductCode] NVARCHAR(50) NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #ProductSupplierTemp
			(
				[ProductId],
				[SupplierId],
				[WholesalePricePerCarton],
				[WholesalePricePerPallet],
				[WholesalePricePerUnit],
				[SupplierProductCode],
				[ActiveStatus]
			)
			VALUES
			(
				@productId,
				@supplierId,
				@wholesalePricePerCarton,
				@wholesalePricePerPallet,
				@wholesalePricePerUnit,
				@supplierProductCode,
				@activeStatus
			)

			MERGE INTO [dbo].[ProductSupplier] AS target
			USING #ProductSupplierTemp AS source
			ON target.[ProductId] = source.[ProductId]
			AND target.[SupplierId] = source.[SupplierId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ProductId],
				[SupplierId],
				[WholesalePricePerCarton],
				[WholesalePricePerPallet],
				[WholesalePricePerUnit],
				[SupplierProductCode],
				[ActiveStatus]
			)
			VALUES
			(
				source.[ProductId],
				source.[SupplierId],
				source.[WholesalePricePerCarton],
				source.[WholesalePricePerPallet],
				source.[WholesalePricePerUnit],
				source.[SupplierProductCode],
				source.[ActiveStatus]
			);

			DROP TABLE #ProductSupplierTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END