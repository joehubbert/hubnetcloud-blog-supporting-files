CREATE TABLE #PaymentMethodTemp
(
	[PaymentMethod] NVARCHAR(50) NOT NULL
)

INSERT INTO #PaymentMethodTemp ([PaymentMethod]) VALUES ('Cash')
INSERT INTO #PaymentMethodTemp ([PaymentMethod]) VALUES ('Debit Card')
INSERT INTO #PaymentMethodTemp ([PaymentMethod]) VALUES ('Credit Card')
INSERT INTO #PaymentMethodTemp ([PaymentMethod]) VALUES ('Invoice')
INSERT INTO #PaymentMethodTemp ([PaymentMethod]) VALUES ('Account Credit')
INSERT INTO #PaymentMethodTemp ([PaymentMethod]) VALUES ('Bank Transfer')

MERGE INTO [dbo].[PaymentMethod] AS target
USING #PaymentMethodTemp AS source
ON target.[PaymentMethod] = source.[PaymentMethod]
WHEN NOT MATCHED THEN
INSERT 
(
	[PaymentMethod]
) 
VALUES 
(
	source.[PaymentMethod]
);

DROP TABLE #PaymentMethodTemp;