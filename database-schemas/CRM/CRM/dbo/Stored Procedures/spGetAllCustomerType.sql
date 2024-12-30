CREATE PROCEDURE [dbo].[spGetAllCustomerType]
AS

SELECT
[Customer Type Id],
[Customer Type],
[Active Status]
FROM [dbo].[vwCustomerType]