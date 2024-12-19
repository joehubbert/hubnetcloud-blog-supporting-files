CREATE VIEW [dbo].[vwProductSalesRegion]
AS

SELECT
P.[ProductId] AS [Product Id],
P.[ProductName] AS [Product Name],
SR.[SalesRegionId] AS [Sales Region Id],
SR.[SalesRegion] AS [Sales Region]
FROM [dbo].[ProductSalesRegion] PSR
INNER JOIN [dbo].[Product] P ON PSR.[ProductId] = P.[ProductId]
INNER JOIN [dbo].[SalesRegion] SR ON PSR.[SalesRegionId] = SR.[SalesRegionId]