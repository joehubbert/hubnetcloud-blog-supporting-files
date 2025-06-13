CREATE TABLE #SupplierOrderPaymentStatusTemp
(
	[SupplierOrderPaymentStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #SupplierOrderPaymentStatusTemp ([SupplierOrderPaymentStatus], [ActiveStatus]) VALUES ('Settled', 1)
INSERT INTO #SupplierOrderPaymentStatusTemp ([SupplierOrderPaymentStatus], [ActiveStatus]) VALUES ('Refunded', 1)
INSERT INTO #SupplierOrderPaymentStatusTemp ([SupplierOrderPaymentStatus], [ActiveStatus]) VALUES ('Pending Payment', 1)
INSERT INTO #SupplierOrderPaymentStatusTemp ([SupplierOrderPaymentStatus], [ActiveStatus]) VALUES ('Chargeback', 1)

MERGE INTO [dbo].[SupplierOrderPaymentStatus] AS target
USING #SupplierOrderPaymentStatusTemp AS source
ON target.[SupplierOrderPaymentStatus] = source.[SupplierOrderPaymentStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[SupplierOrderPaymentStatus],
	[ActiveStatus]
)
VALUES
(
	source.[SupplierOrderPaymentStatus],
	source.[ActiveStatus]
);

DROP TABLE #SupplierOrderPaymentStatusTemp