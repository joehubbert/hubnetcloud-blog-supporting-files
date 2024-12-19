CREATE PROCEDURE [dbo].[spUpdateCustomerTier]
	@customerTier NVARCHAR(50),
	@customerTierCode NCHAR(1),
	@customerTierId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[CustomerTier]
SET 
	[CustomerTierCode] = @customerTierCode,
	[CustomerTierDescription] = @customerTier
WHERE [CustomerTierId] = @customerTierId