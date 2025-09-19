CREATE PROCEDURE [dbo].[spCreateOrderLineItemStatusHistory]
	@orderLineItemId UNIQUEIDENTIFIER,
	@orderLineItemStatusId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[OrderLineItemStatusHistory]
			(
				[OrderLineItemId],
				[OrderLineItemStatusId]
			)
			VALUES
			(
				@orderLineItemId,
				@orderLineItemStatusId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END