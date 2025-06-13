CREATE VIEW [dbo].[vwOrderPayment]
AS

SELECT
OP.[OrderId] AS [Order Id],
OP.[OrderPaymentId] AS [Order Payment Id],
PM.[PaymentMethodId] AS [Payment Method Id],
PM.[PaymentMethod] AS [Payment Method],
OP.[PaymentAmount] AS [Payment Amount]
FROM [dbo].[OrderPayment] OP
INNER JOIN [dbo].[PaymentMethod] PM ON OP.[PaymentMethodId] = PM.[PaymentMethodId]