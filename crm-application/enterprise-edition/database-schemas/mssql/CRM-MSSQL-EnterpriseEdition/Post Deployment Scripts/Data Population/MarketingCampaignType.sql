CREATE TABLE #MarketingCampaignTypeTemp
(
	[MarketingCampaignType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #MarketingCampaignTypeTemp
(
	[MarketingCampaignType],
	[ActiveStatus]
)
VALUES
(
	'Email',
	1
),
(
	'Social',
	1
),
(
	'Event',
	1
),
(
	'Seasonal',
	1
),
(
	'Influencer',
	1
),
(
	'MultiChannel',
	1
)

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