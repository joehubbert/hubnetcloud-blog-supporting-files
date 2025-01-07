CREATE PROCEDURE [dbo].[spGetSalesSubRegion]
	@salesSubRegionId UNIQUEIDENTIFIER
AS

SELECT
[Sales Sub Region Id],
[Sales Region Id],
[Sales Region],
[Sales Sub Region],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwSalesSubRegion]
WHERE [Sales Sub Region Id] = @salesSubRegionId