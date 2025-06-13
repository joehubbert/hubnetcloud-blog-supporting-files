CREATE PROCEDURE [dbo].[spUpdateOrderLineItemDelivery]
	@deliveryDate DATE,
	@deliveryMethodId UNIQUEIDENTIFIER,
	@orderLineItemDeliveryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			DECLARE @shippingDate DATE
			SET @shippingDate = [dbo].[fnCalculateShippingDate](@deliveryDate, @deliveryMethodId)

			UPDATE [dbo].[OrderLineItemDelivery]
			SET
				[DeliveryMethodId] = @deliveryMethodId,
				[DeliveryDate] = @deliveryDate,
				[ShippingDate] = @shippingDate
			WHERE [OrderLineItemDeliveryId] = @orderLineItemDeliveryId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END