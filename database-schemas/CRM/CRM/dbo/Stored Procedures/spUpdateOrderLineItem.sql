CREATE PROCEDURE [dbo].[spUpdateOrderLineItem]
	@orderId UNIQUEIDENTIFIER,
	@orderLineItemId UNIQUEIDENTIFIER,
	@orderLineItemStatusId UNIQUEIDENTIFIER,
	@productId UNIQUEIDENTIFIER,
	@quantity INT
AS

BEGIN TRY
-- Declare variables to hold product information
DECLARE @discontinuedError NVARCHAR(100)
DECLARE @unitStockQuantityHeld INT
DECLARE @wholesaleReorderFlag BIT

-- Retrieve product information
SELECT 
	@unitStockQuantityHeld = [UnitStockQuantityHeld],
	@wholesaleReorderFlag = [WholesaleReorderFlag]
FROM [dbo].[Product]
WHERE ProductId = @productId;

-- Check if the stock will fall below zero
IF @unitStockQuantityHeld - @quantity < 0
BEGIN
	-- If the product is discontinued, raise an error
	IF @wholesaleReorderFlag = 0
	BEGIN
		SET @discontinuedError = CONCAT('The product is discontinued. Maximum allowed quantity is ', @unitStockQuantityHeld - @quantity, 'units');
		THROW 50001, @discontinuedError, 1;
	END
	-- If the product is on backorder, display a message
	ELSE IF @wholesaleReorderFlag = 1
	BEGIN
		PRINT 'Order will reduce stock to 0 but any remaining items will be placed on backorder and fulfilled at a later date.';
	END
END
-- Adjust the quantity from UnitStockQuantityHeld in the Product table
UPDATE [dbo].[Product]
SET UnitStockQuantityHeld = UnitStockQuantityHeld - @quantity
WHERE ProductId = @productId;

-- Update the existing OrderLineItem record
UPDATE [dbo].[OrderLineItem]
SET
	[OrderLineItemStatusId] = @orderLineItemStatusId,
	[ProductId] = @productId,
	[Quantity] = @quantity
WHERE OrderLineItemId = @orderLineItemId;
END TRY
BEGIN CATCH
-- Handle any errors that occur during the transaction
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