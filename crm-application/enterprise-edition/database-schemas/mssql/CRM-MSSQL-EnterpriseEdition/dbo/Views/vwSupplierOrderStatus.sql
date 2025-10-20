CREATE VIEW [dbo].[vwSupplierOrderStatus]
AS

SELECT
[SupplierOrderStatusId]	AS [Supplier Order Status Id],
[SupplierOrderStatus] AS [Supplier Order Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[SupplierOrderStatus]