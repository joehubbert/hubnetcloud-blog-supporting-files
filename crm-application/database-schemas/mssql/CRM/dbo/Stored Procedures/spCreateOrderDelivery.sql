CREATE PROCEDURE [dbo].[spCreateOrderDelivery]
	@deliveryDate DATE,
	@deliveryMethodId UNIQUEIDENTIFIER,
	@orderId UNIQUEIDENTIFIER

AS

DECLARE @shippingDate DATE
SET @shippingDate = [dbo].[fnCalculateShippingDate](@deliveryDate, @deliveryMethodId)

CREATE TABLE #OrderDeliveryTemp
(
	[DeliveryDate] DATE,
	[DeliveryMethodId] UNIQUEIDENTIFIER,
	[OrderId] UNIQUEIDENTIFIER,
	[ShippingDate] DATE
)

INSERT INTO #OrderDeliveryTemp
(
	[DeliveryDate],
	[DeliveryMethodId],
	[OrderId],
	[ShippingDate]
)
VALUES
(
	@deliveryDate,
	@deliveryMethodId,
	@orderId,
	@shippingDate
)

IF EXISTS
(
SELECT *
FROM [dbo].[OrderDelivery] OD
INNER JOIN #OrderDeliveryTemp ODT ON OD.[OrderId] = ODT.[OrderId]
WHERE OD.[OrderId] = ODT.[OrderId]
)
THROW 50000, 'Order Delivery already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[OrderDelivery] AS target
USING #OrderDeliveryTemp AS source
ON target.[OrderId] = source.[OrderId]
WHEN NOT MATCHED THEN
INSERT
(
	[DeliveryDate],
	[DeliveryMethodId],
	[OrderId],
	[ShippingDate]
)
VALUES
(
	source.[DeliveryDate],
	source.[DeliveryMethodId],
	source.[OrderId],
	source.[ShippingDate]
);

DROP TABLE #OrderDeliveryTemp;