CREATE TABLE #MarketingCampaignStatusTemp
(
	[MarketingCampaignStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #MarketingCampaignStatusTemp ([MarketingCampaignStatus], [ActiveStatus]) VALUES ('New', 1)
INSERT INTO #MarketingCampaignStatusTemp ([MarketingCampaignStatus], [ActiveStatus]) VALUES ('Pending Approval', 1)
INSERT INTO #MarketingCampaignStatusTemp ([MarketingCampaignStatus], [ActiveStatus]) VALUES ('Planned', 1)
INSERT INTO #MarketingCampaignStatusTemp ([MarketingCampaignStatus], [ActiveStatus]) VALUES ('Active', 1)
INSERT INTO #MarketingCampaignStatusTemp ([MarketingCampaignStatus], [ActiveStatus]) VALUES ('Paused', 1)
INSERT INTO #MarketingCampaignStatusTemp ([MarketingCampaignStatus], [ActiveStatus]) VALUES ('Completed', 1)
INSERT INTO #MarketingCampaignStatusTemp ([MarketingCampaignStatus], [ActiveStatus]) VALUES ('Cancelled', 1)

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