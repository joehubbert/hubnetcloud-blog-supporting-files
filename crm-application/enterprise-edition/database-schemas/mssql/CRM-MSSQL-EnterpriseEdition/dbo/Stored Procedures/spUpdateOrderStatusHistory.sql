CREATE PROCEDURE [dbo].[spUpdateOrderStatusHistory]
	@orderStatusHistoryId UNIQUEIDENTIFIER,
	@orderStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[OrderStatusHistory]
			SET
				[OrderStatusId] = @orderStatusId
			WHERE [OrderStatusHistoryId] = @orderStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END