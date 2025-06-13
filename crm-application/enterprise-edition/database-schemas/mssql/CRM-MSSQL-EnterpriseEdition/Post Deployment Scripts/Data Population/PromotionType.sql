CREATE TABLE #PromotionTypeTemp
(
	[PromotionType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #PromotionTypeTemp ([PromotionType], [ActiveStatus]) VALUES ('General', 1)
INSERT INTO #PromotionTypeTemp ([PromotionType], [ActiveStatus]) VALUES ('3 for 2', 1)
INSERT INTO #PromotionTypeTemp ([PromotionType], [ActiveStatus]) VALUES ('n for Fixed Price', 1)
INSERT INTO #PromotionTypeTemp ([PromotionType], [ActiveStatus]) VALUES ('Buy One Get One Free', 1)
INSERT INTO #PromotionTypeTemp ([PromotionType], [ActiveStatus]) VALUES ('Percentage Discount', 1)

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