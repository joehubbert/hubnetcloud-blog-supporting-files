CREATE VIEW [dbo].[vwOrderStatus]
AS

SELECT
[OrderStatusId]	AS [Order Status Id],
[OrderStatus] AS [Order Status]
FROM [dbo].[OrderStatus]