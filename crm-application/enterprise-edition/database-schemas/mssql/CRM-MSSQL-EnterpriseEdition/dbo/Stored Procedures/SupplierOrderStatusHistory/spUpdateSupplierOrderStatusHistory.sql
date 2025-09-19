CREATE PROCEDURE [dbo].[spUpdateSupplierOrderStatusHistory]
	@supplierOrderStatusHistoryId UNIQUEIDENTIFIER,
	@supplierOrderStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrderStatusHistory]
			SET
				[SupplierOrderStatusId] = @supplierOrderStatusId
			WHERE [SupplierOrderStatusHistoryId] = @supplierOrderStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END