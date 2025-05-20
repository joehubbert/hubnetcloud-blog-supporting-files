CREATE PROCEDURE [dbo].[spGetSalesRegion]
	@salesRegionId UNIQUEIDENTIFIER
AS

SELECT
[Sales Region Id],
[Sales Region],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwSalesRegion]
WHERE [Sales Region Id] = @salesRegionId