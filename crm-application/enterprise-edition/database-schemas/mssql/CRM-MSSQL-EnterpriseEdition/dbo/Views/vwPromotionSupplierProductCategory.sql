CREATE VIEW [dbo].[vwPromotionSupplierProductCategory]
AS

SELECT
PSPC.[PromotionSupplierProductCategoryId] AS [Promotion Supplier Product Category Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
S.[SupplierId] AS [Supplier Id],
S.[SupplierName] AS [Supplier Name],
PC.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
PSPC.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PSPC.[CreatedBy] AS [Created By],
PSPC.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PSPC.[ModifiedBy] AS [Modified By],
PSPC.[RowVersion] AS [Row Version]
FROM [dbo].[PromotionSupplierProductCategory] PSPC
INNER JOIN [dbo].[Supplier] S ON PSPC.[SupplierId] = S.[SupplierId]
INNER JOIN [dbo].[ProductCategory] PC ON PSPC.[ProductCategoryId] = PC.[ProductCategoryId]
INNER JOIN [dbo].[Promotion] P ON PSPC.[PromotionId] = P.[PromotionId]