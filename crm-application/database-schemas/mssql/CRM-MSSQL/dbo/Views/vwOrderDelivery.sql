CREATE VIEW [dbo].[vwOrderDelivery]
AS

SELECT 
OD.[OrderDeliveryId] AS [Order Delivery Id],
OD.[OrderId] AS [Order Id],
DM.[DeliveryMethod] AS [Delivery Method],
OD.[ShippingDate] AS [Shipping Date],
OD.[DeliveryDate] AS [Delivery Date],
DM.[DeliveryCost] AS [Delivery Cost],
OD.[CreatedTimestamp] AS [Created Timestamp],
OD.[CreatedBy] AS [Created By],
OD.[ModifiedTimestamp] AS [Modified Timestamp],
OD.[ModifiedBy] AS [Modified By]
FROM [dbo].[OrderDelivery] OD
INNER JOIN [dbo].[DeliveryMethod] DM ON OD.[DeliveryMethodId] = DM.[DeliveryMethodId]