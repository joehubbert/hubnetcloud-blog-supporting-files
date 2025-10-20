CREATE PROCEDURE [dbo].[spCreateOrderLineItem]
    @orderId UNIQUEIDENTIFIER,
    @orderLineItemId UNIQUEIDENTIFIER OUTPUT,
    @orderTypeId UNIQUEIDENTIFIER,
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
        );

        INSERT INTO #OrderLineItemTemp ([OrderId], [ProductId], [Quantity], [TaxProfileId])
        VALUES (@orderId, @productId, @quantity, @taxProfileId);

        IF EXISTS 
        (
            SELECT 1
            FROM [dbo].[OrderLineItem] OLI
            INNER JOIN #OrderLineItemTemp OLIT 
                ON OLI.[OrderId] = OLIT.[OrderId]
                AND OLI.[ProductId] = OLIT.[ProductId]
        )
        BEGIN TRY
            THROW 50000, 'Order Line Item already exists, please update the existing record.', 1;
        END TRY
        BEGIN CATCH
            THROW;
        END CATCH

        DECLARE @orderType NVARCHAR(50);
        SELECT @orderType = [OrderType] FROM [dbo].[OrderType] WHERE [OrderTypeId] = @orderTypeId;

        IF @orderType = 'Final'
        BEGIN
            DECLARE 
                @discontinuedError NVARCHAR(100),
                @promotionId UNIQUEIDENTIFIER = NULL,
                @unitPrice MONEY,
                @unitStockQuantityHeld INT,
                @wholesaleReorderFlag BIT;

            SELECT @promotionId = [Promotion Id] 
            FROM [dbo].[vwActivePromotion] 
            WHERE [Promotion Code] = @promotionCode;

            SELECT 
                @unitPrice = [UnitPrice],
                @unitStockQuantityHeld = [UnitStockQuantityHeld],
                @wholesaleReorderFlag = [WholesaleReorderFlag]
            FROM [dbo].[Product]
            WHERE [ProductId] = @productId;

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
            FROM [dbo].[fnLookupPotentialOrderLineItemDiscount](@productId, @quantity);

            DECLARE @percentageDiscount DECIMAL(5,2);
            SELECT @percentageDiscount = MAX([Discount]) FROM @bestDiscountResult;

            DECLARE 
                @orderLineItemUnitPrice MONEY,
                @taxAmount MONEY,
                @lineItemTotal MONEY;

            SET @orderLineItemUnitPrice = @unitPrice * (1 - ISNULL(@percentageDiscount, 0));

            SELECT @taxAmount = ((@orderLineItemUnitPrice * @quantity) * [TaxRate])
            FROM [dbo].[TaxProfile]
            WHERE [TaxProfileId] = @taxProfileId;

            SET @lineItemTotal = (@orderLineItemUnitPrice * @quantity) + @taxAmount;

            IF @unitStockQuantityHeld - @quantity < 0
            BEGIN
                IF @wholesaleReorderFlag = 0
                BEGIN
                    SET @discontinuedError = CONCAT('The product is discontinued. Maximum allowed quantity is ', @unitStockQuantityHeld, ' units');
                    THROW 50001, @discontinuedError, 1;
                END
                ELSE IF @wholesaleReorderFlag = 1
                BEGIN
                    SET @quantity = @unitStockQuantityHeld;
                    RAISERROR('Order quantity adjusted to available stock. Remaining items are on backorder.', 0, 1);
                END
                BEGIN
                UPDATE [dbo].[Product]
                SET UnitStockQuantityHeld = UnitStockQuantityHeld - @quantity
                WHERE ProductId = @productId;
                END
            END

            CREATE TABLE #OrderLineItemTempOutput ([OrderLineItemId] UNIQUEIDENTIFIER NOT NULL);

            INSERT INTO [dbo].[OrderLineItem]
            (
                [OrderId], [ProductId], [Quantity], [UnitPrice], [FinalPrice],
                [LineItemTotal], [TaxProfileId], [TaxAmount],
                [PercentageDiscount], [PromotionId]
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
            FROM #OrderLineItemTemp;

            SET @orderLineItemId = (SELECT TOP 1 [OrderLineItemId] FROM #OrderLineItemTempOutput);

            DECLARE @orderLineItemStatusId UNIQUEIDENTIFIER;
            SELECT @orderLineItemStatusId = [OrderLineItemStatusId] 
            FROM [dbo].[OrderLineItemStatus] 
            WHERE [OrderLineItemStatus] = 'Pending';

            EXEC [dbo].[spCreateOrderLineItemStatusHistory]
                @orderLineItemId = @orderLineItemId,
                @orderLineItemStatusId = @orderLineItemStatusId;

            DROP TABLE #OrderLineItemTempOutput;
        END

        DROP TABLE #OrderLineItemTemp;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END