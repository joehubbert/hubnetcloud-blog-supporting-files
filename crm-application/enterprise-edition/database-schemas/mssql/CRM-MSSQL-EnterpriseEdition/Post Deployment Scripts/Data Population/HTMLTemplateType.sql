CREATE TABLE #HTMLTemplateTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
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
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[HTMLTemplateType],
	[ActiveStatus]
)
VALUES 
(
	source.[MasterDataTypeId],
	source.[HTMLTemplateType],
	source.[ActiveStatus]
);

DROP TABLE #HTMLTemplateTypeTemp