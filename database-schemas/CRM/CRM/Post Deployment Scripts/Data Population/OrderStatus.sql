CREATE TABLE #OrderStatusTemp
(
	[OrderStatus] NVARCHAR(50) NOT NULL
)

INSERT INTO #OrderStatusTemp ([OrderStatus]) VALUES ('Pending')
INSERT INTO #OrderStatusTemp ([OrderStatus]) VALUES ('Awaiting Paymwnt')
INSERT INTO #OrderStatusTemp ([OrderStatus]) VALUES ('Awaiting Shipment')
INSERT INTO #OrderStatusTemp ([OrderStatus]) VALUES ('Picking from Warehouse')
INSERT INTO #OrderStatusTemp ([OrderStatus]) VALUES ('In Transit')
INSERT INTO #OrderStatusTemp ([OrderStatus]) VALUES ('Complete')
INSERT INTO #OrderStatusTemp ([OrderStatus]) VALUES ('Cancelled')

MERGE INTO [dbo].[OrderStatus] AS target
USING #OrderStatusTemp AS source
ON target.[OrderStatus] = source.[OrderStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[OrderStatus]
) 
VALUES 
(
	source.[OrderStatus]
);

DROP TABLE #OrderStatusTemp;