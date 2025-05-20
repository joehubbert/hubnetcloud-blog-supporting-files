CREATE PROCEDURE [dbo].[spCreateOrderLineItemStatusHistory]
	@orderLineItemId UNIQUEIDENTIFIER,
	@orderLineItemStatusId UNIQUEIDENTIFIER
AS

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