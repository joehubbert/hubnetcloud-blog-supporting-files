CREATE TABLE #HTMLTemplateTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[HTMLTemplateType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

DECLARE @builtInMasterDataTypeIdHTMLTemplateType UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdHTMLTemplateType = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #HTMLTemplateTypeTemp
(
	[MasterDataTypeId],
	[HTMLTemplateType],
	[ActiveStatus]
) 
VALUES 
(
	@builtInMasterDataTypeIdHTMLTemplateType,
	'Invoice', 
	1
),
(
	@builtInMasterDataTypeIdHTMLTemplateType,
	'Purchase Order', 
	1
),
(
	@builtInMasterDataTypeIdHTMLTemplateType,
	'Delivery Note', 
	1
),
(
	@builtInMasterDataTypeIdHTMLTemplateType,
	'Email Notification', 
	1
),
(
	@builtInMasterDataTypeIdHTMLTemplateType,
	'Email Newsletter', 
	1
)

MERGE INTO [dbo].[HTMLTemplateType] AS target
USING #HTMLTemplateTypeTemp AS source
ON target.[HTMLTemplateType] = source.[HTMLTemplateType]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[HTMLTemplateType],
	[ActiveStatus]
)
VALUES 
(
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[HTMLTemplateType],
	source.[ActiveStatus]
);

DROP TABLE #HTMLTemplateTypeTemp