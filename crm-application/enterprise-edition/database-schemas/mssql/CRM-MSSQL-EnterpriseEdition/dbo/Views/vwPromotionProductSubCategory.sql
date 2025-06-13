CREATE VIEW [dbo].[vwPromotionProductSubCategory]
AS

SELECT
PPSC.[PromotionProductSubCategoryId] AS [Promotion Product Sub Category Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
PSC.[ProductSubCategoryId] AS [Product Sub Category Id],
PSC.[ProductSubCategory] AS [Product Sub Category],
PPSC.[CreatedTimestamp] AS [Created Timestamp],
PPSC.[CreatedBy] AS [Created By],
PPSC.[ModifiedTimestamp] AS [Modified Timestamp],
PPSC.[ModifiedBy] AS [Modified By]
FROM [dbo].[PromotionProductSubCategory] PPSC
INNER JOIN [dbo].[ProductSubCategory] PSC ON PPSC.[ProductSubCategoryId] = PSC.[ProductSubCategoryId]
INNER JOIN [dbo].[Promotion] P ON PPSC.[PromotionId] = P.[PromotionId]