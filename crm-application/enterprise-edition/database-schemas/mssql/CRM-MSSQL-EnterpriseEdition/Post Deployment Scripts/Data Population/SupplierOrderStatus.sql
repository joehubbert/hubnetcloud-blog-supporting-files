CREATE TABLE #SupplierOrderStatusTemp
(
	[SupplierOrderStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #SupplierOrderStatusTemp ([SupplierOrderStatus], [ActiveStatus]) VALUES ('New', 1)
INSERT INTO #SupplierOrderStatusTemp ([SupplierOrderStatus], [ActiveStatus]) VALUES ('Pending', 1)
INSERT INTO #SupplierOrderStatusTemp ([SupplierOrderStatus], [ActiveStatus]) VALUES ('Awaiting Paymwnt', 1)
INSERT INTO #SupplierOrderStatusTemp ([SupplierOrderStatus], [ActiveStatus]) VALUES ('Awaiting Shipment', 1)
INSERT INTO #SupplierOrderStatusTemp ([SupplierOrderStatus], [ActiveStatus]) VALUES ('Picking from Warehouse', 1)
INSERT INTO #SupplierOrderStatusTemp ([SupplierOrderStatus], [ActiveStatus]) VALUES ('In Transit', 1)
INSERT INTO #SupplierOrderStatusTemp ([SupplierOrderStatus], [ActiveStatus]) VALUES ('Complete', 1)
INSERT INTO #SupplierOrderStatusTemp ([SupplierOrderStatus], [ActiveStatus]) VALUES ('Cancelled', 1)

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