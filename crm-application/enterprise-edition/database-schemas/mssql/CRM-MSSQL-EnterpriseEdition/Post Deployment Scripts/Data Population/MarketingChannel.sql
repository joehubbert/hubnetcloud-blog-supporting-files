CREATE TABLE #MarketingChannelTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[MarketingChannel] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

DECLARE @builtInMasterDataTypeIdMarketingChannel UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdMarketingChannel = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #MarketingChannelTemp 
(
	[MasterDataTypeId],
	[MarketingChannel],
	[ActiveStatus]
)
VALUES 
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Search Engine Optimisation',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Search Engine Marketing',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Pay-Per-Click',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Email',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Social Media',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Content Marketing',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Affiliate Marketing',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Influencer Marketing',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Webinar',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Online Community',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Company Website',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Microsite',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Event & Trade Show',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Print Advertising',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Television',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Radio',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Direct Mail',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'SMS',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Account-Based Marketing',
	1
),
(
	@builtInMasterDataTypeIdMarketingChannel,
	'Company App',
	1
)

MERGE INTO [dbo].[MarketingChannel] AS target
USING #MarketingChannelTemp AS source
ON target.[MarketingChannel] = source.[MarketingChannel]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[MarketingChannel],
	[ActiveStatus]
) 
VALUES 
(
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[MarketingChannel],
	source.[ActiveStatus]
);

DROP TABLE #MarketingChannelTemp