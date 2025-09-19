CREATE PROCEDURE [dbo].[spCreateSupplierOrderPaymentStatusHistory]
	@supplierOrderPaymentId UNIQUEIDENTIFIER,
	@supplierOrderPaymentStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[SupplierOrderPaymentStatusHistory]
			(
				[SupplierOrderPaymentId],
				[SupplierOrderPaymentStatusId]
			)
			VALUES
			(
				@supplierOrderPaymentId,
				@supplierOrderPaymentStatusId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END