CREATE PROCEDURE [dbo].[spCreateOrderPayment]
	@orderId UNIQUEIDENTIFIER,
	@orderPaymentId UNIQUEIDENTIFIER OUTPUT,
	@orderPaymentStatusId UNIQUEIDENTIFIER,
	@paymentAmount MONEY,
	@paymentMethodId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderPaymentIdOutputTemp
			(
				[OrderPaymentId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO [dbo].[OrderPayment] 
			(
				[OrderId],
				[PaymentMethodId],
				[PaymentAmount]
			)
			OUTPUT INSERTED.[OrderPaymentId] INTO #OrderPaymentIdOutputTemp
			VALUES
			(
				@orderId,
				@paymentMethodId,
				@paymentAmount
			)
	
			SELECT @orderPaymentId = [OrderPaymentId] FROM #OrderPaymentIdOutputTemp

			EXEC [dbo].[spCreateOrderPaymentStatusHistory]
				@orderPaymentId = @orderPaymentId,
				@orderPaymentStatusId = @orderPaymentStatusId;

			DROP TABLE #OrderPaymentIdOutputTemp;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END