CREATE PROCEDURE [dbo].[spGetCustomerTier]
	@customerTierId UNIQUEIDENTIFIER
AS

SELECT
[CustomerTierId] AS [Customer Tier Id],
[CustomerTierCode] AS [Customer Tier Code],
[CustomerTierDescription] AS [Customer Tier Description]
FROM [dbo].[CustomerTier]
WHERE [CustomerTierId] = @customerTierId