CREATE VIEW [dbo].[vwOrderValue]
AS
SELECT 
O.[OrderId],
O.[CustomerId],
SUM(OLI.[Quantity] * P.[UnitPrice] * (1 - OLI.[PercentageDiscount])) AS [TotalOrderValue]
FROM [dbo].[Order] O
INNER JOIN [dbo].[OrderLineItem] OLI ON O.OrderId = OLI.OrderId
INNER JOIN [dbo].[Product] P ON OLI.[ProductId] = P.[ProductId]
GROUP BY O.[OrderId], O.[CustomerId]