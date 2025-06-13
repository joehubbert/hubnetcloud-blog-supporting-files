CREATE VIEW [dbo].[vwMarketingCampaignStatus]
AS

SELECT
[MarketingCampaignStatusId]	AS [Marketing Campaign Status Id],
[MarketingCampaignStatus] AS [Marketing Campaign Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[MarketingCampaignStatus]