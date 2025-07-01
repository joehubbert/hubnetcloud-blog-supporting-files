CREATE VIEW [dbo].[vwOrderValue]
AS

SELECT 
O.[OrderId],
O.[CustomerId],
OT.[OrderTypeId],
OT.[OrderType],
SUM(OLI.[LineItemTotal]) AS [TotalOrderValue]
FROM [dbo].[Order] O
INNER JOIN [dbo].[OrderLineItem] OLI ON O.[OrderId] = OLI.[OrderId]
INNER JOIN [dbo].[OrderType] OT ON O.[OrderTypeId] = OT.[OrderTypeId]
GROUP BY 
O.[OrderId],
O.[CustomerId],
OT.[OrderTypeId],
OT.[OrderType]