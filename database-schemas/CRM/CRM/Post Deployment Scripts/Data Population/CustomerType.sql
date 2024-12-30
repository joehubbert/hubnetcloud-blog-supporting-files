CREATE TABLE #CustomerTypeTemp
(
	[CustomerType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #CustomerTypeTemp ([CustomerType], [ActiveStatus]) VALUES ('Personal', 1)
INSERT INTO #CustomerTypeTemp ([CustomerType], [ActiveStatus]) VALUES ('Business - Small', 1)
INSERT INTO #CustomerTypeTemp ([CustomerType], [ActiveStatus]) VALUES ('Business - Medium', 1)
INSERT INTO #CustomerTypeTemp ([CustomerType], [ActiveStatus]) VALUES ('Business - Large', 1)
INSERT INTO #CustomerTypeTemp ([CustomerType], [ActiveStatus]) VALUES ('Business - Multinational', 1)

MERGE INTO [dbo].[CustomerType] AS target
USING #CustomerTypeTemp AS source
ON target.[CustomerType] = source.[CustomerType]
WHEN NOT MATCHED THEN
INSERT
(
	[CustomerType],
	[ActiveStatus]
)
VALUES
(
	source.[CustomerType],
	source.[ActiveStatus]
);

DROP TABLE #CustomerTypeTemp;