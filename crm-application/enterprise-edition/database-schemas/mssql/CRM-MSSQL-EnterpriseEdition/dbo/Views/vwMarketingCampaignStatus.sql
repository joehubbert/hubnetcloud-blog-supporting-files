CREATE VIEW [dbo].[vwMarketingCampaignStatus]
AS

SELECT
[MarketingCampaignStatusId]	AS [Marketing Campaign Status Id],
[MarketingCampaignStatus] AS [Marketing Campaign Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[MarketingCampaignStatus]