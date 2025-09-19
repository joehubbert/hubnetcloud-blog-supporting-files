CREATE PROCEDURE [dbo].[spCreateOrderPaymentStatusHistory]
	@orderPaymentId UNIQUEIDENTIFIER,
	@orderPaymentStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[OrderPaymentStatusHistory]
			(
				[OrderPaymentId],
				[OrderPaymentStatusId]
			)
			VALUES
			(
				@orderPaymentId,
				@orderPaymentStatusId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END