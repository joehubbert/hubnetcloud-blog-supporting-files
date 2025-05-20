CREATE PROCEDURE [dbo].[spUpdateCustomerType]
	@activeStatus BIT,
	@customerType NVARCHAR(50),
	@customerTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[CustomerType]
SET 
	[ActiveStatus] = @activeStatus,
	[CustomerType] = @customerType
WHERE [CustomerTypeId] = @customerTypeId