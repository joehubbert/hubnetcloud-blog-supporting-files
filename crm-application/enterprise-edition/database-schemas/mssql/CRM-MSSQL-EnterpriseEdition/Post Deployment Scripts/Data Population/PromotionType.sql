CREATE TABLE #PromotionTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[PromotionType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

DECLARE @builtInMasterDataTypeIdPromotionType UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdPromotionType = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #PromotionTypeTemp 
(
	[MasterDataTypeId],
	[PromotionType],
	[ActiveStatus]
)
VALUES
(
	@builtInMasterDataTypeIdPromotionType,
	'General',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'Seasonal',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'Clearance',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'Flash Sale',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'Bundle Deal',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'Free Shipping',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'Loyalty Discount',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'Student Discount',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'First-Time Buyer Discount',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'3 for 2',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'n for Fixed Price',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'Buy One Get One Free',
	1
),
(
	@builtInMasterDataTypeIdPromotionType,
	'Percentage Discount',
	1
)

MERGE INTO [dbo].[PromotionType] AS target
USING #PromotionTypeTemp AS source
ON target.[PromotionType] = source.[PromotionType]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[PromotionType],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataTypeId],
	source.[PromotionType],
	source.[ActiveStatus]
);

DROP TABLE #PromotionTypeTemp