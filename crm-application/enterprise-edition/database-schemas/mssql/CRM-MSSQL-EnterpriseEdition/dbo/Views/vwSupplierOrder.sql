CREATE VIEW [dbo].[vwSupplierOrder]
AS

SELECT
    SO.[SupplierOrderId] AS [Supplier Order Id],
    SO.[InternalReference] AS [Supplier Order Internal Reference],
    S.[SupplierId] AS [Supplier Id],
    S.[SupplierName] AS [Supplier Name], 
    SOS.[SupplierOrderStatus] AS [Supplier Order Status],
    PM.[PaymentMethod] AS [Payment Method],
    VSOV.[TotalOrderValue] AS [Total Order Value],
    CUR.[CurrencyCode] AS [Currency Code],
    SO.[CreatedTimestamp] AS [Created Timestamp],
    SO.[CreatedBy] AS [Created By],
    SO.[ModifiedTimestamp] AS [Modified Timestamp],
    SO.[ModifiedBy] AS [Modified By]
FROM [dbo].[SupplierOrder] SO
INNER JOIN [dbo].[Supplier] S ON SO.[SupplierId] = S.[SupplierId]
INNER JOIN [dbo].[Currency] CUR ON S.[PaymentCurrencyId] = CUR.[CurrencyId]
INNER JOIN [dbo].[SupplierOrderPayment] SOP ON SO.[SupplierOrderId] = SOP.[SupplierOrderId]
INNER JOIN (
    SELECT SOSH1.[SupplierOrderId], SOS.[SupplierOrderStatus]
    FROM [dbo].[SupplierOrderStatusHistory] SOSH1
    INNER JOIN (
        SELECT [SupplierOrderId], MAX([CreatedTimestamp]) AS [MaxCreatedTimestamp]
        FROM [dbo].[SupplierOrderStatusHistory]
        GROUP BY [SupplierOrderId]
    ) SOSH2 ON SOSH1.[SupplierOrderId] = SOSH2.[SupplierOrderId] AND SOSH1.[CreatedTimestamp] = SOSH2.[MaxCreatedTimestamp]
    INNER JOIN [dbo].[SupplierOrderStatus] SOS ON SOSH1.[SupplierOrderStatusId] = SOS.[SupplierOrderStatusId]
) SOS ON SO.[SupplierOrderId] = SOS.[SupplierOrderId]
INNER JOIN [dbo].[PaymentMethod] PM ON SOP.[PaymentMethodId] = PM.[PaymentMethodId]
INNER JOIN [dbo].[vwSupplierOrderValue] VSOV ON SO.[SupplierOrderId] = VSOV.[SupplierOrderId]