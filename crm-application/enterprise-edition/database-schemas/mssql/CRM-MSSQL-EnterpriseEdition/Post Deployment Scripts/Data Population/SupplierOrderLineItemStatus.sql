CREATE TABLE #SupplierOrderLineItemStatusTemp
(
	[SupplierOrderLineItemStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #SupplierOrderLineItemStatusTemp
(
	[SupplierOrderLineItemStatus],
	[ActiveStatus]
)
VALUES
(
	'Pending',
	1
),
(
	'Shipped',
	1
),
(
	'Delivered',
	1
),
(
	'Cancelled',
	1
),
(
	'Returned',
	1
),
(
	'Refunded',
	1
),
(
	'Partially Shipped',
	1
),
(
	'Partially Delivered',
	1
),
(
	'Partially Returned',
	1
),
(
	'Partially Refunded',
	1
),
(
	'Awaiting Stock',
	1
)

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