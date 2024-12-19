CREATE PROCEDURE [dbo].[spGetOrderStatus]
	@orderStatusId UNIQUEIDENTIFIER
AS

SELECT
[OrderStatusId]	AS [Order Status Id],
[OrderStatus] AS [Order Status]
FROM [dbo].[OrderStatus]
WHERE [OrderStatusId] = @orderStatusId