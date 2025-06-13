CREATE PROCEDURE [dbo].[spGetOrderLineItemStatusHistory]
	@orderLineItemStatusHistoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Order Line Item Status History Id],
			[Order Line Item Id],
			[Order Line Item Status Id],
			[Order Line Item Status],
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwOrderLineItemStatusHistory]
			WHERE [Order Line Item Status History Id] = @orderLineItemStatusHistoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END