CREATE VIEW [dbo].[vwOrderProduct]
AS

SELECT
OLI.[ProductId] AS [Product Id],
OLI.[OrderId] AS [Order Id],
SUM(OLI.[Quantity]) AS [Product Quantity],
SUM(VOV.[TotalOrderValue]) AS [Product Order Value]
FROM [dbo].[OrderLineItem] OLI
INNER JOIN [dbo].[vwOrderValue] VOV ON OLI.[OrderId] = VOV.[OrderId]
GROUP BY OLI.[OrderId], OLI.[ProductId]