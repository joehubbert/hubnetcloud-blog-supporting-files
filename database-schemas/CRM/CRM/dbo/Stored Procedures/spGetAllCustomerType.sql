CREATE PROCEDURE [dbo].[spGetAllCustomerType]
AS

SELECT
[CustomerTypeId] AS [Customer Type Id],
[CustomerType] AS [Customer Type]
FROM [dbo].[CustomerType]