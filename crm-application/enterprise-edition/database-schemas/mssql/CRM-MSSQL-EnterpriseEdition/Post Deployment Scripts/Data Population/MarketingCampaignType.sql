CREATE TABLE #MarketingCampaignTypeTemp
(
	[MarketingCampaignType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #MarketingCampaignTypeTemp ([MarketingCampaignType], [ActiveStatus]) VALUES ('Email', 1)
INSERT INTO #MarketingCampaignTypeTemp ([MarketingCampaignType], [ActiveStatus]) VALUES ('Social', 1)
INSERT INTO #MarketingCampaignTypeTemp ([MarketingCampaignType], [ActiveStatus]) VALUES ('Event', 1)
INSERT INTO #MarketingCampaignTypeTemp ([MarketingCampaignType], [ActiveStatus]) VALUES ('Seasonal', 1)
INSERT INTO #MarketingCampaignTypeTemp ([MarketingCampaignType], [ActiveStatus]) VALUES ('Influencer', 1)
INSERT INTO #MarketingCampaignTypeTemp ([MarketingCampaignType], [ActiveStatus]) VALUES ('MultiChannel', 1)

MERGE INTO [dbo].[MarketingCampaignType] AS target
USING #MarketingCampaignTypeTemp AS source
ON target.[MarketingCampaignType] = source.[MarketingCampaignType]
WHEN NOT MATCHED THEN
INSERT
(
	[MarketingCampaignType],
	[ActiveStatus]
)
VALUES 
(
	source.[MarketingCampaignType],
	source.[ActiveStatus]
);

DROP TABLE #MarketingCampaignTypeTemp