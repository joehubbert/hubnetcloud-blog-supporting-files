CREATE TABLE #PromotionTargetTypeTemp
(
	[PromotionTargetType] NVARCHAR(50) NOT NULL,
	[PromotionTargetTypeDescription] NVARCHAR(255) NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #PromotionTargetTypeTemp
(
	[PromotionTargetType],
	[PromotionTargetTypeDescription],
	[ActiveStatus]
)
VALUES 
(
	'General',
	'Generic promotion',
	1
),
(
	'Manufacturer',
	'Promotion set at the product manufacturer level.',
	1
),
(
	'Manufacturer Product Category',
	'Promotion set at the product category level linked to a specific manufacturer.',
	1
),
(
	'Manufacturer Product Sub Category',
	'Promotion set at the product sub category level linked to a specific manufacturer.',
	1
),
(
	'Product',
	'Promotion for a specific product.',
	1
),
(
	'Product Category',
	'Promotion set at the product category level.',
	1
),
(
	'Product Sub Category',
	'Promotion set at the product sub category level.',
	1
),
(
	'Supplier',
	'Promotion set at the supplier level.',
	1
),
(
	'Supplier Product Category',
	'Promotion set at the product category level linked to a specific supplier.',
	1
),
(
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
	[PromotionTargetType],
	[PromotionTargetTypeDescription],
	[ActiveStatus]
)
VALUES
(
	source.[PromotionTargetType],
	source.[PromotionTargetTypeDescription],
	source.[ActiveStatus]
);

DROP TABLE #PromotionTargetTypeTemp