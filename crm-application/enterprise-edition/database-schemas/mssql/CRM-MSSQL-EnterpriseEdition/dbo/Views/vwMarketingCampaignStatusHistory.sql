CREATE VIEW [dbo].[vwMarketingCampaignStatusHistory]
AS

SELECT
MCSH.[MarketingCampaignStatusHistoryId] AS [Marketing Campaign Status History Id],
MCA.[MarketingCampaignId] AS [Marketing Campaign Id],
MCS.[MarketingCampaignStatusId] AS [Marketing Campaign Status Id],
MCS.[MarketingCampaignStatus] AS [Marketing Campaign Status],
MCSH.[CreatedTimestampUTC] AS [Created Timestamp UTC],
MCSH.[CreatedBy] AS [Created By],
MCSH.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
MCSH.[ModifiedBy] AS [Modified By],
MCSH.[RowVersion] AS [Row Version]
FROM [dbo].[MarketingCampaignStatusHistory] MCSH
INNER JOIN [dbo].[MarketingCampaign] MCA ON MCSH.[MarketingCampaignId] = MCA.[MarketingCampaignId]
INNER JOIN [dbo].[MarketingCampaignStatus] MCS ON MCSH.[MarketingCampaignStatusId] = MCS.[MarketingCampaignStatusId]