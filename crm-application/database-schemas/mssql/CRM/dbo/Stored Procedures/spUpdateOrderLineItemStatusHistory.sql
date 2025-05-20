CREATE PROCEDURE [dbo].[spUpdateOrderLineItemStatusHistory]
	@orderLineItemStatusId UNIQUEIDENTIFIER,
	@orderLineItemStatusHistoryId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[OrderLineItemStatusHistory]
SET 
	[OrderLineItemStatusId] = @orderLineItemStatusId
WHERE [OrderLineItemStatusHistoryId] = @orderLineItemStatusHistoryId