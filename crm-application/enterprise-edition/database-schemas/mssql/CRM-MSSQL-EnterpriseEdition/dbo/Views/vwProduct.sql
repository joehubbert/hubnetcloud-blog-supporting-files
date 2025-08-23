CREATE VIEW [dbo].[vwProduct]
AS

SELECT
P.[ProductId] AS [Product Id],
PSC.[ProductSubCategoryId] AS [Product Sub Category Id],
PSC.[ProductSubCategory] AS [Product Sub Category],
PC.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
PF.[ProductFamilyId] AS [Product Family Id],
PF.[ProductFamily] AS [Product Family],
P.[ProductName] AS [Product Name],
P.[ProductDescription] AS [Product Description],
M.[ManufacturerId] AS [Manufacturer Id],
M.[ManufacturerName] AS [Manufacturer Name],
P.[ManufacturerPartNumber] AS [Manufacturer Part Number],
P.[ProductImage] AS [Product Image],
C.[CountryId] AS [Product Country Of Origin Id],
C.[CountryEnglishName] AS [Product Country Of Origin],
P.[WholesaleCartonFlag] AS [Wholesale Carton Flag],
P.[WholesaleCartonBarcode] AS [Wholesale Carton Barcode],
P.[WholesaleUnitQuantityPerCarton] AS [Wholesale Unit Quantity Per Carton],
P.[WholesaleCartonStockQuantityHeld] AS [Wholesale Carton Stock Quantity Held],
P.[WholesaleCartonWeightKilogram] AS [Wholesale Carton Weight Kilogram],
P.[WholesaleCartonHeightCentimeter] AS [Wholesale Carton Height Centimeter],
P.[WholesaleCartonWidthCentimeter] AS [Wholesale Carton Width Centimeter],
P.[WholesaleCartonDepthCentimeter] AS [Wholesale Carton Depth Centimeter],
P.[WholesalePalletFlag] AS [Wholesale Pallet Flag],
P.[WholesaleCartonQuantityPerPallet] AS [Wholesale Carton Quantity Per Pallet],
P.[WholesalePalletHeightCentimeter] AS [Wholesale Pallet Height Centimeter],
P.[WholesalePalletWidthCentimeter] AS [Wholesale Pallet Width Centimeter],
P.[WholesalePalletDepthCentimeter] AS [Wholesale Pallet Depth Centimeter],
P.[WholesalePalletWeightKilogram] AS [Wholesale Pallet Weight Kilogram],
P.[WholesalePalletTotalHeightCentimeter] AS [Wholesale Pallet Total Height Centimeter],
P.[WholesalePalletTotalWidthCentimeter] AS [Wholesale Pallet Total Width Centimeter],
P.[WholesalePalletTotalDepthCentimeter] AS [Wholesale Pallet Total Depth Centimeter],
P.[WholesalePalletTotalWeightKilogram] AS [Wholesale Pallet Total Weight Kilogram],
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
INNER JOIN [dbo].[ProductFamily] PF ON P.[ProductFamilyId] = PF.[ProductFamilyId]
INNER JOIN [dbo].[ProductSubCategory] PSC ON P.[ProductSubCategoryId] = PSC.[ProductSubCategoryId]
INNER JOIN [dbo].[ProductCategory] PC ON PSC.[ProductCategoryId] = PC.[ProductCategoryId]