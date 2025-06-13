CREATE PROCEDURE [dbo].[spUpdateOrderLineItemStatusHistory]
	@orderLineItemStatusId UNIQUEIDENTIFIER,
	@orderLineItemStatusHistoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[OrderLineItemStatusHistory]
			SET 
				[OrderLineItemStatusId] = @orderLineItemStatusId
			WHERE [OrderLineItemStatusHistoryId] = @orderLineItemStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END