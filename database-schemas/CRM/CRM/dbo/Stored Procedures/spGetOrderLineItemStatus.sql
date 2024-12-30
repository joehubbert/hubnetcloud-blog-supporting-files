CREATE PROCEDURE [dbo].[spGetOrderLineItemStatus]
	@orderLineItemStatusId UNIQUEIDENTIFIER
AS

SELECT
[Order Line Item Status Id],
[Order Line Item Status],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwOrderLineItemStatus]
WHERE [Order Line Item Status Id] = @orderLineItemStatusId