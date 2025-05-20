CREATE PROCEDURE [dbo].[spGetOrderDelivery]
	@orderId UNIQUEIDENTIFIER
AS

SELECT
[Order Delivery Id],
[Order Id],
[Delivery Method],
[Shipping Date],
[Delivery Date],
[Delivery Cost],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwOrderDelivery]
WHERE [Order Id] = @orderId