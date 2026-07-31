CREATE TABLE #MarketingCampaignStatusTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[MarketingCampaignStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

DECLARE @builtInMasterDataTypeIdMarketingCampaignStatus UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdMarketingCampaignStatus = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #MarketingCampaignStatusTemp
(
	[MasterDataTypeId],
	[MarketingCampaignStatus],
	[ActiveStatus]
) 
VALUES 
(
	@builtInMasterDataTypeIdMarketingCampaignStatus,
	'New', 
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignStatus,
	'Pending Approval',
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignStatus,
	'Planned',
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignStatus,
	'Active',
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignStatus,
	'Paused', 
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignStatus,
	'Completed', 
	1
),
(
	@builtInMasterDataTypeIdMarketingCampaignStatus,
	'Cancelled', 
	1
)

MERGE INTO [dbo].[MarketingCampaignStatus] AS target
USING #MarketingCampaignStatusTemp AS source
ON target.[MarketingCampaignStatus] = source.[MarketingCampaignStatus]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[MarketingCampaignStatus],
	[ActiveStatus]
) 
VALUES 
(
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[MarketingCampaignStatus],
	source.[ActiveStatus]
);

DROP TABLE #MarketingCampaignStatusTemp