CREATE PROCEDURE [dbo].[spUpdateOrderLineItem]
    @orderId UNIQUEIDENTIFIER,
    @orderLineItemId UNIQUEIDENTIFIER,
    @productId UNIQUEIDENTIFIER,
    @promotionCode NVARCHAR(15) = NULL,
    @quantity INT,
    @orderLineItemStatusId UNIQUEIDENTIFIER,
    @taxProfileId UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
        BEGIN TRANSACTION;

        -- Declare variables for product and pricing
        DECLARE @discontinuedError NVARCHAR(100);
        DECLARE @lineItemTotalOriginalValue MONEY;
        DECLARE @percentageDiscountOriginalValue DECIMAL(5,2);
        DECLARE @productIdOriginalValue UNIQUEIDENTIFIER;
        DECLARE @promotionId UNIQUEIDENTIFIER = NULL;
        DECLARE @promotionIdOriginalValue UNIQUEIDENTIFIER = NULL;
        DECLARE @quantityOriginalValue INT;
        DECLARE @taxAmountOriginalValue MONEY;
        DECLARE @taxProfileIdOriginalValue UNIQUEIDENTIFIER;
        DECLARE @unitPrice MONEY;
        DECLARE @unitPriceOriginalValue MONEY;
        DECLARE @unitStockQuantityHeld INT;
        DECLARE @wholesaleReorderFlag BIT;

        -- Check for valid promotion code
        SELECT @promotionId = [Promotion Id]
        FROM [dbo].[vwActivePromotion]
        WHERE [Promotion Code] = @promotionCode;

        SELECT @lineItemTotalOriginalValue = [LineItemTotal],
        @percentageDiscountOriginalValue = [PercentageDiscount],
        @productIdOriginalValue = [ProductId],
        @promotionIdOriginalValue = [PromotionId],
        @quantityOriginalValue = [Quantity],
        @taxAmountOriginalValue = [TaxAmount],
        @taxProfileIdOriginalValue = [TaxProfileId],
        @unitPriceOriginalValue = [UnitPrice]
        FROM [dbo].[OrderLineItem]
        WHERE [OrderLineItemId] = @orderLineItemId;

        -- Retrieve product information
        SELECT 
            @unitPrice = [UnitPrice],
            @unitStockQuantityHeld = [UnitStockQuantityHeld],
            @wholesaleReorderFlag = [WholesaleReorderFlag]
        FROM [dbo].[Product]
        WHERE ProductId = @productId;

        IF @quantityOriginalValue != @quantity OR @productId != @productIdOriginalValue
        BEGIN
            -- Lookup the best discounts for the product based on the quantity
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
            );

            INSERT INTO @bestDiscountResult
            SELECT *
            FROM [dbo].[fnLookupPotentialOrderLineItemDiscount](
                @productId,
                @quantity
            );

            DECLARE @percentageDiscount DECIMAL(5,2);
            SELECT @percentageDiscount = MAX([Discount]) FROM @bestDiscountResult;

            -- Calculate the unit price after discount
            DECLARE @orderLineItemUnitPrice MONEY;
            SET @orderLineItemUnitPrice = 
                CASE 
                    WHEN @productId = @productIdOriginalValue THEN @unitPriceOriginalValue
                    ELSE @unitPrice
                END * (1 - @percentageDiscount);

            -- Calculate the tax amount
            DECLARE @taxAmount MONEY;
            SELECT @taxAmount = ((@orderLineItemUnitPrice * @quantity) * [TaxRate])
            FROM [dbo].[TaxProfile]
            WHERE [TaxProfileId] = @taxProfileId;

            -- Calculate the total line item price
            DECLARE @lineItemTotal MONEY;
            SET @lineItemTotal = (@orderLineItemUnitPrice * @quantity + @taxAmount);

            -- Check if the stock will fall below zero
            IF @unitStockQuantityHeld - @quantity < 0
            BEGIN
                -- If the product is discontinued, raise an error
                IF @wholesaleReorderFlag = 0
                BEGIN
                    SET @discontinuedError = CONCAT('The product is discontinued. Maximum allowed quantity is ', @unitStockQuantityHeld, ' units');
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

            -- If product or quantity changes, adjust stock accordingly
            IF @quantityOriginalValue != @quantity OR @productId != @productIdOriginalValue
            BEGIN
                -- Revert stock for original product
                UPDATE [dbo].[Product]
                SET UnitStockQuantityHeld = UnitStockQuantityHeld + @quantityOriginalValue
                WHERE ProductId = @productIdOriginalValue;

                -- Deduct stock for new product
                UPDATE [dbo].[Product]
                SET UnitStockQuantityHeld = UnitStockQuantityHeld - @quantity
                WHERE ProductId = @productId;
            END
        END

        -- Update the existing OrderLineItem record
        -- Build dynamic SQL to update only changed columns
        DECLARE @sql NVARCHAR(MAX) = N'UPDATE [dbo].[OrderLineItem] SET ';
        DECLARE @set NVARCHAR(MAX) = N'';
        DECLARE @params NVARCHAR(MAX) = N'@orderLineItemId UNIQUEIDENTIFIER';

        -- ProductId
        IF @productIdOriginalValue != @productId
        BEGIN
            SET @set += '[ProductId] = @productId, ';
            SET @params += N', @productId UNIQUEIDENTIFIER';
        END

        -- Quantity
        IF @quantityOriginalValue != @quantity
        BEGIN
            SET @set += '[Quantity] = @quantity, ';
            SET @params += N', @quantity INT';
        END

        -- FinalPrice
        IF @unitPriceOriginalValue != @orderLineItemUnitPrice
        BEGIN
            SET @set += '[FinalPrice] = @orderLineItemUnitPrice, ';
            SET @params += N', @orderLineItemUnitPrice MONEY';
        END

        -- LineItemTotal
        IF @lineItemTotal IS NOT NULL AND @lineItemTotal != @lineItemTotalOriginalValue
        BEGIN
            SET @set += '[LineItemTotal] = @lineItemTotal, ';
            SET @params += N', @lineItemTotal MONEY';
        END

        -- TaxAmount
        IF @taxAmount IS NOT NULL AND @taxAmount != @taxAmountOriginalValue
        BEGIN
            SET @set += '[TaxAmount] = @taxAmount, ';
            SET @params += N', @taxAmount MONEY';
        END

        -- PercentageDiscount
        IF @percentageDiscount IS NOT NULL AND @percentageDiscount != @percentageDiscountOriginalValue
        BEGIN
            SET @set += '[PercentageDiscount] = @percentageDiscount, ';
            SET @params += N', @percentageDiscount DECIMAL(5,2)';
        END

        -- PromotionId
        IF @promotionIdOriginalValue != @promotionId
        BEGIN
            SET @set += '[PromotionId] = @promotionId, ';
            SET @params += N', @promotionId UNIQUEIDENTIFIER';
        END

        -- Remove trailing comma and space
        IF LEN(@set) > 0
        BEGIN
            SET @set = LEFT(@set, LEN(@set) - 2);
            SET @sql += @set + N' WHERE [OrderLineItemId] = @orderLineItemId;';

            EXEC sp_executesql @sql, @params,
                @orderLineItemId = @orderLineItemId,
                @productId = @productId,
                @quantity = @quantity,
                @orderLineItemUnitPrice = @orderLineItemUnitPrice,
                @lineItemTotal = @lineItemTotal,
                @taxAmount = @taxAmount,
                @percentageDiscount = @percentageDiscount,
                @promotionId = @promotionId;
        END

        -- Update status history
        EXEC [dbo].[spCreateOrderLineItemStatusHistory]
            @orderLineItemId = @orderLineItemId,
            @orderLineItemStatusId = @orderLineItemStatusId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        THROW @ErrorSeverity, @ErrorMessage, @ErrorState;
    END CATCH
END