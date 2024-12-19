CREATE PROCEDURE [dbo].[spGetSalesRegionMember]
	@salesRegionMemberId UNIQUEIDENTIFIER
AS

SELECT
[Sales Region Member Id],
[Sales Region],
[Sales Region Member],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwSalesRegionMember]
WHERE [Sales Region Member Id] = @salesRegionMemberId