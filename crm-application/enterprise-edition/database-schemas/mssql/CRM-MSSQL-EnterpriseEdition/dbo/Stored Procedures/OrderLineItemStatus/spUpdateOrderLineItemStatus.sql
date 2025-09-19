CREATE PROCEDURE [dbo].[spUpdateOrderLineItemStatus]
	@activeStatus BIT,
	@orderLineItemStatus NVARCHAR(50),
	@orderLineItemStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[OrderLineItemStatus]
			SET 
				[ActiveStatus] = @activeStatus,
				[OrderLineItemStatus] = @orderLineItemStatus
			WHERE [OrderLineItemStatusId] = @orderLineItemStatusId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END