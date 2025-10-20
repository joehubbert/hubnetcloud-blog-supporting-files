CREATE VIEW [dbo].[vwPromotionProduct]
AS

SELECT
PP.[PromotionProductId] AS [Promotion Product Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
PROD.[ProductId] AS [Product Id],
PROD.[ProductName] AS [Product Name],
PP.[CreatedTimestampUTC] AS [Created Timestmap],
PP.[CreatedBy] AS [Created By],
PP.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PP.[ModifiedBy] AS [Modified By],
PP.[RowVersion] AS [Row Version]
FROM [dbo].[PromotionProduct] PP
INNER JOIN [dbo].[Product] PROD ON PP.[ProductId] = PROD.[ProductId]
INNER JOIN [dbo].[Promotion] P ON PP.[PromotionId] = P.[PromotionId]