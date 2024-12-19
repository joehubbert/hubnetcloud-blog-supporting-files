CREATE PROCEDURE [dbo].[spGetCustomerType]
	@customerTypeId UNIQUEIDENTIFIER
AS

SELECT
[Customer Type Id],
[Customer Type]
FROM [dbo].[vwCustomerType]
WHERE [Customer Type Id] = @customerTypeId