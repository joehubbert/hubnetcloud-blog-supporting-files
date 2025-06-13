CREATE VIEW [dbo].[vwOrderPaymentStatus]
AS

SELECT
[OrderPaymentStatusId] AS [Order Payment Status Id],
[OrderPaymentStatus] AS [Order Payment Status],
[ActiveStatus] AS [Active Status]
FROM [dbo].[OrderPaymentStatus]