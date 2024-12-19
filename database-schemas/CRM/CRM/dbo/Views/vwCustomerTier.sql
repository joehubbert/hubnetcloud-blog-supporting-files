CREATE VIEW [dbo].[vwCustomerTier]
AS

SELECT
[CustomerTierId] AS [Customer Tier Id],
[CustomerTierCode] AS [Customer Tier Code],
[CustomerTierDescription] AS [Customer Tier Description],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerTier]