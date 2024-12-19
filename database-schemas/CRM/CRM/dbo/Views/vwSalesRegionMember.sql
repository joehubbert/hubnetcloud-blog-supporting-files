CREATE VIEW [dbo].[vwSalesRegionMember]
AS

SELECT
SRM.[SalesRegionMemberId] AS [Sales Region Member Id],
SR.[SalesRegion] AS [Sales Region],
SRM.[SalesRegionMember] AS [Sales Region Member]
FROM [dbo].[SalesRegionMember] SRM
INNER JOIN [dbo].[SalesRegion] SR ON SRM.[SalesRegionId] = SR.[SalesRegionId]