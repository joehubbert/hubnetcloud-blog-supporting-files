CREATE PROCEDURE [dbo].[spUpdateOrderStatusHistory]
	@orderStatusHistoryId UNIQUEIDENTIFIER,
	@orderStatusId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[OrderStatusHistory]
SET
	[OrderStatusId] = @orderStatusId
WHERE [OrderStatusHistoryId] = @orderStatusHistoryId