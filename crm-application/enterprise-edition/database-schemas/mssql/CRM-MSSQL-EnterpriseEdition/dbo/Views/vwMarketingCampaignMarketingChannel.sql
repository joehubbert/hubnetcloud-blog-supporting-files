CREATE VIEW [dbo].[vwMarketingCampaignMarketingChannel]
AS

SELECT
MCAMCH.[MarketingCampaignMarketingChannelId] AS [Marketing Campaign Marketing Channel Id],
MCA.[MarketingCampaignId] AS [Marketing Campaign Id],
MCA.[MarketingCampaignName] AS [Marketing Campaign Name],
MCH.[MarketingChannelId] AS [Marketing Channel Id],
MCH.[MarketingChannel] AS [Marketing Channel],
MCAMCH.[CreatedTimestamp] AS [Created Timestamp],
MCAMCH.[CreatedBy] AS [Created By],
MCAMCH.[ModifiedTimestamp] AS [Modified Timestamp],
MCAMCH.[ModifiedBy] AS [Modified By]
FROM [dbo].[MarketingCampaignMarketingChannel] MCAMCH
INNER JOIN [dbo].[MarketingChannel] MCH ON MCAMCH.[MarketingChannelId] = MCH.[MarketingChannelId]
INNER JOIN [dbo].[MarketingCampaign] MCA ON MCAMCH.[MarketingCampaignId] = MCA.[MarketingCampaignId]