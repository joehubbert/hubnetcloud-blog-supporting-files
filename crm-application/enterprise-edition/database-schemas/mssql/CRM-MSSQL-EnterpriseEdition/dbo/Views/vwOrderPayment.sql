CREATE VIEW [dbo].[vwOrderPayment]
AS

SELECT
OP.[OrderId] AS [Order Id],
OP.[OrderPaymentId] AS [Order Payment Id],
PM.[PaymentMethodId] AS [Payment Method Id],
PM.[PaymentMethod] AS [Payment Method],
OP.[PaymentAmount] AS [Payment Amount],
OP.[CreatedTimestampUTC] AS [Created Timestamp UTC],
OP.[CreatedBy] AS [Created By],
OP.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
OP.[ModifiedBy] AS [Modified By],
OP.[RowVersion] AS [Row Version]
FROM [dbo].[OrderPayment] OP
INNER JOIN [dbo].[PaymentMethod] PM ON OP.[PaymentMethodId] = PM.[PaymentMethodId]