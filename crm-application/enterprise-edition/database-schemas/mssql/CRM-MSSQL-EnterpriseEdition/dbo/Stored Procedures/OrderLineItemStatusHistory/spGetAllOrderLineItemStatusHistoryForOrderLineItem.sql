CREATE PROCEDURE [dbo].[spGetAllOrderLineItemStatusHistoryForOrderLineItem]
	@orderLineItemId UNIQUEIDENTIFIER
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
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwOrderLineItemStatusHistory]
			WHERE [Order Line Item Id] = @orderLineItemId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END