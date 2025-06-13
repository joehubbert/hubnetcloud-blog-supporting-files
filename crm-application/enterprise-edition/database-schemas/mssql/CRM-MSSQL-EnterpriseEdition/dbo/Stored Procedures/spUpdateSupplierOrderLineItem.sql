CREATE PROCEDURE [dbo].[spUpdateSupplierOrderLineItem]
    @supplierOrderId UNIQUEIDENTIFIER,
    @supplierOrderLineItemId UNIQUEIDENTIFIER,
    @productId UNIQUEIDENTIFIER,
    @supplierId UNIQUEIDENTIFIER,
    @wholesaleCartonQuantity INT,
    @supplierOrderLineItemStatusId UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
        BEGIN TRANSACTION;

        -- Declare variables for original values and product/supplier info
        DECLARE @discontinuedError NVARCHAR(100);
        DECLARE @productIdOriginalValue UNIQUEIDENTIFIER;
        DECLARE @wholesaleCartonQuantityOriginalValue INT;
        DECLARE @unitStockQuantityHeld INT;
        DECLARE @wholesaleReorderFlag BIT;
        DECLARE @productSupplierId UNIQUEIDENTIFIER;
        DECLARE @productSupplierWholesalePricePerUnit MONEY;
        DECLARE @wholesaleUnitQuantityPerCarton INT;
        DECLARE @lineItemTotal MONEY;

        -- Get original values
        SELECT
            @productIdOriginalValue = [ProductId],
            @wholesaleCartonQuantityOriginalValue = [WholesaleCartonQuantity]
        FROM [dbo].[SupplierOrderLineItem]
        WHERE [SupplierOrderLineItemId] = @supplierOrderLineItemId;

        -- Retrieve product information
        SELECT
            @unitStockQuantityHeld = [UnitStockQuantityHeld],
            @wholesaleReorderFlag = [WholesaleReorderFlag],
            @wholesaleUnitQuantityPerCarton = [WholesaleUnitQuantityPerCarton]
        FROM [dbo].[Product]
        WHERE [ProductId] = @productId;

        -- Retrieve supplier product information
        SELECT
            @productSupplierId = [ProductSupplierId],
            @productSupplierWholesalePricePerUnit = [WholesalePricePerUnit]
        FROM [dbo].[ProductSupplier]
        WHERE [ProductId] = @productId
          AND [SupplierId] = @supplierId;

        -- Calculate new line item total
        SET @lineItemTotal = @wholesaleCartonQuantity * @productSupplierWholesalePricePerUnit * @wholesaleUnitQuantityPerCarton;

        -- Stock adjustment logic
        IF @productId = @productIdOriginalValue
        BEGIN
            -- Adjust stock for same product
            UPDATE [dbo].[Product]
            SET UnitStockQuantityHeld = UnitStockQuantityHeld + (@wholesaleCartonQuantityOriginalValue - @wholesaleCartonQuantity) * @wholesaleUnitQuantityPerCarton
            WHERE ProductId = @productId;
        END
        ELSE
        BEGIN
            -- Revert stock for original product
            DECLARE @originalWholesaleUnitQuantityPerCarton INT;
            SELECT @originalWholesaleUnitQuantityPerCarton = [WholesaleUnitQuantityPerCarton]
            FROM [dbo].[Product]
            WHERE [ProductId] = @productIdOriginalValue;

            UPDATE [dbo].[Product]
            SET UnitStockQuantityHeld = UnitStockQuantityHeld + (@wholesaleCartonQuantityOriginalValue * @originalWholesaleUnitQuantityPerCarton)
            WHERE ProductId = @productIdOriginalValue;

            -- Deduct stock for new product
            UPDATE [dbo].[Product]
            SET UnitStockQuantityHeld = UnitStockQuantityHeld - (@wholesaleCartonQuantity * @wholesaleUnitQuantityPerCarton)
            WHERE ProductId = @productId;
        END

        -- Check for discontinued or reorderable product
        IF @wholesaleReorderFlag = 0 AND @unitStockQuantityHeld < @wholesaleCartonQuantity * @wholesaleUnitQuantityPerCarton
        BEGIN
            SET @discontinuedError = CONCAT('The product is discontinued. Maximum allowed quantity is ', @unitStockQuantityHeld / @wholesaleUnitQuantityPerCarton, ' cartons');
            THROW 50001, @discontinuedError, 1;
        END
        ELSE IF @wholesaleReorderFlag = 1 AND @unitStockQuantityHeld < @wholesaleCartonQuantity * @wholesaleUnitQuantityPerCarton
        BEGIN
            PRINT 'Supplier order quantity adjusted to available stock. Any remaining items will be placed on backorder and will need to be fulfilled with a new order at a later date.';
        END

        -- Update the SupplierOrderLineItem record
        UPDATE [dbo].[SupplierOrderLineItem]
        SET
            [ProductId] = @productId,
            [WholesaleCartonQuantity] = @wholesaleCartonQuantity,
            [WholesalePricePerUnit] = @productSupplierWholesalePricePerUnit,
            [LineItemTotal] = @lineItemTotal
        WHERE [SupplierOrderLineItemId] = @supplierOrderLineItemId;

        -- Update status history
        EXEC [dbo].[spCreateSupplierOrderLineItemStatusHistory]
            @supplierOrderLineItemId = @supplierOrderLineItemId,
            @supplierOrderLineItemStatusId = @supplierOrderLineItemStatusId;

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