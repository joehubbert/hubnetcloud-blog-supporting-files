CREATE VIEW [dbo].[vwPromotionManufacturer]
AS

SELECT
PM.[PromotionManufacturerId] AS [Promotion Manufacturer Id],
P.[PromotionId] AS [Promotion Id],
P.[PromotionName] AS [Promotion Name],
M.[ManufacturerId] AS [Manufacturer Id],
M.[ManufacturerName] AS [Manufacturer Name],
PM.[CreatedTimestamp] AS [Created Timestmap],
PM.[CreatedBy] AS [Created By],
PM.[ModifiedTimestamp] AS [Modified Timestamp],
PM.[ModifiedBy] AS [Modified By]
FROM [dbo].[PromotionManufacturer] PM
INNER JOIN [dbo].[Manufacturer] M ON PM.[ManufacturerId] = M.[ManufacturerId]
INNER JOIN [dbo].[Promotion] P ON PM.[PromotionId] = P.[PromotionId]