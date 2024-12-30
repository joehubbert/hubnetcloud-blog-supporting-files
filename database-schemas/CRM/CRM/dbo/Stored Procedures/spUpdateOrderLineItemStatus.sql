CREATE PROCEDURE [dbo].[spUpdateOrderLineItemStatus]
	@activeStatus BIT,
	@orderLineItemStatus NVARCHAR(50),
	@orderLineItemStatusId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[OrderLineItemStatus]
SET 
	[ActiveStatus] = @activeStatus,
	[OrderLineItemStatus] = @orderLineItemStatus
WHERE [OrderLineItemStatusId] = @orderLineItemStatusId