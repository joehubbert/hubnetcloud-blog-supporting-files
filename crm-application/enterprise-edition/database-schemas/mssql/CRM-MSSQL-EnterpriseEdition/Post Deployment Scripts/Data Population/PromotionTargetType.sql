CREATE TABLE #PromotionTargetTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[PromotionTargetType] NVARCHAR(50) NOT NULL,
	[PromotionTargetTypeDescription] NVARCHAR(255) NULL,
	[ActiveStatus] BIT NOT NULL
)

DECLARE @builtInMasterDataTypeIdPromotionTargetType UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdPromotionTargetType = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #PromotionTargetTypeTemp
(
	[MasterDataTypeId],
	[PromotionTargetType],
	[PromotionTargetTypeDescription],
	[ActiveStatus]
)
VALUES 
(
	@builtInMasterDataTypeIdPromotionTargetType,
	'General',
	'Generic promotion',
	1
),
(
	@builtInMasterDataTypeIdPromotionTargetType,
	'Manufacturer',
	'Promotion set at the product manufacturer level.',
	1
),
(
	@builtInMasterDataTypeIdPromotionTargetType,
	'Manufacturer Product Category',
	'Promotion set at the product category level linked to a specific manufacturer.',
	1
),
(
	@builtInMasterDataTypeIdPromotionTargetType,
	'Manufacturer Product Sub Category',
	'Promotion set at the product sub category level linked to a specific manufacturer.',
	1
),
(
	@builtInMasterDataTypeIdPromotionTargetType,
	'Product',
	'Promotion for a specific product.',
	1
),
(
	@builtInMasterDataTypeIdPromotionTargetType,
	'Product Category',
	'Promotion set at the product category level.',
	1
),
(
	@builtInMasterDataTypeIdPromotionTargetType,
	'Product Sub Category',
	'Promotion set at the product sub category level.',
	1
),
(
	@builtInMasterDataTypeIdPromotionTargetType,
	'Supplier',
	'Promotion set at the supplier level.',
	1
),
(
	@builtInMasterDataTypeIdPromotionTargetType,
	'Supplier Product Category',
	'Promotion set at the product category level linked to a specific supplier.',
	1
),
(
	@builtInMasterDataTypeIdPromotionTargetType,
	'Supplier Product Sub Category',
	'Promotion set at the product sub category level linked to a specific supplier.',
	1
)

MERGE INTO [dbo].[PromotionTargetType] AS target
USING #PromotionTargetTypeTemp AS source
ON target.[PromotionTargetType] = source.[PromotionTargetType]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[PromotionTargetType],
	[PromotionTargetTypeDescription],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataTypeId],
	source.[PromotionTargetType],
	source.[PromotionTargetTypeDescription],
	source.[ActiveStatus]
);

DROP TABLE #PromotionTargetTypeTemp