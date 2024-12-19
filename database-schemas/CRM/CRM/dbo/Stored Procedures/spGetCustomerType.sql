CREATE PROCEDURE [dbo].[spGetCustomerType]
	@customerTypeId UNIQUEIDENTIFIER
AS

SELECT
[CustomerTypeId] AS [Customer Type Id],
[CustomerType] AS [Customer Type]
FROM [dbo].[CustomerType]
WHERE [CustomerTypeId] = @customerTypeId