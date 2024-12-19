CREATE PROCEDURE [dbo].[spGetCustomerTier]
	@customerTierId UNIQUEIDENTIFIER
AS

SELECT
[Customer Tier Id],
[Customer Tier Code],
[Customer Tier Description]
FROM [dbo].[vwCustomerTier]
WHERE [Customer Tier Id] = @customerTierId