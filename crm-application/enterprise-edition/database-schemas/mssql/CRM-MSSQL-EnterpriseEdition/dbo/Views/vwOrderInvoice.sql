CREATE VIEW [dbo].[vwOrderInvoice]
AS 

SELECT
[OrderId] AS [Order Id],
[OrderInvoiceId] AS [Order Invoice Id],
[OrderInvoice] AS [Order Invoice],
[OrderInvoiceDate] AS [Order Invoice Date],
[OrderInvoiceFriendlyId] AS [Order Invoice Friendly Id],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[OrderInvoice]