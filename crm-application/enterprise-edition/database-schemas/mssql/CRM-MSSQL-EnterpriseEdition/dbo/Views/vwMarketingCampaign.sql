CREATE VIEW [dbo].[vwMarketingCampaign]
AS

SELECT
MC.[MarketingCampaignId] AS [Marketing Campaign Id],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Configuration Company Name],
MCT.[MarketingCampaignTypeId] AS [Marketing Campaign Type Id],
MCT.[MarketingCampaignType] AS [Marketing Campaign Type],
MC.[MarketingCampaignName] AS [Marketing Campaign Name],
MC.[MarketingCampaignDescription] AS [Marketing Campaign Description],
MC.[MarketingCampaignGoal] AS [Marketing Campaign Goal],
MC.[MarketingCampaignStartTimestamp] AS [Marketing Campaign Start Timestamp],
MC.[MarketingCampaignEndTimestamp] AS [Marketing Campaign End Timestamp],
CAST(MC.[MarketingCampaignStartTimestamp] AS DATE) AS [Marketing Campaign Start Date],
CAST(MC.[MarketingCampaignEndTimestamp] AS DATE) AS [Marketing Campaign End Date],
MC.[Budget] AS [Marketing Campaign Budget],
MC.[ActualCost] AS [Marketing Campaign Actual Cost],
SUM(MC.[Budget]-MC.[ActualCost]) AS [Marketing Campaign Budget vs Actual Cost],
SUM((MC.[Budget]-MC.[ActualCost]) / (MC.[Budget] * 100)) AS [Marketing Campaign Budget vs Actual Cost Percentage],
MC.[ForecastedRevenue] AS [Marketing Campaign Forecasted Revenue],
SUM(OLI.[FinalPrice]) AS [Marketing Campaign Gross Revenue],
SUM(MC.[ForecastedRevenue]-OLI.[FinalPrice]) AS [Marketing Campaign Forecasted Revenue vs Gross Revenue],
SUM((MC.[ForecastedRevenue]-OLI.[FinalPrice]) - (MC.[Budget]-MC.[ActualCost])) AS [Marketing Campaign Gross Revenue vs Net Revenue],
AVG(OLI.[FinalPrice]) AS [Marketing Campaign Average Order Value],
MC.[ActiveStatus] AS [Active Status],
MC.[CreatedTimestamp] AS [Created Timestamp],
MC.[CreatedBy] AS [Created By],
MC.[ModifiedTimestamp] AS [Modified Timestamp],
MC.[ModifiedBy] AS [Modified By]
FROM [dbo].[MarketingCampaign] MC
INNER JOIN [dbo].[CompanyConfiguration] CC ON MC.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MarketingCampaignType] MCT ON MC.[MarketingCampaignTypeId] = MCT.[MarketingCampaignTypeId]
INNER JOIN [dbo].[Promotion] P ON MC.[MarketingCampaignId] = P.[MarketingCampaignId]
INNER JOIN [dbo].[OrderLineItem] OLI ON P.[PromotionId] = OLI.[PromotionId]
GROUP BY
MC.[MarketingCampaignId],
CC.[CompanyConfigurationId],
CC.[CompanyName],
MCT.[MarketingCampaignTypeId],
MCT.[MarketingCampaignType],
MC.[MarketingCampaignName],
MC.[MarketingCampaignDescription],
MC.[MarketingCampaignGoal],
MC.[MarketingCampaignStartTimestamp],
MC.[MarketingCampaignEndTimestamp],
MC.[Budget],
MC.[ActualCost],
MC.[ForecastedRevenue],
MC.[ActiveStatus],
MC.[CreatedTimestamp],
MC.[CreatedBy],
MC.[ModifiedTimestamp],
MC.[ModifiedBy]