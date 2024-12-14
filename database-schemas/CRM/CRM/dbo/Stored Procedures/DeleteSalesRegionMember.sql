CREATE PROCEDURE [dbo].[DeleteSalesRegionMember]
	@salesRegionMemberId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[SalesRegionMember]
WHERE [SalesRegionMemberId] = @salesRegionMemberId