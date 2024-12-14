CREATE PROCEDURE [dbo].[DeleteCustomer]
	@customerId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[Customer]
WHERE [CustomerId] = @customerId