CREATE PROCEDURE [dbo].[spGetAllOrderLineItemStatusHistory]
	@orderLineItemId UNIQUEIDENTIFIER
AS

SELECT
[Order Line Item Status History Id],
[Order Line Item Status Id],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwOrderLineItemStatusHistory]
WHERE [Order Line Item Id] = @orderLineItemId