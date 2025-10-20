CREATE TABLE #MarketingCampaignStatusTemp
(
	[MarketingCampaignStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #MarketingCampaignStatusTemp
(
	[MarketingCampaignStatus],
	[ActiveStatus]
) 
VALUES 
(
	'New', 
	1
),
(
	'Pending Approval',
	1
),
(
	'Planned',
	1
),
(
	'Active',
	1
),
(
	'Paused', 
	1
),
(
	'Completed', 
	1
),
(
	'Cancelled', 
	1
)

MERGE INTO [dbo].[MarketingCampaignStatus] AS target
USING #MarketingCampaignStatusTemp AS source
ON target.[MarketingCampaignStatus] = source.[MarketingCampaignStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[MarketingCampaignStatus],
	[ActiveStatus]
) 
VALUES 
(
	source.[MarketingCampaignStatus],
	source.[ActiveStatus]
);

DROP TABLE #MarketingCampaignStatusTemp