CREATE VIEW [dbo].[vwSalesRegion]
AS

SELECT
[SalesRegionId]	AS [Sales Region Id],
[SalesRegion] AS [Sales Region],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[SalesRegion]