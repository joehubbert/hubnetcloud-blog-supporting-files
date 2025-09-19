CREATE PROCEDURE [dbo].[spDeleteSupplierOrderPaymentStatus]
	@supplierOrderPaymentStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE FROM [dbo].[SupplierOrderPaymentStatus]
		WHERE [SupplierOrderPaymentStatusId] = @supplierOrderPaymentStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END