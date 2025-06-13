CREATE PROCEDURE [dbo].[spCreateProductSupplier]
	@activeStatus BIT,
	@productId UNIQUEIDENTIFIER,
	@supplierId UNIQUEIDENTIFIER,
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
				[WholesalePricePerUnit] MONEY NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #ProductSupplierTemp
			(
				[ProductId],
				[SupplierId],
				[WholesalePricePerUnit],
				[ActiveStatus]
			)
			VALUES
			(
				@productId,
				@supplierId,
				@wholesalePricePerUnit,
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
				[WholesalePricePerUnit],
				[ActiveStatus]
			)
			VALUES
			(
				source.[ProductId],
				source.[SupplierId],
				source.[WholesalePricePerUnit],
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