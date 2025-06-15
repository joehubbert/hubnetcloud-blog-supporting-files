CREATE VIEW [dbo].[vwOrderLineItem]
AS

SELECT
OLI.[OrderId] AS [Order Id],
OLI.[OrderLineItemId] AS [Order Line Item Id],
OLIS.[OrderLineItemStatusId] AS [Order Line Item Status Id],
OLIS.[OrderLineItemStatus] AS [Order Line Item Status],
P.[ProductId] AS [Product Id],
P.[ProductName] AS [Product Name],
OLI.[UnitPrice] AS [Product Unit Price],
OLI.[FinalPrice] AS [Order Line Item Unit Price],
OLI.[TaxAmount] AS [Order Line Item Tax Amount],
TP.[TaxProfileId] AS [Tax Profile Id],
TP.[TaxProfile] AS [Tax Profile],
TP.[TaxRate] AS [Tax Rate],
OLI.[Quantity] AS [Order Line Item Quantity],
OLI.[PercentageDiscount] AS [Order Line Item Percentage Discount],
PROMO.[PromotionId] AS [Promotion Id],
PROMO.[PromotionCode] AS [Promotion Code],
PT.[PromotionTypeId] AS [Promotion Type Id],
PT.[PromotionType] AS [Promotion Type],
OLI.[LineItemTotal] AS [Total Line Item Price],
OLI.[CreatedTimestampUTC] AS [Created Timestamp UTC],
OLI.[CreatedBy] AS [Created By],
OLI.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
OLI.[ModifiedBy] AS [Modified By]
FROM [dbo].[OrderLineItem] OLI
INNER JOIN [dbo].[OrderLineItemStatusHistory] OLISH ON OLI.[OrderLineItemId] = OLISH.[OrderLineItemId]
INNER JOIN [dbo].[OrderLineItemStatus] OLIS ON OLISH.[OrderLineItemStatusId] = OLIS.[OrderLineItemStatusId]
INNER JOIN [dbo].[Product] P ON OLI.[ProductId] = P.[ProductId]
LEFT JOIN [dbo].[Promotion] PROMO ON OLI.[PromotionId] = PROMO.[PromotionId]
INNER JOIN [dbo].[PromotionType] PT ON PROMO.[PromotionTypeId] = PT.[PromotionTypeId]
INNER JOIN [dbo].[TaxProfile] TP ON OLI.[TaxProfileId] = TP.[TaxProfileId]
GROUP BY
OLI.[OrderId],
OLI.[OrderLineItemId],
OLIS.[OrderLineItemStatusId],
OLIS.[OrderLineItemStatus],
P.[ProductId],
P.[ProductName],
OLI.[UnitPrice],
OLI.[FinalPrice],
OLI.[TaxAmount],
TP.[TaxProfileId],
TP.[TaxProfile],
TP.[TaxRate],
OLI.[Quantity],
OLI.[PercentageDiscount],
PROMO.[PromotionId],
PROMO.[PromotionCode],
PT.[PromotionTypeId],
PT.[PromotionType],
OLI.[LineItemTotal],
OLI.[CreatedTimestampUTC],
OLI.[CreatedBy],
OLI.[ModifiedTimestampUTC],
OLI.[ModifiedBy]