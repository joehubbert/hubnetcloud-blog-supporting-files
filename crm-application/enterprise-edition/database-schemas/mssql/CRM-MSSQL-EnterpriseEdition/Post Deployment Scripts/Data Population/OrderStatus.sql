CREATE TABLE #OrderStatusTemp
(
	[OrderStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #OrderStatusTemp 
(
	[OrderStatus],
	[ActiveStatus]
)
VALUES
(
	'New', 
	1
),
(
	'Pending',
	1
),
(
	'Awaiting Payment',
	1
),
(
	'Awaiting Shipment',
	1
),
(
	'Picking from Warehouse',
	1
),
(
	'In Transit',
	1
),
(
	'Complete',
	1
),
(
	'Cancelled',
	1
)

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