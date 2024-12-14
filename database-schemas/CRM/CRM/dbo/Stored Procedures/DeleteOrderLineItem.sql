CREATE PROCEDURE [dbo].[DeleteOrderLineItem]
	@orderLineItemId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[OrderLineItem]
WHERE [OrderLineItemId] = @orderLineItemId