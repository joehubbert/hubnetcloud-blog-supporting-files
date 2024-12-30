CREATE PROCEDURE [dbo].[spUpdateCustomerTier]
	@activeStatus BIT,
	@customerTier NVARCHAR(50),
	@customerTierCode NCHAR(1),
	@customerTierId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[CustomerTier]
SET 
	[ActiveStatus] = @activeStatus,
	[CustomerTierCode] = @customerTierCode,
	[CustomerTierDescription] = @customerTier
WHERE [CustomerTierId] = @customerTierId