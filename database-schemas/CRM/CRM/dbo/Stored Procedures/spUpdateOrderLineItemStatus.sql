CREATE PROCEDURE [dbo].[spUpdateOrderLineItemStatus]
	@orderLineItemStatus NVARCHAR(50),
	@orderLineItemStatusId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[OrderLineItemStatus]
SET 
	[OrderLineItemStatus] = @orderLineItemStatus
WHERE [OrderLineItemStatusId] = @orderLineItemStatusId