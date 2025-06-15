CREATE VIEW [dbo].[vwProductSupplier]
AS

SELECT
PS.[ProductSupplierId] AS [Product Supplier Id],
P.[ProductId] AS [Product Id],
P.[ProductName] AS [Product Name],
PS.[WholesalePricePerUnit] AS [Wholesale Price Per Unit],
S.[SupplierId] AS [Supplier Id],
S.[SupplierName] AS [Supplier Name],
PS.[SupplierProductCode] AS [Supplier Product Code],
PS.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PS.[CreatedBy] AS [Created By],
PS.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PS.[ModifiedBy] AS [Modified By]
FROM [dbo].[ProductSupplier] PS
INNER JOIN [dbo].[Product] P ON PS.[ProductId] = P.[ProductId]
INNER JOIN [dbo].[Supplier] S ON PS.[SupplierId] = S.[SupplierId]