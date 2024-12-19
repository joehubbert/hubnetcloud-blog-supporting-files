CREATE PROCEDURE [dbo].[spCreatePaymentMethod]
	@paymentMethod NVARCHAR(50)
AS

CREATE TABLE #PaymentMethodTemp
(
	[PaymentMethod] NVARCHAR(50) NOT NULL
)

INSERT INTO #PaymentMethodTemp
(
	[PaymentMethod]
)
VALUES
(
	@paymentMethod
)

IF EXISTS
(
SELECT *
FROM [dbo].[PaymentMethod] PM
INNER JOIN #PaymentMethodTemp PMT ON PM.[PaymentMethod] = PMT.[PaymentMethod]
WHERE PM.[PaymentMethod] = PMT.[PaymentMethod]
)
THROW 50000, 'Payment Method already exists, please update the existing record.', 1;
ELSE
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