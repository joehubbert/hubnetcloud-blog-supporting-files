CREATE PROCEDURE [dbo].[spUpdateSalesRegionMember]
	@salesRegionId UNIQUEIDENTIFIER,
	@salesRegionMember NVARCHAR(50),
	@sakesRegionMemberId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[SalesRegionMember]
SET 
	[SalesRegionId] = @salesRegionId,
	[SalesRegionMember] = @salesRegionMember
WHERE [SalesRegionMemberId] = @sakesRegionMemberId