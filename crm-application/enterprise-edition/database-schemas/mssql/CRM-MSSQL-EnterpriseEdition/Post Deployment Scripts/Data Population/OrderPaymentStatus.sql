CREATE TABLE #OrderPaymentStatusTemp
(
	[OrderPaymentStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #OrderPaymentStatusTemp ([OrderPaymentStatus], [ActiveStatus]) VALUES ('Settled', 1)
INSERT INTO #OrderPaymentStatusTemp ([OrderPaymentStatus], [ActiveStatus]) VALUES ('Refunded', 1)
INSERT INTO #OrderPaymentStatusTemp ([OrderPaymentStatus], [ActiveStatus]) VALUES ('Partially Refunded', 1)
INSERT INTO #OrderPaymentStatusTemp ([OrderPaymentStatus], [ActiveStatus]) VALUES ('Pending Payment', 1)
INSERT INTO #OrderPaymentStatusTemp ([OrderPaymentStatus], [ActiveStatus]) VALUES ('Chargeback', 1)

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