CREATE TABLE #OrderStatusTemp
(
	[OrderStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #OrderStatusTemp ([OrderStatus], [ActiveStatus]) VALUES ('New', 1)
INSERT INTO #OrderStatusTemp ([OrderStatus], [ActiveStatus]) VALUES ('Pending', 1)
INSERT INTO #OrderStatusTemp ([OrderStatus], [ActiveStatus]) VALUES ('Awaiting Payment', 1)
INSERT INTO #OrderStatusTemp ([OrderStatus], [ActiveStatus]) VALUES ('Awaiting Shipment', 1)
INSERT INTO #OrderStatusTemp ([OrderStatus], [ActiveStatus]) VALUES ('Picking from Warehouse', 1)
INSERT INTO #OrderStatusTemp ([OrderStatus], [ActiveStatus]) VALUES ('In Transit', 1)
INSERT INTO #OrderStatusTemp ([OrderStatus], [ActiveStatus]) VALUES ('Complete', 1)
INSERT INTO #OrderStatusTemp ([OrderStatus], [ActiveStatus]) VALUES ('Cancelled', 1)

MERGE INTO [dbo].[OrderStatus] AS target
USING #OrderStatusTemp AS source
ON target.[OrderStatus] = source.[OrderStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[OrderStatus],
	[ActiveStatus]
) 
VALUES 
(
	source.[OrderStatus],
	source.[ActiveStatus]
);

DROP TABLE #OrderStatusTemp