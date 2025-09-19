CREATE PROCEDURE [dbo].[spUpdateOrderType]
	@activeStatus BIT,
	@orderType NVARCHAR(50),
	@orderTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[OrderType]
			SET 
				[ActiveStatus] = @activeStatus,
				[OrderType] = @orderType
			WHERE [OrderTypeId] = @orderTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END