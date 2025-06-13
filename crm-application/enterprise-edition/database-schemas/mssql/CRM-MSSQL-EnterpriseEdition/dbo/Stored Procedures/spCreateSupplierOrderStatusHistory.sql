CREATE PROCEDURE [dbo].[spCreateSupplierOrderStatusHistory]
	@supplierOrderId UNIQUEIDENTIFIER,
	@supplierOrderStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[SupplierOrderStatusHistory]
			(
				[SupplierOrderId],
				[SupplierOrderStatusId]
			)
			VALUES
			(
				@supplierOrderId,
				@supplierOrderStatusId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END