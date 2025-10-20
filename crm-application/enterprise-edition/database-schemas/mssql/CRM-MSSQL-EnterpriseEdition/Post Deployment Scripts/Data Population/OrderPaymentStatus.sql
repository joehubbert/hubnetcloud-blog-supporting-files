CREATE TABLE #OrderPaymentStatusTemp
(
	[OrderPaymentStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #OrderPaymentStatusTemp
(
	[OrderPaymentStatus],
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

MERGE INTO [dbo].[OrderPaymentStatus] AS target
USING #OrderPaymentStatusTemp AS source
ON target.[OrderPaymentStatus] = source.[OrderPaymentStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[OrderPaymentStatus],
	[ActiveStatus]
)
VALUES
(
	source.[OrderPaymentStatus],
	source.[ActiveStatus]
);

DROP TABLE #OrderPaymentStatusTemp