CREATE PROCEDURE [dbo].[DeleteDeliveryMethod]
	@deliveryMethodId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[DeliveryMethod]
WHERE [DeliveryMethodId] = @deliveryMethodId