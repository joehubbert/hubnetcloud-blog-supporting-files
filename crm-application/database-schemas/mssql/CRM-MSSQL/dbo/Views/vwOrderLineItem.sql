CREATE VIEW [dbo].[vwOrderLineItem]
AS

SELECT
OLI.[OrderId] AS [Order Id],
OLI.[OrderLineItemId] AS [Order Line Item Id],
OLI.[OrderLineItemStatusId] AS [Order Line Item Status Id],
OLIS.[OrderLineItemStatus] AS [Order Line Item Status],
OLI.[ProductId] AS [Product Id],
P.[ProductName] AS [Product Name],
P.[UnitPrice] AS [Product Unit Price],
OLI.[Quantity] AS [Product Quantity],
OLI.[PercentageDiscount] AS [Product Percentage Discount],
SUM(OLI.[Quantity] * P.[UnitPrice] * (1 - OLI.[PercentageDiscount])) AS [Total Line Item Price],
OLI.[CreatedTimestamp] AS [Created Timestamp],
OLI.[CreatedBy] AS [Created By],
OLI.[ModifiedTimestamp] AS [Modified Timestamp],
OLI.[ModifiedBy] AS [Modified By]
FROM [dbo].[OrderLineItem] OLI
INNER JOIN [dbo].[Product] P ON OLI.[ProductId] = P.[ProductId]
INNER JOIN [dbo].[OrderLineItemStatus] OLIS ON OLI.[OrderLineItemStatusId] = OLIS.[OrderLineItemStatusId]
GROUP BY
OLI.[OrderId],
OLI.[OrderLineItemId],
OLI.[OrderLineItemStatusId],
OLIS.[OrderLineItemStatus],
OLI.[ProductId],
P.[ProductName],
P.[UnitPrice],
OLI.[Quantity],
OLI.[PercentageDiscount],
OLI.[CreatedTimestamp],
OLI.[CreatedBy],
OLI.[ModifiedTimestamp],
OLI.[ModifiedBy]