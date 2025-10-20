CREATE VIEW [dbo].[vwPromotionProductSubCategory]
AS

SELECT
PPSC.[PromotionProductSubCategoryId] AS [Promotion Product Sub Category Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
PSC.[ProductSubCategoryId] AS [Product Sub Category Id],
PSC.[ProductSubCategory] AS [Product Sub Category],
PPSC.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PPSC.[CreatedBy] AS [Created By],
PPSC.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PPSC.[ModifiedBy] AS [Modified By],
PPSC.[RowVersion] AS [Row Version]
FROM [dbo].[PromotionProductSubCategory] PPSC
INNER JOIN [dbo].[ProductSubCategory] PSC ON PPSC.[ProductSubCategoryId] = PSC.[ProductSubCategoryId]
INNER JOIN [dbo].[Promotion] P ON PPSC.[PromotionId] = P.[PromotionId]