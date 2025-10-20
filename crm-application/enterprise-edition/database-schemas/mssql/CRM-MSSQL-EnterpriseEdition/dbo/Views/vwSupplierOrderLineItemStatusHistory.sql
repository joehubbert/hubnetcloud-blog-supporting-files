CREATE VIEW [dbo].[vwSupplierOrderLineItemStatusHistory]
AS

SELECT
SOLISH.[SupplierOrderLineItemStatusHistoryId] AS [Supplier Order Line Item Status History Id],
SOLISH.[SupplierOrderLineItemId] AS [Supplier Order Line Item Id],
SOLIS.[SupplierOrderLineItemStatusId] AS [Supplier Order Line Item Status Id],
SOLIS.[SupplierOrderLineItemStatus] AS [Supplier Order Line Item Status],
SOLISH.[CreatedTimestampUTC] AS [Created Timestamp UTC],
SOLISH.[CreatedBy] AS [Created By],
SOLISH.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
SOLISH.[ModifiedBy] [Modified By],
SOLISH.[RowVersion] AS [Row Version]
FROM [dbo].[SupplierOrderLineItemStatusHistory] SOLISH
INNER JOIN [dbo].[SupplierOrderLineItemStatus] SOLIS ON SOLISH.[SupplierOrderLineItemStatusId] = SOLIS.[SupplierOrderLineItemStatusId]