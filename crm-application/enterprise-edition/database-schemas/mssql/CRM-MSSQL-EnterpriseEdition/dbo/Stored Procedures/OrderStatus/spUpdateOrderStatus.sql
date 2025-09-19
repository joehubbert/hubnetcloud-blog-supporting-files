CREATE PROCEDURE [dbo].[spUpdateOrderStatus]
	@activeStatus BIT,
	@orderStatus NVARCHAR(50),
	@orderStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[OrderStatus]
			SET 
				[ActiveStatus] = @activeStatus,
				[OrderStatus] = @orderStatus
			WHERE [OrderStatusId] = @orderStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END