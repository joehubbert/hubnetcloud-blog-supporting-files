CREATE VIEW [dbo].[vwPromotionManufacturerProductCategory]
AS

SELECT
PMPC.[PromotionManufacturerProductCategoryId] AS [Promotion Manufacturer Product Category Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
M.[ManufacturerId] AS [Manufacturer Id],
M.[ManufacturerName] AS [Manufacturer Name],
PC.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
PMPC.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PMPC.[CreatedBy] AS [Created By],
PMPC.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PMPC.[ModifiedBy] AS [Modified By]
FROM [dbo].[PromotionManufacturerProductCategory] PMPC
INNER JOIN [dbo].[Manufacturer] M ON PMPC.[ManufacturerId] = M.[ManufacturerId]
INNER JOIN [dbo].[ProductCategory] PC ON PMPC.[ProductCategoryId] = PC.[ProductCategoryId]
INNER JOIN [dbo].[Promotion] P ON PMPC.[PromotionId] = P.[PromotionId]