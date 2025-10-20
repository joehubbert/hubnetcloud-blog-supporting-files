CREATE VIEW [dbo].[vwPromotionSupplier]
AS

SELECT
PS.[PromotionSupplierId] AS [Promotion Supplier Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
S.[SupplierId] AS [Supplier Id],
S.[SupplierName] AS [Supplier Name],
PS.[CreatedTimestampUTC] AS [Created Timestmap],
PS.[CreatedBy] AS [Created By],
PS.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PS.[ModifiedBy] AS [Modified By],
PS.[RowVersion] AS [Row Version]
FROM [dbo].[PromotionSupplier] PS
INNER JOIN [dbo].[Supplier] S ON PS.[SupplierId] = S.[SupplierId]
INNER JOIN [dbo].[Promotion] P ON PS.[PromotionId] = P.[PromotionId]