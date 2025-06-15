CREATE VIEW [dbo].[vwSupplierOrderLineItem]
AS

SELECT
SOLI.[SupplierOrderId] AS [Supplier Order Id],
SOLI.[SupplierOrderLineItemId] AS [Supplier Order Line Item Id],
SOLIS.[SupplierOrderLineItemStatusId] AS [Supplier Order Line Item Status Id],
SOLIS.[SupplierOrderLineItemStatus] AS [Supplier Order Line Item Status],
P.[ProductId] AS [Product Id],
P.[ProductName] AS [Product Name],
SOLI.[WholesalePricePerUnit] AS [Wholesale Price Per Unit],
SOLI.[WholesaleCartonQuantity] AS [Wholesale Carton Quantity],
P.[WholesaleUnitQuantityPerCarton] AS [Wholesale Unit Quantity Per Carton],
SOLI.[LineItemTotal] AS [Total Line Item Price],
SOLI.[CreatedTimestampUTC] AS [Created Timestamp UTC],
SOLI.[CreatedBy] AS [Created By],
SOLI.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
SOLI.[ModifiedBy] AS [Modified By]
FROM [dbo].[SupplierOrderLineItem] SOLI
INNER JOIN [dbo].[Product] P ON SOLI.[ProductId] = P.[ProductId]
INNER JOIN [dbo].[SupplierOrderLineItemStatusHistory] SOLISH ON SOLI.[SupplierOrderLineItemId] = SOLISH.[SupplierOrderLineItemId]
INNER JOIN [dbo].[SupplierOrderLineItemStatus] SOLIS ON SOLISH.[SupplierOrderLineItemStatusId] = SOLIS.[SupplierOrderLineItemStatusId]
GROUP BY
SOLI.[SupplierOrderId],
SOLI.[SupplierOrderLineItemId],
SOLIS.[SupplierOrderLineItemStatusId],
SOLIS.[SupplierOrderLineItemStatus],
P.[ProductId],
P.[ProductName],
SOLI.[WholesalePricePerUnit],
SOLI.[WholesaleCartonQuantity],
P.[WholesaleUnitQuantityPerCarton],
SOLI.[LineItemTotal],
SOLI.[CreatedTimestampUTC],
SOLI.[CreatedBy],
SOLI.[ModifiedTimestampUTC],
SOLI.[ModifiedBy]