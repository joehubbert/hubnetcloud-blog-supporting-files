CREATE VIEW [dbo].[vwSupplierOrderLineItemStatusHistory]
AS

SELECT
SOLISH.[SupplierOrderLineItemStatusHistoryId] AS [Supplier Order Line Item Status History Id],
SOLISH.[SupplierOrderLineItemId] AS [Supplier Order Line Item Id],
SOLIS.[SupplierOrderLineItemStatusId] AS [Supplier Order Line Item Status Id],
SOLIS.[SupplierOrderLineItemStatus] AS [Supplier Order Line Item Status],
SOLISH.[CreatedTimestamp] AS [Created Timestamp],
SOLISH.[CreatedBy] AS [Created By],
SOLISH.[ModifiedTimestamp] AS [Modified Timestamp],
SOLISH.[ModifiedBy] [Modified By]
FROM [dbo].[SupplierOrderLineItemStatusHistory] SOLISH
INNER JOIN [dbo].[SupplierOrderLineItemStatus] SOLIS ON SOLISH.[SupplierOrderLineItemStatusId] = SOLIS.[SupplierOrderLineItemStatusId]