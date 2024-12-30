CREATE PROCEDURE [dbo].[spUpdateSalesRegionMember]
	@activeStatus BIT,
	@salesRegionId UNIQUEIDENTIFIER,
	@salesRegionMember NVARCHAR(50),
	@sakesRegionMemberId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[SalesRegionMember]
SET 
	[ActiveStatus] = @activeStatus,
	[SalesRegionId] = @salesRegionId,
	[SalesRegionMember] = @salesRegionMember
WHERE [SalesRegionMemberId] = @sakesRegionMemberId