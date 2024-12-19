CREATE PROCEDURE [dbo].[spGetProduct]
	@productId UNIQUEIDENTIFIER
AS

SELECT
P.[ProductId] AS [Product Id],
PC.[ProductCategory] AS [Product Category],
S.[CompanyName] AS [Supplier Name],
P.[ProductName] AS [Product Name],
P.[WholesalePricePerUnit] AS [Wholesale Price Per Unit],
P.[WholesaleUnitQuantityPerCarton] AS [Wholesale Unit Quantity Per Carton],
P.[WholesaleReorderFlag] AS [Wholesale Reorder Flag],
P.[UnitPrice] AS [Unit Selling Price],
P.[UnitStockQuantityHeld] AS [Unit Stock Quantity Held],
P.[ActiveStatus] AS [Active Status]
FROM [dbo].[Product] P
INNER JOIN [dbo].[ProductCategory] PC ON P.[ProductCategoryId] = PC.[ProductCategoryId]
INNER JOIN [dbo].[Supplier] S ON P.[SupplierId] = S.[SupplierId]
WHERE P.[ProductId] = @productId