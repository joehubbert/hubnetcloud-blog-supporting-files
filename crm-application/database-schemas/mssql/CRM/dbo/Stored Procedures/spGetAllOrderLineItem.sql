CREATE PROCEDURE [dbo].[spGetAllOrderLineItem]
	@orderId UNIQUEIDENTIFIER
AS

SELECT
[Order Id],
[Order Line Item Id],
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
WHERE [Order Id] = @orderId