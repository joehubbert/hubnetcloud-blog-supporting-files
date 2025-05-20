CREATE PROCEDURE [dbo].[spUpdateOrder]
	@currencyId UNIQUEIDENTIFIER,
	@orderId UNIQUEIDENTIFIER,
	@orderStatusId UNIQUEIDENTIFIER,
	@paymentMethodId UNIQUEIDENTIFIER
AS

DECLARE @orderStatus NVARCHAR(50)
SET @orderStatus = (SELECT [OrderStatus] FROM [dbo].[OrderStatus] WHERE [OrderStatusId] = @orderStatusId)

BEGIN TRY
	BEGIN TRANSACTION
	IF @orderStatus = 'Cancelled'
	BEGIN

	DECLARE @orderLineItemStatusId UNIQUEIDENTIFIER
	SET @orderLineItemStatusId = (SELECT [OrderLineItemStatusId] FROM [dbo].[OrderLineItemStatus] WHERE [OrderLineItemStatus] = 'Cancelled')
	-- Update OrderLineItem status to 'Cancelled'
			UPDATE [dbo].[OrderLineItem]
			SET [OrderLineItemStatusId] = @orderLineItemStatusId
			WHERE [OrderId] = @orderId

	-- Adjust quantities in the Product table
			UPDATE P
			SET P.[UnitStockQuantityHeld] = P.[UnitStockQuantityHeld] + OLI.[Quantity]
			FROM [dbo].[Product] P
			INNER JOIN [dbo].[OrderLineItem] OLI ON P.[ProductId] = OLI.[ProductId]
			WHERE OLI.[OrderId] = @orderId

	-- Update Order status
			UPDATE [dbo].[Order]
			SET [OrderStatusId] = @orderStatusId
			WHERE [OrderId] = @orderId
	END
	ELSE
	BEGIN
		UPDATE [dbo].[Order]
		SET
			[CurrencyId] = @currencyId,
			[OrderStatusId] = @orderStatusId,
			[PaymentMethodId] = @paymentMethodId
		WHERE [OrderId] = @orderId
	END

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
		-- Handle any errors that occur during the transaction
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION

		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE();

		-- Rethrow the error to the caller
		THROW @ErrorSeverity, @ErrorMessage, @ErrorState;
END CATCH