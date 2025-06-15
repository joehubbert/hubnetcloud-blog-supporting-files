CREATE VIEW [dbo].[vwProduct]
AS

SELECT
P.[ProductId] AS [Product Id],
PSC.[ProductSubCategoryId] AS [Product Sub Category Id],
PSC.[ProductSubCategory] AS [Product Sub Category],
PC.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
P.[ProductName] AS [Product Name],
P.[ProductDescription] AS [Product Description],
M.[ManufacturerId] AS [Manufacturer Id],
M.[ManufacturerName] AS [Manufacturer Name],
P.[ManufacturerPartNumber] AS [Manufacturer Part Number],
P.[ProductImage] AS [Product Image],
C.[CountryId] AS [Product Country Of Origin Id],
C.[CountryName] AS [Product Country Of Origin],
P.[WholesaleCartonBarcode] AS [Wholesale Carton Barcode],
P.[WholesaleUnitQuantityPerCarton] AS [Wholesale Unit Quantity Per Carton],
P.[WholesaleCartonStockQuantityHeld] AS [Wholesale Carton Stock Quantity Held],
P.[WholesaleCartonWeightKilogram] AS [Wholesale Carton Weight Kilogram],
P.[WholesaleCartonHeightCentimeter] AS [Wholesale Carton Height Centimeter],
P.[WholesaleCartonWidthCentimeter] AS [Wholesale Carton Width Centimeter],
P.[WholesaleCartonDepthCentimeter] AS [Wholesale Carton Depth Centimeter],
P.[WholesaleReorderFlag] AS [Wholesale Reorder Flag],
P.[UnitBarcode] AS [Unit Barcode],
P.[UnitPrice] AS [Unit Selling Price],
P.[UnitMinimumOrderQuantity] AS [Unit Minimum Order Quantity],
P.[UnitMinimumStockQuantity] AS [Unit Minimum Stock Quantity],
P.[UnitStockQuantityHeld] AS [Unit Stock Quantity Held],
P.[UnitWeightKilogram] AS [Unit Weight Kilogram],
P.[UnitHeightCentimeter] AS [Unit Height Centimeter],
P.[UnitWidthCentimeter] AS [Unit Width Centimeter],
P.[UnitDepthCentimeter] AS [Unit Depth Centimeter],
P.[ActiveStatus] AS [Active Status],
P.[CreatedTimestampUTC] AS [Created Timestamp UTC],
P.[CreatedBy] AS [Created By],
P.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
P.[ModifiedBy] AS [Modified By]
FROM [dbo].[Product] P
INNER JOIN [dbo].[Country] C ON P.[ProductCountryOfOriginId] = C.[CountryId]
INNER JOIN [dbo].[Manufacturer] M ON P.[ManufacturerId] = M.[ManufacturerId]
INNER JOIN [dbo].[ProductSubCategory] PSC ON P.[ProductSubCategoryId] = PSC.[ProductSubCategoryId]
INNER JOIN [dbo].[ProductCategory] PC ON PSC.[ProductCategoryId] = PC.[ProductCategoryId]