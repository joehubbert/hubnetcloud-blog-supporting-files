CREATE PROCEDURE [dbo].[spUpdateDeliveryMethod]
	@deliveryMethod NVARCHAR(50),
	@deliveryMethodId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[DeliveryMethod]
SET 
	[DeliveryMethod] = @deliveryMethod
WHERE [DeliveryMethodId] = @deliveryMethodId