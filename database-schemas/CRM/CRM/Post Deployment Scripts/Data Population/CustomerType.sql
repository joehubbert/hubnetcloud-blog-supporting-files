CREATE TABLE #CustomerTypeTemp
(
	[CustomerType] NVARCHAR(50) NOT NULL
)

INSERT INTO #CustomerTypeTemp ([CustomerType]) VALUES ('Personal')
INSERT INTO #CustomerTypeTemp ([CustomerType]) VALUES ('Business - Small')
INSERT INTO #CustomerTypeTemp ([CustomerType]) VALUES ('Business - Medium')
INSERT INTO #CustomerTypeTemp ([CustomerType]) VALUES ('Business - Large')
INSERT INTO #CustomerTypeTemp ([CustomerType]) VALUES ('Business - Multinational')

MERGE INTO [dbo].[CustomerType] AS target
USING #CustomerTypeTemp AS source
ON target.[CustomerType] = source.[CustomerType]
WHEN NOT MATCHED THEN
INSERT
(
	[CustomerType]
)
VALUES
(
	source.[CustomerType]
);

DROP TABLE #CustomerTypeTemp;