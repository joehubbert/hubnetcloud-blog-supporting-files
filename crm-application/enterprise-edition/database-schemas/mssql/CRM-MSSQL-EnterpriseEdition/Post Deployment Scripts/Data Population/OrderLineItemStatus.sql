CREATE TABLE #OrderLineItemStatusTemp
(
	[OrderLineItemStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #OrderLineItemStatusTemp
(
	[OrderLineItemStatus],
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