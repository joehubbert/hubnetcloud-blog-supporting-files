CREATE TABLE #PaymentMethodTemp
(
	[PaymentMethod] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #PaymentMethodTemp ([PaymentMethod], [ActiveStatus]) VALUES ('Cash', 1)
INSERT INTO #PaymentMethodTemp ([PaymentMethod], [ActiveStatus]) VALUES ('Debit Card', 1)
INSERT INTO #PaymentMethodTemp ([PaymentMethod], [ActiveStatus]) VALUES ('Credit Card', 1)
INSERT INTO #PaymentMethodTemp ([PaymentMethod], [ActiveStatus]) VALUES ('Invoice', 1)
INSERT INTO #PaymentMethodTemp ([PaymentMethod], [ActiveStatus]) VALUES ('Account Credit', 1)
INSERT INTO #PaymentMethodTemp ([PaymentMethod], [ActiveStatus]) VALUES ('Bank Transfer', 1)

MERGE INTO [dbo].[PaymentMethod] AS target
USING #PaymentMethodTemp AS source
ON target.[PaymentMethod] = source.[PaymentMethod]
WHEN NOT MATCHED THEN
INSERT 
(
	[PaymentMethod],
	[ActiveStatus]
) 
VALUES 
(
	source.[PaymentMethod],
	source.[ActiveStatus]
);

DROP TABLE #PaymentMethodTemp