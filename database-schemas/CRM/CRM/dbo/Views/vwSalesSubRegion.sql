CREATE VIEW [dbo].[vwSalesSubRegion]
AS

SELECT
SSR.[SalesSubRegionId] AS [Sales Sub Region Id],
SR.[SalesRegion] AS [Sales Region],
SSR.[SalesSubRegion] AS [Sales Sub Region],
SSR.ActiveStatus AS [Sales Sub Region Active Status],
SSR.[CreatedTimestamp] AS [Created Timestamp],
SSR.[CreatedBy] AS [Created By],
SSR.[ModifiedTimestamp] AS [Modified Timestamp],
SSR.[ModifiedBy] AS [Modified By]
FROM [dbo].[SalesSubRegion] SSR
INNER JOIN [dbo].[SalesRegion] SR ON SSR.[SalesRegionId] = SR.[SalesRegionId]