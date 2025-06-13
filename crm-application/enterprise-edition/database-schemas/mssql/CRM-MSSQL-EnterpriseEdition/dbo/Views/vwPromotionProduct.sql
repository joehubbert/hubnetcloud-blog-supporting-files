CREATE VIEW [dbo].[vwPromotionProduct]
AS

SELECT
PP.[PromotionProductId] AS [Promotion Product Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
PROD.[ProductId] AS [Product Id],
PROD.[ProductName] AS [Product Name],
PP.[CreatedTimestamp] AS [Created Timestmap],
PP.[CreatedBy] AS [Created By],
PP.[ModifiedTimestamp] AS [Modified Timestamp],
PP.[ModifiedBy] AS [Modified By]
FROM [dbo].[PromotionProduct] PP
INNER JOIN [dbo].[Product] PROD ON PP.[ProductId] = PROD.[ProductId]
INNER JOIN [dbo].[Promotion] P ON PP.[PromotionId] = P.[PromotionId]