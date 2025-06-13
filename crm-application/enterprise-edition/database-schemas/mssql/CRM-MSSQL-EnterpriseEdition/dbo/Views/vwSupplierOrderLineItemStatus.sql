CREATE VIEW [dbo].[vwSupplierOrderLineItemStatus]
AS

SELECT
[SupplierOrderLineItemStatusId]	AS [Supplier Order Line Item Status Id],
[SupplierOrderLineItemStatus] AS [Supplier Order Line Item Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[SupplierOrderLineItemStatus]