CREATE VIEW [dbo].[vwPromotion]
AS

SELECT
P.[PromotionId] AS [Promotion Id],
MC.[MarketingCampaignId] AS [Marketing Campaign Id],
MC.[MarketingCampaignName] AS [Marketing Campaign Name],
P.[PromotionName] AS [Promotion Name],
P.[PromotionDescription] AS [Promotion Description],
P.[PromotionCode] AS [Promotion Code],
PTT.[PromotionTargetTypeId] AS [Promotion Target Type Id],
PTT.[PromotionTargetType] AS [Promotion Target Type],
PT.[PromotionTypeId] AS [Promotion Type Id],
PT.[PromotionType] AS [Promotion Type],
P.[PromotionValue] AS [Promotion Value],
P.[PromotionBuyQuantity] AS [Promotion Buy Quantity],
P.[PromotionGetQuantity] AS [Promotion Get Quantity],
P.[PromotionStartTimestamp] AS [Promotion Start Timestamp],
P.[PromotionEndTimestamp] AS [Promotion End Timestamp],
P.[ActiveStatus] AS [Active Status],
P.[CreatedTimestamp] AS [Created Timestamp],
P.[CreatedBy] AS [Created By],
P.[ModifiedTimestamp] AS [Modified Timestamp],
P.[ModifiedBy] AS [Modified By]
FROM [dbo].[Promotion] P
INNER JOIN [dbo].[MarketingCampaign] MC ON P.[MarketingCampaignId] = MC.[MarketingCampaignId]
INNER JOIN [dbo].[PromotionTargetType] PTT ON P.[PromotionTargetTypeId] = PTT.[PromotionTargetTypeId]
INNER JOIN [dbo].[PromotionType] PT ON P.[PromotionTypeId] = PT.[PromotionTypeId]