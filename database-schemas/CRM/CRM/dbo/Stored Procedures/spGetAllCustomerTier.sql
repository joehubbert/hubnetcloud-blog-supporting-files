CREATE PROCEDURE [dbo].[spGetAllCustomerTier]
AS

SELECT
[Customer Tier Id],
[Customer Tier Code],
[Customer Tier Description],
[Active Status]
FROM [dbo].[vwCustomerTier]