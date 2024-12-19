CREATE PROCEDURE [dbo].[spGetAllCustomerTier]
AS

SELECT
[CustomerTierId] AS [Customer Tier Id],
[CustomerTierCode] AS [Customer Tier Code],
[CustomerTierDescription] AS [Customer Tier Description]
FROM [dbo].[CustomerTier]