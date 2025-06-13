CREATE PROCEDURE [dbo].[spUpdateOrderPaymentStatusHistory]
	@orderPaymentId UNIQUEIDENTIFIER,
	@orderPaymentStatusHistoryId UNIQUEIDENTIFIER,
	@orderPaymentStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[OrderPaymentStatusHistory]
			SET
				[OrderPaymentId] = @orderPaymentId,
				[OrderPaymentStatusId] = @orderPaymentStatusId
			WHERE [OrderPaymentStatusHistoryId] = @orderPaymentStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END