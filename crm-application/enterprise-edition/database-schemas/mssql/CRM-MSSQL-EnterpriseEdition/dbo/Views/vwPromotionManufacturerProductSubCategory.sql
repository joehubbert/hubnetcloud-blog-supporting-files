CREATE VIEW [dbo].[vwPromotionManufacturerProductSubCategory]
AS

SELECT
PMPSC.[PromotionManufacturerProductSubCategoryId] AS [Promotion Manufacturer Product Sub Category Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
M.[ManufacturerId] AS [Manufacturer Id],
M.[ManufacturerName] AS [Manufacturer Name],
PSC.[ProductSubCategoryId] AS [Product Sub Category Id],
PSC.[ProductSubCategory] AS [Product Sub Category],
PMPSC.[CreatedTimestamp] AS [Created Timestamp],
PMPSC.[CreatedBy] AS [Created By],
PMPSC.[ModifiedTimestamp] AS [Modified Timestamp],
PMPSC.[ModifiedBy] AS [Modified By]
FROM [dbo].[PromotionManufacturerProductSubCategory] PMPSC
INNER JOIN [dbo].[Manufacturer] M ON PMPSC.[ManufacturerId] = M.[ManufacturerId]
INNER JOIN [dbo].[ProductSubCategory] PSC ON PMPSC.[ProductSubCategoryId] = PSC.[ProductSubCategoryId]
INNER JOIN [dbo].[Promotion] P ON PMPSC.[PromotionId] = P.[PromotionId]