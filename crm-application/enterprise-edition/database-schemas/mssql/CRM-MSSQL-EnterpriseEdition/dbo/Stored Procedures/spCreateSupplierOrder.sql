CREATE PROCEDURE [dbo].[spCreateSupplierOrder]
	@internalReference NVARCHAR(50) = NULL,
	@supplierId UNIQUEIDENTIFIER,
	@supplierOrderId UNIQUEIDENTIFIER OUTPUT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierOrderTempOutput
			(
				[SupplierOrderId] UNIQUEIDENTIFIER NOT NULL
			);

			INSERT INTO [dbo].[SupplierOrder]
			(
				[InternalReference],
				[SupplierId]
			)
			OUTPUT INSERTED.[SupplierOrderId] INTO #SupplierOrderTempOutput
			VALUES
			(
				@internalReference,
				@supplierId
			);

			SET @supplierOrderId = (SELECT [SupplierOrderId] FROM #SupplierOrderTempOutput);
			DROP TABLE #SupplierOrderTempOutput;

			DECLARE @supplierOrderStatusId UNIQUEIDENTIFIER;
			SELECT @supplierOrderStatusId = [SupplierOrderStatusId] FROM [dbo].[SupplierOrderStatus] WHERE [SupplierOrderStatus] = 'New';

			EXEC [dbo].[spCreateSupplierOrderStatusHistory]
				@supplierOrderId = @supplierOrderId,
				@supplierOrderStatusId = @supplierOrderStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END