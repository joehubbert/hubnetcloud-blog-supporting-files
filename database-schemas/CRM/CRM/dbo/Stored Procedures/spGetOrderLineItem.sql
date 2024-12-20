CREATE PROCEDURE [dbo].[spGetOrderLineItem]
	@orderLineItemId UNIQUEIDENTIFIER
AS

SELECT
[Order Id],
[Order Line Item Id],
[Order Line Item Status Id],
[Order Line Item Status],
[Product Id],
[Product Name],
[Product Unit Price],
[Product Quantity],
[Product Percentage Discount],
[Total Line Item Price],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwOrderLineItem]
WHERE [Order Line Item Id] = @orderLineItemId