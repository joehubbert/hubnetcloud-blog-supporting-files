CREATE PROCEDURE [dbo].[spUpdateSupplierOrderPayment]
	@paymentMethodId UNIQUEIDENTIFIER,
	@supplierOrderPaymentId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierOrderPayment]
			SET 
				[PaymentMethodId] = @paymentMethodId
			WHERE [SupplierOrderPaymentId] = @supplierOrderPaymentId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END