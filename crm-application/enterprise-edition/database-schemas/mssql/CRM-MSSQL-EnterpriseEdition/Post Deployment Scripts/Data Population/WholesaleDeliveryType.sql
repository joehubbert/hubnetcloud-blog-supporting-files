CREATE TABLE #WholesaleDeliveryTypeTemp
(
	[WholesaleDeliveryType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #WholesaleDeliveryTypeTemp ([WholesaleDeliveryType], [ActiveStatus]) VALUES ('Carton', 1)
INSERT INTO #WholesaleDeliveryTypeTemp ([WholesaleDeliveryType], [ActiveStatus]) VALUES ('Pallet - Carton', 1)
INSERT INTO #WholesaleDeliveryTypeTemp ([WholesaleDeliveryType], [ActiveStatus]) VALUES ('Pallet - Unit', 1)

MERGE INTO [dbo].[WholesaleDeliveryType] AS target
USING #WholesaleDeliveryTypeTemp AS source
ON target.[WholesaleDeliveryType] = source.[WholesaleDeliveryType]
WHEN NOT MATCHED THEN
INSERT
(
	[WholesaleDeliveryType],
	[ActiveStatus]
)
VALUES
(
	source.[WholesaleDeliveryType],
	source.[ActiveStatus]
);

DROP TABLE #WholesaleDeliveryTypeTemp