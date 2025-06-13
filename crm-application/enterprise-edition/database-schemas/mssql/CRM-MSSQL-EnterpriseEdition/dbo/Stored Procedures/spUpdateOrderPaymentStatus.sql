CREATE PROCEDURE [dbo].[spUpdateOrderPaymentStatus]
	@activeStatus BIT,
	@orderPaymentStatusId UNIQUEIDENTIFIER,
	@orderPaymentStatus NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[OrderPaymentStatus]
			SET
				[OrderPaymentStatus] = @orderPaymentStatus,
				[ActiveStatus] = @activeStatus
			WHERE [OrderPaymentStatusId] = @orderPaymentStatusId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END