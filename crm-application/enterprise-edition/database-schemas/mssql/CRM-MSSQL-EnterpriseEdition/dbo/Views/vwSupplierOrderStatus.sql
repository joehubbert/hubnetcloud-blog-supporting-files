CREATE VIEW [dbo].[vwSupplierOrderStatus]
AS

SELECT
[SupplierOrderStatusId]	AS [Supplier Order Status Id],
[SupplierOrderStatus] AS [Supplier Order Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[SupplierOrderStatus]