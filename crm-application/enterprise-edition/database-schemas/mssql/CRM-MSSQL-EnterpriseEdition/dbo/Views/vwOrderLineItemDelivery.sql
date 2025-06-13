CREATE VIEW [dbo].[vwOrderLineItemDelivery]
AS

SELECT
OLID.[OrderLineItemDeliveryId] AS [Order Line Item Delivery Id],
OLI.[OrderLineItemId] AS [Order Line Item Id],
P.[ProductId] AS [Product Id],
P.[ProductName] AS [Product Name],
DM.[DeliveryMethod] AS [Delivery Method],
OLID.[ShippingDate] AS [Shipping Date],
OLID.[DeliveryDate] AS [Delivery Date]
FROM [dbo].[OrderLineItemDelivery] OLID
INNER JOIN [dbo].[DeliveryMethod] DM ON OLID.[DeliveryMethodId] = DM.[DeliveryMethodId]
INNER JOIN [dbo].[OrderLineItem] OLI ON OLID.[OrderLineItemId] = OLI.[OrderLineItemId]
INNER JOIN [dbo].[Product] P ON OLI.[ProductId] = P.[ProductId]