CREATE VIEW [dbo].[vwSupplierOrderValue]
AS

SELECT 
SO.[SupplierOrderId],
SO.[SupplierId],
SUM(SOLI.[LineItemTotal]) AS [TotalOrderValue]
FROM [dbo].[SupplierOrder] SO
INNER JOIN [dbo].[SupplierOrderLineItem] SOLI ON SO.[SupplierOrderId] = SOLI.[SupplierOrderId]
GROUP BY SO.[SupplierOrderId], SO.[SupplierId]