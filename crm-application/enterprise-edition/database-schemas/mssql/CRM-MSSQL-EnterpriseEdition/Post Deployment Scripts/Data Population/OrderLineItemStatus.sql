CREATE TABLE #OrderLineItemStatusTemp
(
	[OrderLineItemStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Pending', 1)
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Shipped', 1)
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Delivered', 1)
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Cancelled', 1)
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Returned', 1)
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Refunded', 1)
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Partially Shipped', 1)
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Partially Delivered', 1)
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Partially Returned', 1)
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Partially Refunded', 1)
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus], [ActiveStatus]) VALUES ('Awaiting Stock', 1)

MERGE INTO [dbo].[OrderLineItemStatus] AS target
USING #OrderLineItemStatusTemp AS source
ON target.[OrderLineItemStatus] = source.[OrderLineItemStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[OrderLineItemStatus],
	[ActiveStatus]
)
VALUES
(
	source.[OrderLineItemStatus],
	source.[ActiveStatus]
);

DROP TABLE #OrderLineItemStatusTemp