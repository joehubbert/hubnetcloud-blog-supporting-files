CREATE TABLE #PaymentMethodTemp
(
	[PaymentMethod] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #PaymentMethodTemp
(
	[PaymentMethod],
	[ActiveStatus]
)
VALUES
(
	'Cash', 
	1
),
(
	'Debit Card',
	1
),
(
	'Credit Card',
	1
),
(
	'Invoice',
	1
),
(
	'Account Credit',
	1
),
(
	'Bank Transfer',
	1
),
(
	'Vipps',
	1
)

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