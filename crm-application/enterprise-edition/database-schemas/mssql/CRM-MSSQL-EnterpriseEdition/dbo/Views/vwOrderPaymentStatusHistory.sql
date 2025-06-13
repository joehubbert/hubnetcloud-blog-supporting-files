CREATE VIEW [dbo].[vwOrderPaymentStatusHistory]
AS

SELECT
OPSH.[OrderPaymentStatusHistoryId] AS [Order Payment Status History Id],
OP.[OrderId] AS [Order Id],
OP.[OrderPaymentId] AS [Order Payment Id],
OPS.[OrderPaymentStatusId] AS [Order Payment Status Id],
OPS.[OrderPaymentStatus] AS [Order Payment Status]
FROM [dbo].[OrderPaymentStatusHistory] OPSH
INNER JOIN [dbo].[OrderPayment] OP ON OPSH.[OrderPaymentId] = OP.[OrderPaymentId]
INNER JOIN [dbo].[OrderPaymentStatus] OPS ON OPSH.[OrderPaymentStatusId] = OPS.[OrderPaymentStatusId]