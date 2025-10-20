CREATE TABLE #SupplierOrderStatusTemp
(
	[SupplierOrderStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #SupplierOrderStatusTemp 
(
	[SupplierOrderStatus],
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

MERGE INTO [dbo].[SupplierOrderStatus] AS target
USING #SupplierOrderStatusTemp AS source
ON target.[SupplierOrderStatus] = source.[SupplierOrderStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[SupplierOrderStatus],
	[ActiveStatus]
) 
VALUES 
(
	source.[SupplierOrderStatus],
	source.[ActiveStatus]
);

DROP TABLE #SupplierOrderStatusTemp