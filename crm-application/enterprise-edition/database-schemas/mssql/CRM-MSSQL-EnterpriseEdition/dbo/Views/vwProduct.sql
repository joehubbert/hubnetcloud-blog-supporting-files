CREATE VIEW [dbo].[vwProduct]
AS

SELECT
P.[ProductId] AS [Product Id],
PSC.[ProductSubCategoryId] AS [Product Sub Category Id],
PSC.[ProductSubCategory] AS [Product Sub Category],
PC.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
P.[ProductName] AS [Product Name],
M.[ManufacturerId] AS [Manufacturer Id],
M.[ManufacturerName] AS [Manufacturer Name],
P.[ProductImage] AS [Product Image],
P.[WholesaleUnitQuantityPerCarton] AS [Wholesale Unit Quantity Per Carton],
P.[WholesaleCartonStockQuantityHeld] AS [Wholesale Carton Stock Quantity Held],
P.[WholesaleReorderFlag] AS [Wholesale Reorder Flag],
P.[UnitPrice] AS [Unit Selling Price],
P.[UnitMinimumOrderQuantity] AS [Unit Minimum Order Quantity],
P.[UnitMinimumStockQuantity] AS [Unit Minimum Stock Quantity],
P.[UnitStockQuantityHeld] AS [Unit Stock Quantity Held],
P.[ActiveStatus] AS [Active Status],
P.[CreatedTimestamp] AS [Created Timestamp],
P.[CreatedBy] AS [Created By],
P.[ModifiedTimestamp] AS [Modified Timestamp],
P.[ModifiedBy] AS [Modified By]
FROM [dbo].[Product] P
INNER JOIN [dbo].[Manufacturer] M ON P.[ManufacturerId] = M.[ManufacturerId]
INNER JOIN [dbo].[ProductSubCategory] PSC ON P.[ProductSubCategoryId] = PSC.[ProductSubCategoryId]
INNER JOIN [dbo].[ProductCategory] PC ON PSC.[ProductCategoryId] = PC.[ProductCategoryId]