CREATE PROCEDURE [dbo].[DeleteCustomerTier]
	@customerTierId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[CustomerTier]
WHERE [CustomerTierId] = @customerTierId