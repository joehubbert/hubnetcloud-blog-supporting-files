CREATE VIEW [dbo].[vwSupplierOrderPaymentStatusHistory]
AS

SELECT
SOPSH.[SupplierOrderPaymentStatusHistoryId] AS [Supplier Order Payment Status History Id],
SOP.[SupplierOrderId] AS [Supplier Order Id],
SOP.[SupplierOrderPaymentId] AS [Supplier Order Payment Id],
SOPS.[SupplierOrderPaymentStatusId] AS [Supplier Order Payment Status Id],
SOPS.[SupplierOrderPaymentStatus] AS [Supplier Order Payment Status],
SOPSH.[CreatedTimestampUTC] AS [Created Timestamp UTC],
SOPSH.[CreatedBy] AS [Created By],
SOPSH.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
SOPSH.[ModifiedBy] [Modified By],
SOPSH.[RowVersion] AS [Row Version]
FROM [dbo].[SupplierOrderPaymentStatusHistory] SOPSH
INNER JOIN [dbo].[SupplierOrderPayment] SOP ON SOPSH.[SupplierOrderPaymentId] = SOP.[SupplierOrderPaymentId]
INNER JOIN [dbo].[SupplierOrderPaymentStatus] SOPS ON SOPSH.[SupplierOrderPaymentStatusId] = SOPS.[SupplierOrderPaymentStatusId]