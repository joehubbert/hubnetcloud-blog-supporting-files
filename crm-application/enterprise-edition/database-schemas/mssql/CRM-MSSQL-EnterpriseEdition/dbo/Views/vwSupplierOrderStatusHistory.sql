CREATE VIEW [dbo].[vwSupplierOrderStatusHistory]
AS

SELECT
SOSH.[SupplierOrderStatusHistoryId] AS [Supplier Order Status History Id],
SOSH.[SupplierOrderId] AS [Supplier Order Id],
SOS.[SupplierOrderStatusId] AS [Supplier Order Status Id],
SOS.[SupplierOrderStatus] AS [Supplier Order Status],
SOSH.[CreatedTimestampUTC] AS [Created Timestamp UTC],
SOSH.[CreatedBy] AS [Created By],
SOSH.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
SOSH.[ModifiedBy] AS [Modified By],
SOSH.[RowVersion] AS [Row Version]
FROM [dbo].[SupplierOrderStatusHistory] SOSH
INNER JOIN [dbo].[SupplierOrderStatus] SOS ON SOSH.[SupplierOrderStatusId] = SOS.[SupplierOrderStatusId]