CREATE VIEW [dbo].[vwOrderProduct]
AS

SELECT
OLI.[ProductId] AS [Product Id],
O.[OrderId] AS [Order Id],
OT.[OrderTypeId] AS [Order Type Id],
OT.[OrderType] AS [Order Type],
SUM(OLI.[Quantity]) AS [Product Quantity],
SUM(VOV.[TotalOrderValue]) AS [Product Order Value]
FROM [dbo].[OrderLineItem] OLI
INNER JOIN [dbo].[Order] O ON OLI.[OrderId] = O.[OrderId]
INNER JOIN [dbo].[OrderType] OT ON O.[OrderTypeId] = OT.[OrderTypeId]
INNER JOIN [dbo].[vwOrderValue] VOV ON OLI.[OrderId] = VOV.[OrderId]
GROUP BY
O.[OrderId],
OLI.[ProductId],
OT.[OrderTypeId],
OT.[OrderType]