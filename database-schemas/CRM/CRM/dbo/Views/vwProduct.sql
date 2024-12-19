CREATE VIEW [dbo].[vwProduct]
AS

SELECT
P.[ProductId] AS [Product Id],
P.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
S.[CompanyName] AS [Supplier Name],
P.[ProductName] AS [Product Name],
P.[WholesalePricePerUnit] AS [Wholesale Price Per Unit],
P.[WholesaleUnitQuantityPerCarton] AS [Wholesale Unit Quantity Per Carton],
P.[WholesaleReorderFlag] AS [Wholesale Reorder Flag],
P.[UnitPrice] AS [Unit Selling Price],
P.[UnitStockQuantityHeld] AS [Unit Stock Quantity Held],
P.[ActiveStatus] AS [Active Status],
P.[CreatedTimestamp] AS [Created Timestamp],
P.[CreatedBy] AS [Created By],
P.[ModifiedTimestamp] AS [Modified Timestamp],
P.[ModifiedBy] AS [Modified By]
FROM [dbo].[Product] P
INNER JOIN [dbo].[ProductCategory] PC ON P.[ProductCategoryId] = PC.[ProductCategoryId]
INNER JOIN [dbo].[Supplier] S ON P.[SupplierId] = S.[SupplierId]