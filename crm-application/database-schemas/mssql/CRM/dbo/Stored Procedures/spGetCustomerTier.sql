CREATE PROCEDURE [dbo].[spGetCustomerTier]
	@customerTierId UNIQUEIDENTIFIER
AS

SELECT
[Customer Tier Id],
[Customer Tier Code],
[Customer Tier Description],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwCustomerTier]
WHERE [Customer Tier Id] = @customerTierId