CREATE VIEW [dbo].[vwOrderInvoice]
AS 

SELECT
[OrderId] AS [Order Id],
[OrderInvoiceId] AS [Order Invoice Id],
[OrderInvoice] AS [Order Invoice],
[OrderInvoiceDate] AS [Order Invoice Date],
[OrderInvoiceFriendlyId] AS [Order Invoice Friendly Id]
FROM [dbo].[OrderInvoice]