CREATE PROCEDURE [dbo].[spUpdateOrderDelivery]
	@deliveryDate DATE,
	@deliveryMethodId UNIQUEIDENTIFIER,
	@orderDeliveryId UNIQUEIDENTIFIER
AS

DECLARE @shippingDate DATE
SET @shippingDate = [dbo].[fnCalculateShippingDate](@deliveryDate, @deliveryMethodId)

UPDATE [dbo].[OrderDelivery]
SET
	[DeliveryDate] = @deliveryDate,
	[DeliveryMethodId] = @deliveryMethodId,
	[ShippingDate] = @shippingDate
WHERE [OrderDeliveryId] = @orderDeliveryId