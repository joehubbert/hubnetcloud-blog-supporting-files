CREATE TABLE #PromotionTypeTemp
(
	[PromotionType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #PromotionTypeTemp 
(
	[PromotionType],
	[ActiveStatus]
)
VALUES
(
	'General',
	1
),
(
	'Seasonal',
	1
),
(
	'Clearance',
	1
),
(
	'Flash Sale',
	1
),
(
	'Bundle Deal',
	1
),
(
	'Free Shipping',
	1
),
(
	'Loyalty Discount',
	1
),
(
	'Student Discount',
	1
),
(
	'First-Time Buyer Discount',
	1
),
(
	'3 for 2',
	1
),
(
	'n for Fixed Price',
	1
),
(
	'Buy One Get One Free',
	1
),
(
	'Percentage Discount',
	1
)

MERGE INTO [dbo].[PromotionType] AS target
USING #PromotionTypeTemp AS source
ON target.[PromotionType] = source.[PromotionType]
WHEN NOT MATCHED THEN
INSERT
(
	[PromotionType],
	[ActiveStatus]
)
VALUES
(
	source.[PromotionType],
	source.[ActiveStatus]
);

DROP TABLE #PromotionTypeTemp