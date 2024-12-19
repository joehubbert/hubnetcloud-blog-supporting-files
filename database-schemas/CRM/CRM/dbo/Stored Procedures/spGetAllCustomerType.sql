CREATE PROCEDURE [dbo].[spGetAllCustomerType]
AS

SELECT
[Customer Type Id],
[Customer Type]
FROM [dbo].[vwCustomerType]