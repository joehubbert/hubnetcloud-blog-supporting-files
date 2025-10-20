CREATE VIEW [dbo].[vwSupplierOrderLineItemStatus]
AS

SELECT
[SupplierOrderLineItemStatusId]	AS [Supplier Order Line Item Status Id],
[SupplierOrderLineItemStatus] AS [Supplier Order Line Item Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[SupplierOrderLineItemStatus]