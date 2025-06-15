CREATE VIEW [dbo].[vwSalesSubRegion]
AS

SELECT
SSR.[SalesSubRegionId] AS [Sales Sub Region Id],
SR.[SalesRegionId] AS [Sales Region Id],
SR.[SalesRegion] AS [Sales Region],
SSR.[SalesSubRegion] AS [Sales Sub Region],
SSR.ActiveStatus AS [Active Status],
SSR.[CreatedTimestampUTC] AS [Created Timestamp UTC],
SSR.[CreatedBy] AS [Created By],
SSR.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
SSR.[ModifiedBy] AS [Modified By]
FROM [dbo].[SalesSubRegion] SSR
INNER JOIN [dbo].[SalesRegion] SR ON SSR.[SalesRegionId] = SR.[SalesRegionId]