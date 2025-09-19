CREATE PROCEDURE [dbo].[spCreateOrderLineItemDelivery]
	@deliveryDate DATE,
	@deliveryMethodId UNIQUEIDENTIFIER,
	@orderLineItemId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			DECLARE @shippingDate DATE
			SET @shippingDate = [dbo].[fnCalculateShippingDate](@deliveryDate, @deliveryMethodId)

			INSERT INTO [dbo].[OrderLineItemDelivery]
			(
				[OrderLineItemId],
				[DeliveryMethodId],
				[DeliveryDate],
				[ShippingDate]
			)
			VALUES
			(
				@orderLineItemId,
				@deliveryMethodId,
				@deliveryDate,
				@shippingDate
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END