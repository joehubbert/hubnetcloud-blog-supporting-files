CREATE VIEW [dbo].[vwSupplierOrderStatusHistory]
AS

SELECT
SOSH.[SupplierOrderStatusHistoryId] AS [Supplier Order Status History Id],
SOSH.[SupplierOrderId] AS [Supplier Order Id],
SOS.[SupplierOrderStatusId] AS [Supplier Order Status Id],
SOS.[SupplierOrderStatus] AS [Supplier Order Status],
SOSH.[CreatedTimestamp] AS [Created Timestamp],
SOSH.[CreatedBy] AS [Created By],
SOSH.[ModifiedTimestamp] AS [Modified Timestamp],
SOSH.[ModifiedBy] AS [Modified By]
FROM [dbo].[SupplierOrderStatusHistory] SOSH
INNER JOIN [dbo].[SupplierOrderStatus] SOS ON SOSH.[SupplierOrderStatusId] = SOS.[SupplierOrderStatusId]