CREATE TABLE #SupplierOrderPaymentStatusTemp
(
	[SupplierOrderPaymentStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #SupplierOrderPaymentStatusTemp 
(
	[SupplierOrderPaymentStatus],
	[ActiveStatus]
)
VALUES
(
	'Settled', 
	1
),
(
	'Partially Settled', 
	1
),
(
	'Unsettled', 
	1
),
(
	'Refunded', 
	1
),
(
	'Pending Payment', 
	1
),
(
	'Chargeback', 
	1
)

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