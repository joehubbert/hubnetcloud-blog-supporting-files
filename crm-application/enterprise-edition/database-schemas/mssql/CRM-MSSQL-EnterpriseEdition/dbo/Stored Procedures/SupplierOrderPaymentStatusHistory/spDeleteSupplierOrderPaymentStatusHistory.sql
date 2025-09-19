CREATE PROCEDURE [dbo].[spDeleteSupplierOrderPaymentStatusHistory]
	@supplierOrderPaymentStatusHistoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE FROM [dbo].[SupplierOrderPaymentStatusHistory]
		WHERE [SupplierOrderPaymentStatusHistoryId] = @supplierOrderPaymentStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END