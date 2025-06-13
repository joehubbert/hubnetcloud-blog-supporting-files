CREATE PROCEDURE [dbo].[spUpdateSupplierOrderPaymentStatusHistory]
	@supplierOrderPaymentId UNIQUEIDENTIFIER,
	@supplierOrderPaymentStatusHistoryId UNIQUEIDENTIFIER,
	@supplierOrderPaymentStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrderPaymentStatusHistory]
			SET
				[SupplierOrderPaymentId] = @supplierOrderPaymentId,
				[SupplierOrderPaymentStatusId] = @supplierOrderPaymentStatusId
			WHERE [SupplierOrderPaymentStatusHistoryId] = @supplierOrderPaymentStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END