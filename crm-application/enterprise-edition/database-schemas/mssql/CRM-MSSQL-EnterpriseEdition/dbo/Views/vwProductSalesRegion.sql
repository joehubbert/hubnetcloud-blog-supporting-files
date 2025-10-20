CREATE VIEW [dbo].[vwProductSalesRegion]
AS

SELECT
P.[ProductId] AS [Product Id],
P.[ProductName] AS [Product Name],
SR.[SalesRegionId] AS [Sales Region Id],
SR.[SalesRegion] AS [Sales Region],
PSSR.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PSSR.[CreatedBy] AS [Created By],
PSSR.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PSSR.[ModifiedBy] AS [Modified By],
PSSR.[RowVersion] AS [Row Version]
FROM [dbo].[ProductSalesSubRegion] PSSR
INNER JOIN [dbo].[Product] P ON PSSR.[ProductId] = P.[ProductId]
INNER JOIN [dbo].[SalesSubRegion] SSR ON PSSR.[SalesSubRegionId] = SSR.[SalesSubRegionId]
INNER JOIN [dbo].[SalesRegion] SR ON SSR.[SalesRegionId] = SR.[SalesRegionId]