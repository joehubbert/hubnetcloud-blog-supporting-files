CREATE VIEW [dbo].[vwOrderValue]
AS

SELECT 
O.[OrderId],
O.[CustomerId],
SUM(OLI.[LineItemTotal]) AS [TotalOrderValue]
FROM [dbo].[Order] O
INNER JOIN [dbo].[OrderLineItem] OLI ON O.[OrderId] = OLI.[OrderId]
GROUP BY O.[OrderId], O.[CustomerId]