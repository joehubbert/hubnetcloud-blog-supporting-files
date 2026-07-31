CREATE TABLE #MarketingCampaignTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[MarketingCampaignType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

DECLARE @builtInMasterDataTypeIdMarketingCampaignType UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdMarketingCampaignType = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #MarketingCampaignTypeTemp
(
	[MasterDataTypeId],
	[MarketingCampaignType],
	[ActiveStatus]
)
VALUES
(
	@builtInMasterDataTypeIdMarketingCampaignType,
	'Email',
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignType,
	'Social',
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignType,
	'Event',
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignType,
	'Seasonal',
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignType,
	'Influencer',
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignType,
	'MultiChannel',
	1
)

MERGE INTO [dbo].[MarketingCampaignType] AS target
USING #MarketingCampaignTypeTemp AS source
ON target.[MarketingCampaignType] = source.[MarketingCampaignType]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[MarketingCampaignType],
	[ActiveStatus]
)
VALUES 
(
	source.[MasterDataTypeId],
	source.[MarketingCampaignType],
	source.[ActiveStatus]
);

DROP TABLE #MarketingCampaignTypeTemp