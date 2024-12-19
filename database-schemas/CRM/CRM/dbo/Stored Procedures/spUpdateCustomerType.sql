CREATE PROCEDURE [dbo].[spUpdateCustomerType]
	@customerType NVARCHAR(50),
	@customerTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[CustomerType]
SET 
	[CustomerType] = @customerType
WHERE [CustomerTypeId] = @customerTypeId