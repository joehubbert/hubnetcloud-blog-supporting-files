CREATE TABLE #SupplierOrderLineItemStatusTemp
(
	[SupplierOrderLineItemStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Pending', 1)
INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Shipped', 1)
INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Delivered', 1)
INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Cancelled', 1)
INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Returned', 1)
INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Refunded', 1)
INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Partially Shipped', 1)
INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Partially Delivered', 1)
INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Partially Returned', 1)
INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Partially Refunded', 1)
INSERT INTO #SupplierOrderLineItemStatusTemp ([SupplierOrderLineItemStatus], [ActiveStatus]) VALUES ('Awaiting Stock', 1)

MERGE INTO [dbo].[SupplierOrderLineItemStatus] AS target
USING #SupplierOrderLineItemStatusTemp AS source
ON target.[SupplierOrderLineItemStatus] = source.[SupplierOrderLineItemStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[SupplierOrderLineItemStatus],
	[ActiveStatus]
)
VALUES
(
	source.[SupplierOrderLineItemStatus],
	source.[ActiveStatus]
);

DROP TABLE #SupplierOrderLineItemStatusTemp