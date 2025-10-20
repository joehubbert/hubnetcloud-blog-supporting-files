CREATE VIEW [dbo].[vwMarketingCampaignType]
AS

SELECT 
[MarketingCampaignTypeId] AS [Marketing Campaign Type Id],
[MarketingCampaignType] AS [Marketing Campaign Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[MarketingCampaignType]