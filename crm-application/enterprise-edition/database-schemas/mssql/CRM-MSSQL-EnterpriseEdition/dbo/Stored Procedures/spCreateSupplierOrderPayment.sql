CREATE PROCEDURE [dbo].[spCreateSupplierOrderPayment]
	@paymentAmount MONEY,
	@paymentMethodId UNIQUEIDENTIFIER,
	@supplierOrderId UNIQUEIDENTIFIER,
	@supplierOrderPaymentId UNIQUEIDENTIFIER OUTPUT,
	@supplierOrderPaymentStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #SupplierOrderPaymentIdOutputTemp
			(
				[SupplierOrderPaymentId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO [dbo].[SupplierOrderPayment] 
			(
				[SupplierOrderId],
				[PaymentMethodId],
				[PaymentAmount]
			)
			OUTPUT INSERTED.[SupplierOrderPaymentId] INTO #SupplierOrderPaymentIdOutputTemp
			VALUES
			(
				@supplierOrderId,
				@paymentMethodId,
				@paymentAmount
			)
	
			SELECT @supplierOrderPaymentId = [SupplierOrderPaymentId] FROM #SupplierOrderPaymentIdOutputTemp

			EXEC [dbo].[spCreateSupplierOrderPaymentStatusHistory]
				@supplierOrderPaymentId = @supplierOrderPaymentId,
				@supplierOrderPaymentStatusId = @supplierOrderPaymentStatusId;

			DROP TABLE #SupplierOrderPaymentIdOutputTemp;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END