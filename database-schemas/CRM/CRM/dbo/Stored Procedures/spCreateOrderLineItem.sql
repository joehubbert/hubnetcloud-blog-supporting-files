CREATE PROCEDURE [dbo].[spCreateOrderLineItem]
	@orderId UNIQUEIDENTIFIER,
	@productId UNIQUEIDENTIFIER,
	@quantity INT,
	@taxProfileId UNIQUEIDENTIFIER
AS

CREATE TABLE #OrderLineItemTemp
(
	[OrderId] UNIQUEIDENTIFIER NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[Quantity] INT NOT NULL,
	[TaxProfileId] UNIQUEIDENTIFIER NOT NULL
)

INSERT INTO #OrderLineItemTemp
(
	[OrderId],
	[ProductId],
	[Quantity],
	[TaxProfileId]
)
VALUES
(
	@orderId,
	@productId,
	@quantity,
	@taxProfileId
)

IF EXISTS
(
SELECT *
FROM [dbo].[OrderLineItem] OLI
INNER JOIN #OrderLineItemTemp OLIT ON OLI.[OrderId] = OLIT.[OrderId]
AND OLI.[ProductId] = OLIT.[ProductId]
WHERE OLI.[OrderId] = OLIT.[OrderId]
AND OLI.[ProductId] = OLIT.[ProductId]
)
THROW 50000, 'Order Line Item already exists, please update the existing record.', 1;
ELSE
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
-- Deduct the quantity from UnitStockQuantityHeld in the Product table
UPDATE [dbo].[Product]
SET UnitStockQuantityHeld = UnitStockQuantityHeld - @quantity
WHERE ProductId = @productId;

-- Insert the new order line item into the OrderLineItem table
INSERT INTO [dbo].[OrderLineItem]
(
	[OrderId],
	[OrderLineItemStatusId],
	[ProductId],
	[Quantity],
	[TaxProfileId]
)
SELECT
	[OrderId],
	(SELECT [OrderLineItemStatus] FROM [dbo].[OrderLineItemStatus] WHERE [OrderLineItemStatus] = 'Pending'),
	[ProductId],
	[Quantity],
	[TaxProfileId]
FROM #OrderLineItemTemp
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
THROW @ErrorSeverity, @ErrorMessage, @ErrorState
END CATCH

DROP TABLE #OrderLineItemTemp