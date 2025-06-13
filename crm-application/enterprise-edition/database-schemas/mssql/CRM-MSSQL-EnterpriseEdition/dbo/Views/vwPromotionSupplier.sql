CREATE VIEW [dbo].[vwPromotionSupplier]
AS

SELECT
PS.[PromotionSupplierId] AS [Promotion Supplier Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
S.[SupplierId] AS [Supplier Id],
S.[SupplierName] AS [Supplier Name],
PS.[CreatedTimestamp] AS [Created Timestmap],
PS.[CreatedBy] AS [Created By],
PS.[ModifiedTimestamp] AS [Modified Timestamp],
PS.[ModifiedBy] AS [Modified By]
FROM [dbo].[PromotionSupplier] PS
INNER JOIN [dbo].[Supplier] S ON PS.[SupplierId] = S.[SupplierId]
INNER JOIN [dbo].[Promotion] P ON PS.[PromotionId] = P.[PromotionId]