CREATE VIEW [dbo].[vwPromotionSupplierProductSubCategory]
AS

SELECT
PSPSC.[PromotionSupplierProductSubCategoryId] AS [Promotion Supplier Product Sub Category Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
S.[SupplierId] AS [Supplier Id],
S.[SupplierName] AS [Supplier Name],
PSC.[ProductSubCategoryId] AS [Product Sub Category Id],
PSC.[ProductSubCategory] AS [Product Sub Category],
PSPSC.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PSPSC.[CreatedBy] AS [Created By],
PSPSC.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PSPSC.[ModifiedBy] AS [Modified By],
PSPSC.[RowVersion] AS [Row Version]
FROM [dbo].[PromotionSupplierProductSubCategory] PSPSC
INNER JOIN [dbo].[Supplier] S ON PSPSC.[SupplierId] = S.[SupplierId]
INNER JOIN [dbo].[ProductSubCategory] PSC ON PSPSC.[ProductSubCategoryId] = PSC.[ProductSubCategoryId]
INNER JOIN [dbo].[Promotion] P ON PSPSC.[PromotionId] = P.[PromotionId]