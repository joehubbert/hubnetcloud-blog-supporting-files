CREATE PROCEDURE [dbo].[spCreateOrderLineItem]
	@orderId UNIQUEIDENTIFIER,
	@orderLineItemId UNIQUEIDENTIFIER OUTPUT,
	@productId UNIQUEIDENTIFIER,
	@promotionCode NVARCHAR(15) = NULL,
	@quantity INT,
	@taxProfileId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

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
			DECLARE @promotionId UNIQUEIDENTIFIER = NULL
			DECLARE @unitPrice MONEY
			DECLARE @unitStockQuantityHeld INT
			DECLARE @wholesaleReorderFlag BIT

			--Check for valid promotion code			
			SELECT @promotionId = [Promotion Id] FROM [dbo].[vwActivePromotion] WHERE [Promotion Code] = @promotionCode;

			-- Retrieve product information
			SELECT 
				@unitPrice = [UnitPrice],
				@unitStockQuantityHeld = [UnitStockQuantityHeld],
				@wholesaleReorderFlag = [WholesaleReorderFlag]
			FROM [dbo].[Product]
			WHERE ProductId = @productId;

			--Lookup the best discounts for the product based on the quantity
            DECLARE @bestDiscountResult TABLE
            (
            [Discount] DECIMAL(5,2) NOT NULL,
            [OriginalQuantity] INT NOT NULL,
            [SuggestedQuantity] INT NOT NULL,
            [UnitPrice] MONEY NOT NULL,
            [FinalPrice] MONEY NOT NULL,
            [OriginalLineItemTotal] MONEY NOT NULL,
            [FinalLineItemTotal] MONEY NOT NULL,
            [PromotionCode] NVARCHAR(15) NOT NULL,
            [PromotionType] NVARCHAR(50) NOT NULL,
            [PromotionTypeId] UNIQUEIDENTIFIER NULL
            )

            INSERT INTO @bestDiscountResult
            SELECT *
            FROM [dbo].[fnLookupPotentialOrderLineItemDiscount](
            @productId,
            @quantity
            );

			DECLARE @percentageDiscount DECIMAL(5,2)
			SELECT @percentageDiscount = MAX([Discount]) FROM @bestDiscountResult

			-- Calculate the unit price after discount
			DECLARE @orderLineItemUnitPrice MONEY
			SET @orderLineItemUnitPrice = @unitPrice * (1 - @percentageDiscount)

			-- Calculate the tax amount
			DECLARE @taxAmount MONEY
			SELECT @taxAmount = ((@orderLineItemUnitPrice * @quantity) * [TaxRate]) FROM [dbo].[TaxProfile] WHERE [TaxProfileId] = @taxProfileId;

			-- Calculate the total line item price
			DECLARE @lineItemTotal MONEY
			SET @lineItemTotal = (@orderLineItemUnitPrice * @quantity + @taxAmount)

			-- Check if the stock will fall below zero
			IF @unitStockQuantityHeld - @quantity < 0
			BEGIN
				-- If the product is discontinued, raise an error
				IF @wholesaleReorderFlag = 0
				BEGIN
					SET @discontinuedError = CONCAT('The product is discontinued. Maximum allowed quantity is ', @unitStockQuantityHeld , 'units');
					THROW 50001, @discontinuedError, 1;
				END
				-- If the product is on backorder, display a message
				ELSE IF @wholesaleReorderFlag = 1
				BEGIN
					-- Adjust @quantity to the maximum allowed that will take stock to 0
					SET @quantity = @unitStockQuantityHeld;
					PRINT 'Order quantity adjusted to available stock. Any remaining items will be placed on backorder and will need to be fulfilled with a new order at a later date.';
				END
			END
			-- Deduct the quantity from UnitStockQuantityHeld in the Product table
			UPDATE [dbo].[Product]
			SET UnitStockQuantityHeld = UnitStockQuantityHeld - @quantity
			WHERE ProductId = @productId;

			CREATE TABLE #OrderLineItemTempOutput
			(
				[OrderLineItemId] UNIQUEIDENTIFIER NOT NULL
			);

			-- Insert the new order line item into the OrderLineItem table
            INSERT INTO [dbo].[OrderLineItem]
            (
            [OrderId],
            [ProductId],
            [Quantity],
            [UnitPrice],
            [FinalPrice],
            [LineItemTotal],
            [TaxProfileId],
            [TaxAmount],
            [PercentageDiscount],
            [PromotionId]
            )
            OUTPUT INSERTED.[OrderLineItemId] INTO #OrderLineItemTempOutput
            SELECT
            [OrderId],
            [ProductId],
            @quantity,
            @unitPrice,
            @orderLineItemUnitPrice,
            @lineItemTotal,
            [TaxProfileId],
            @taxAmount,
            @percentageDiscount,
            @promotionId
            FROM #OrderLineItemTemp

			SET @orderLineItemId = (SELECT [OrderLineItemId] FROM #OrderLineItemTempOutput)

			DECLARE @orderLineItemStatusId UNIQUEIDENTIFIER
			SELECT @orderLineItemStatusId = [OrderLineItemStatusId] FROM [dbo].[OrderLineItemStatus] WHERE [OrderLineItemStatus] = 'Pending'

			EXEC [dbo].[spCreateOrderLineItemStatusHistory]
				@orderLineItemId = @orderLineItemId,
				@orderLineItemStatusId = @orderLineItemStatusId

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
			DROP TABLE #OrderLineItemTempOutput

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END