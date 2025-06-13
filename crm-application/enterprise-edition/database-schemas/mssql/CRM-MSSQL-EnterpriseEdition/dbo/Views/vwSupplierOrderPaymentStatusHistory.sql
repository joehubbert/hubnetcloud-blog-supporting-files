CREATE VIEW [dbo].[vwSupplierOrderPaymentStatusHistory]
AS

SELECT
SOPSH.[SupplierOrderPaymentStatusHistoryId] AS [Supplier Order Payment Status History Id],
SOP.[SupplierOrderId] AS [Supplier Order Id],
SOP.[SupplierOrderPaymentId] AS [Supplier Order Payment Id],
SOPS.[SupplierOrderPaymentStatusId] AS [Supplier Order Payment Status Id],
SOPS.[SupplierOrderPaymentStatus] AS [Supplier Order Payment Status]
FROM [dbo].[SupplierOrderPaymentStatusHistory] SOPSH
INNER JOIN [dbo].[SupplierOrderPayment] SOP ON SOPSH.[SupplierOrderPaymentId] = SOP.[SupplierOrderPaymentId]
INNER JOIN [dbo].[SupplierOrderPaymentStatus] SOPS ON SOPSH.[SupplierOrderPaymentStatusId] = SOPS.[SupplierOrderPaymentStatusId]