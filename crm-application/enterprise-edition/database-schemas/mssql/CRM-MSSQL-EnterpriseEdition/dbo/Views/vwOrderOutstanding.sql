CREATE VIEW [dbo].[vwOrderOutstanding]
AS

SELECT
O.[OrderId] AS [Order Id],
O.[CustomerId] AS [Customer Id],
O.[OrderDate] AS [Order Date],
OV.[TotalOrderValue] AS [Total Order Value]
FROM [dbo].[Order] O
INNER JOIN [dbo].[vwOrderValue] OV ON O.[OrderId] = OV.[OrderId]
INNER JOIN [dbo].[OrderStatusHistory] OSH ON O.[OrderId] = OSH.[OrderId]
INNER JOIN [dbo].[OrderStatus] OS ON OSH.[OrderStatusId] = OS.[OrderStatusId]
WHERE OS.[OrderStatus] != 'Complete'
AND OS.[OrderStatus] != 'Cancelled'