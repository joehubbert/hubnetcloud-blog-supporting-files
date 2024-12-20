CREATE TABLE #OrderLineItemStatusTemp
(
	[OrderLineItemStatus] NVARCHAR(50) NOT NULL
)

INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Pending')
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Shipped')
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Delivered')
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Cancelled')
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Returned')
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Refunded')
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Partially Shipped')
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Partially Delivered')
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Partially Returned')
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Partially Refunded')
INSERT INTO #OrderLineItemStatusTemp ([OrderLineItemStatus]) VALUES ('Awaiting Stock')

MERGE INTO [dbo].[OrderLineItemStatus] AS target
USING #OrderLineItemStatusTemp AS source
ON target.[OrderLineItemStatus] = source.[OrderLineItemStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[OrderLineItemStatus]
)
VALUES
(
	source.[OrderLineItemStatus]
);

DROP TABLE #OrderLineItemStatusTemp;