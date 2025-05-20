CREATE PROCEDURE [dbo].[spUpdateDeliveryMethod]
	@activeStatus BIT,
	@deliveryMethod NVARCHAR(50),
	@deliveryMethodId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[DeliveryMethod]
SET 
	[ActiveStatus] = @activeStatus,
	[DeliveryMethod] = @deliveryMethod
WHERE [DeliveryMethodId] = @deliveryMethodId