CREATE VIEW [dbo].[vwPromotionProductCategory]
AS

SELECT
PPC.[PromotionProductCategoryId] AS [Promotion Product Category Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
PC.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
PPC.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PPC.[CreatedBy] AS [Created By],
PPC.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PPC.[ModifiedBy] AS [Modified By],
PPC.[RowVersion] AS [Row Version]
FROM [dbo].[PromotionProductCategory] PPC
INNER JOIN [dbo].[ProductCategory] PC ON PPC.[ProductCategoryId] = PC.[ProductCategoryId]
INNER JOIN [dbo].[Promotion] P ON PPC.[PromotionId] = P.[PromotionId]