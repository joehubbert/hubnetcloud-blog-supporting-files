CREATE TABLE #OrderTypeTemp
(
	[OrderType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #OrderTypeTemp ([OrderType], [ActiveStatus]) VALUES ('Final', 1)
INSERT INTO #OrderTypeTemp ([OrderType], [ActiveStatus]) VALUES ('Quote', 1)

MERGE INTO [dbo].[OrderType] AS target
USING #OrderTypeTemp AS source
ON target.[OrderType] = source.[OrderType]
WHEN NOT MATCHED THEN
INSERT
(
	[OrderType],
	[ActiveStatus]
) 
VALUES 
(
	source.[OrderType],
	source.[ActiveStatus]
);

DROP TABLE #OrderTypeTemp