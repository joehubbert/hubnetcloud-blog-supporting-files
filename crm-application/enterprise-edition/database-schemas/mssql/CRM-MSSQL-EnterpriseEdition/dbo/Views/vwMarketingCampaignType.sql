CREATE VIEW [dbo].[vwMarketingCampaignType]
AS

SELECT 
[MarketingCampaignTypeId] AS [Marketing Campaign Type Id],
[MarketingCampaignType] AS [Marketing Campaign Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[MarketingCampaignType]