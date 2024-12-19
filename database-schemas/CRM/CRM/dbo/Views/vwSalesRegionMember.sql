CREATE VIEW [dbo].[vwSalesRegionMember]
AS

SELECT
SRM.[SalesRegionMemberId] AS [Sales Region Member Id],
SR.[SalesRegion] AS [Sales Region],
SRM.[SalesRegionMember] AS [Sales Region Member],
SRM.[CreatedTimestamp] AS [Created Timestamp],
SRM.[CreatedBy] AS [Created By],
SRM.[ModifiedTimestamp] AS [Modified Timestamp],
SRM.[ModifiedBy] AS [Modified By]
FROM [dbo].[SalesRegionMember] SRM
INNER JOIN [dbo].[SalesRegion] SR ON SRM.[SalesRegionId] = SR.[SalesRegionId]