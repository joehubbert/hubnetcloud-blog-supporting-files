CREATE VIEW [dbo].[vwMarketingCampaignStatusHistory]
AS

SELECT
MCSH.[MarketingCampaignStatusHistoryId] AS [Marketing Campaign Status History Id],
MCA.[MarketingCampaignId] AS [Marketing Campaign Id],
MCS.[MarketingCampaignStatusId] AS [Marketing Campaign Status Id],
MCS.[MarketingCampaignStatus] AS [Marketing Campaign Status],
MCSH.[CreatedTimestamp] AS [Created Timestamp],
MCSH.[CreatedBy] AS [Created By],
MCSH.[ModifiedTimestamp] AS [Modified Timestamp],
MCSH.[ModifiedBy] AS [Modified By]
FROM [dbo].[MarketingCampaignStatusHistory] MCSH
INNER JOIN [dbo].[MarketingCampaign] MCA ON MCSH.[MarketingCampaignId] = MCA.[MarketingCampaignId]
INNER JOIN [dbo].[MarketingCampaignStatus] MCS ON MCSH.[MarketingCampaignStatusId] = MCS.[MarketingCampaignStatusId]