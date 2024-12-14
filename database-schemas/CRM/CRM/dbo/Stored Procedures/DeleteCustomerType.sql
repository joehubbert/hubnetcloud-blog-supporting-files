CREATE PROCEDURE [dbo].[DeleteCustomerType]
	@customerTypeId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[CustomerType]
WHERE [CustomerTypeId] = @customerTypeId