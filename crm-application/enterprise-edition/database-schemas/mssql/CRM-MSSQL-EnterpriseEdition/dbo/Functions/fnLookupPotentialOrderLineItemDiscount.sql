CREATE FUNCTION [dbo].[fnLookupPotentialOrderLineItemDiscount]
(
	@productId UNIQUEIDENTIFIER,
    @quantity INT
)
RETURNS @result TABLE
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
AS
BEGIN
    DECLARE @currentUTCTimestampUTC DATETIME2 = SYSUTCDATETIME();
    DECLARE @discount DECIMAL(5,2) = 0.00;
    DECLARE @finalLineItemTotal MONEY;
    DECLARE @numGroups INT;
    DECLARE @originalLineItemTotal MONEY;
    DECLARE @originalQuantity INT = @quantity;
    DECLARE @paidQuantity INT;
    DECLARE @productCategoryId UNIQUEIDENTIFIER;
    DECLARE @productFinalPrice MONEY;
    DECLARE @productManufacturerId UNIQUEIDENTIFIER;
    DECLARE @productSubCategoryId UNIQUEIDENTIFIER;
    DECLARE @productSupplierId UNIQUEIDENTIFIER;
    DECLARE @productUnitPrice MONEY;
    DECLARE @promotionBuyQuantity INT;
    DECLARE @promotionCode NVARCHAR(15);
    DECLARE @promotionGetQuantity INT;
    DECLARE @promotionType NVARCHAR(50);
    DECLARE @promotionTypeId UNIQUEIDENTIFIER;
    DECLARE @promotionValue DECIMAL(18,2);
    DECLARE @suggestedQuantity INT;

    -- 1. Lookup Product Information
    SELECT @productCategoryId = PC.[ProductCategoryId],
    @productManufacturerId = P.[ManufacturerId],
    @productSubCategoryId = P.[ProductSubCategoryId],
    @productUnitPrice = P.[UnitPrice]
    FROM [dbo].[Product] P
    INNER JOIN [dbo].[ProductSubCategory] PS ON P.[ProductSubCategoryId] = PS.[ProductSubCategoryId]
    INNER JOIN [dbo].[ProductCategory] PC ON PS.[ProductCategoryId] = PC.[ProductCategoryId]
    WHERE P.[ProductId] = @productId

    -- 2. Set @originalQuantity
    SET @originalQuantity = @quantity;

    -- 3. Set @originalLineItemTotal
    SET @originalLineItemTotal = @originalQuantity * @productUnitPrice;

    -- 4. Check PromotionProduct
    SELECT TOP 1 @discount = P.[PromotionValue] / 100.0,
        @promotionBuyQuantity = P.[PromotionBuyQuantity],
        @promotionGetQuantity = P.[PromotionGetQuantity],
        @promotionValue = P.[PromotionValue],
        @promotionCode = P.[PromotionCode],
        @promotionTypeId = PT.[PromotionTypeId],
        @promotionType = PT.[PromotionType]
    FROM [dbo].[PromotionProduct] PP
    INNER JOIN [dbo].[Promotion] P ON PP.[PromotionId] = P.[PromotionId]
    INNER JOIN [dbo].[PromotionType] PT ON P.[PromotionTypeId] = PT.[PromotionTypeId]
    WHERE PP.[ProductId] = @productId
      AND P.[ActiveStatus] = 1
      AND @currentUTCTimestampUTC BETWEEN P.[PromotionStartTimestampUTC] AND P.[PromotionEndTimestampUTC]
    ORDER BY P.[PromotionValue] DESC;

    IF @discount > 0
    BEGIN
        IF @promotionBuyQuantity + @promotionGetQuantity > 0
        BEGIN
            IF @quantity % (@promotionBuyQuantity + @promotionGetQuantity) = 0
                SET @suggestedQuantity = @quantity;
            ELSE
                SET @suggestedQuantity = ((@quantity / (@promotionBuyQuantity + @promotionGetQuantity)) + 1) * (@promotionBuyQuantity + @promotionGetQuantity);

            -- Calculate how many are paid for
            SET @numGroups = @suggestedQuantity / (@promotionBuyQuantity + @promotionGetQuantity);
            SET @paidQuantity = @numGroups * @promotionBuyQuantity + (@suggestedQuantity % (@promotionBuyQuantity + @promotionGetQuantity));
            SET @productFinalPrice = @paidQuantity * @productUnitPrice * (1 - @discount);
            SET @finalLineItemTotal = @productFinalPrice * @suggestedQuantity;

            INSERT INTO @result ([Discount],[OriginalQuantity],[SuggestedQuantity],[UnitPrice],[FinalPrice],[OriginalLineItemTotal],[FinalLineItemTotal],[PromotionCode],[PromotionType],[PromotionTypeId])
            VALUES (@discount, @originalQuantity, @suggestedQuantity, @productUnitPrice, @productFinalPrice, @originalLineItemTotal, @finalLineItemTotal, @promotionCode, @promotionType, @promotionTypeId);
        END
    END

    -- 5. Check PromotionProductCategory
    SELECT TOP 1 @discount = P.[PromotionValue] / 100.0,
        @promotionBuyQuantity = P.[PromotionBuyQuantity],
        @promotionGetQuantity = P.[PromotionGetQuantity],
        @promotionValue = P.[PromotionValue],
        @promotionCode = P.[PromotionCode],
        @promotionTypeId = PT.[PromotionTypeId],
        @promotionType = PT.[PromotionType]
    FROM [dbo].[PromotionProductCategory] PPC
    INNER JOIN [dbo].[Promotion] P ON PPC.[PromotionId] = P.[PromotionId]
    INNER JOIN [dbo].[PromotionType] PT ON P.[PromotionTypeId] = PT.[PromotionTypeId]
    WHERE PPC.[ProductCategoryId] = @productCategoryId
      AND P.[ActiveStatus] = 1
      AND @currentUTCTimestampUTC BETWEEN P.[PromotionStartTimestampUTC] AND P.[PromotionEndTimestampUTC]
    ORDER BY P.[PromotionValue] DESC;

    IF @discount > 0
    BEGIN
        IF @promotionBuyQuantity + @promotionGetQuantity > 0
        BEGIN
            IF @quantity % (@promotionBuyQuantity + @promotionGetQuantity) = 0
                SET @suggestedQuantity = @quantity;
            ELSE
                SET @suggestedQuantity = ((@quantity / (@promotionBuyQuantity + @promotionGetQuantity)) + 1) * (@promotionBuyQuantity + @promotionGetQuantity);

            -- Calculate how many are paid for
            SET @numGroups = @suggestedQuantity / (@promotionBuyQuantity + @promotionGetQuantity);
            SET @paidQuantity = @numGroups * @promotionBuyQuantity + (@suggestedQuantity % (@promotionBuyQuantity + @promotionGetQuantity));
            SET @productFinalPrice = @paidQuantity * @productUnitPrice * (1 - @discount);
            SET @finalLineItemTotal = @productFinalPrice * @suggestedQuantity;

            INSERT INTO @result ([Discount],[OriginalQuantity],[SuggestedQuantity],[UnitPrice],[FinalPrice],[OriginalLineItemTotal],[FinalLineItemTotal],[PromotionCode],[PromotionType],[PromotionTypeId])
            VALUES (@discount, @originalQuantity, @suggestedQuantity, @productUnitPrice, @productFinalPrice, @originalLineItemTotal, @finalLineItemTotal, @promotionCode, @promotionType, @promotionTypeId);
        END
    END

    -- 6. Check PromotionProductSubCategory
    SELECT TOP 1 @discount = P.[PromotionValue] / 100.0,
        @promotionBuyQuantity = P.[PromotionBuyQuantity],
        @promotionGetQuantity = P.[PromotionGetQuantity],
        @promotionValue = P.[PromotionValue],
        @promotionCode = P.[PromotionCode],
        @promotionTypeId = PT.[PromotionTypeId],
        @promotionType = PT.[PromotionType]
    FROM [dbo].[PromotionProductSubCategory] PPSC
    INNER JOIN [dbo].[Promotion] P ON PPSC.[PromotionId] = P.[PromotionId]
    INNER JOIN [dbo].[PromotionType] PT ON P.[PromotionTypeId] = PT.[PromotionTypeId]
    WHERE PPSC.[ProductSubCategoryId] = @productSubCategoryId
      AND P.[ActiveStatus] = 1
      AND @currentUTCTimestampUTC BETWEEN P.[PromotionStartTimestampUTC] AND P.[PromotionEndTimestampUTC]
    ORDER BY P.[PromotionValue] DESC;

    IF @discount > 0
    BEGIN
        IF @promotionBuyQuantity + @promotionGetQuantity > 0
        BEGIN
            IF @quantity % (@promotionBuyQuantity + @promotionGetQuantity) = 0
                SET @suggestedQuantity = @quantity;
            ELSE
                SET @suggestedQuantity = ((@quantity / (@promotionBuyQuantity + @promotionGetQuantity)) + 1) * (@promotionBuyQuantity + @promotionGetQuantity);

            -- Calculate how many are paid for
            SET @numGroups = @suggestedQuantity / (@promotionBuyQuantity + @promotionGetQuantity);
            SET @paidQuantity = @numGroups * @promotionBuyQuantity + (@suggestedQuantity % (@promotionBuyQuantity + @promotionGetQuantity));
            SET @productFinalPrice = @paidQuantity * @productUnitPrice * (1 - @discount);
            SET @finalLineItemTotal = @productFinalPrice * @suggestedQuantity;

            INSERT INTO @result ([Discount],[OriginalQuantity],[SuggestedQuantity],[UnitPrice],[FinalPrice],[OriginalLineItemTotal],[FinalLineItemTotal],[PromotionCode],[PromotionType],[PromotionTypeId])
            VALUES (@discount, @originalQuantity, @suggestedQuantity, @productUnitPrice, @productFinalPrice, @originalLineItemTotal, @finalLineItemTotal, @promotionCode, @promotionType, @promotionTypeId);
        END
    END

    -- 7. Check PromotionManufacturer
    BEGIN
        SELECT TOP 1 @discount = P.[PromotionValue] / 100.0,
            @promotionBuyQuantity = P.[PromotionBuyQuantity],
            @promotionGetQuantity = P.[PromotionGetQuantity],
            @promotionValue = P.[PromotionValue],
            @promotionCode = P.[PromotionCode],
            @promotionTypeId = PT.[PromotionTypeId],
            @promotionType = PT.[PromotionType]
        FROM [dbo].[PromotionManufacturer] PM
        INNER JOIN [dbo].[Promotion] P ON PM.[PromotionId] = P.[PromotionId]
        INNER JOIN [dbo].[PromotionType] PT ON P.[PromotionTypeId] = PT.[PromotionTypeId]
        WHERE PM.[ManufacturerId] = @productManufacturerId
          AND P.[ActiveStatus] = 1
          AND @currentUTCTimestampUTC BETWEEN P.[PromotionStartTimestampUTC] AND P.[PromotionEndTimestampUTC]
        ORDER BY P.[PromotionValue] DESC;

        IF @discount > 0
        BEGIN
            IF @promotionBuyQuantity + @promotionGetQuantity > 0
            BEGIN
                IF @quantity % (@promotionBuyQuantity + @promotionGetQuantity) = 0
                    SET @suggestedQuantity = @quantity;
                ELSE
                    SET @suggestedQuantity = ((@quantity / (@promotionBuyQuantity + @promotionGetQuantity)) + 1) * (@promotionBuyQuantity + @promotionGetQuantity);

                -- Calculate how many are paid for
                SET @numGroups = @suggestedQuantity / (@promotionBuyQuantity + @promotionGetQuantity);
                SET @paidQuantity = @numGroups * @promotionBuyQuantity + (@suggestedQuantity % (@promotionBuyQuantity + @promotionGetQuantity));
                SET @productFinalPrice = @paidQuantity * @productUnitPrice * (1 - @discount);
                SET @finalLineItemTotal = @productFinalPrice * @suggestedQuantity;

                INSERT INTO @result ([Discount],[OriginalQuantity],[SuggestedQuantity],[UnitPrice],[FinalPrice],[OriginalLineItemTotal],[FinalLineItemTotal],[PromotionCode],[PromotionType],[PromotionTypeId])
                VALUES (@discount, @originalQuantity, @suggestedQuantity, @productUnitPrice, @productFinalPrice, @originalLineItemTotal, @finalLineItemTotal, @promotionCode, @promotionType, @promotionTypeId);
            END
        END
    END
 
    -- 8. Check PromotionManufacturerProductCategory
    BEGIN
        SELECT TOP 1 @discount = P.[PromotionValue] / 100.0,
            @promotionBuyQuantity = P.[PromotionBuyQuantity],
            @promotionGetQuantity = P.[PromotionGetQuantity],
            @promotionValue = P.[PromotionValue],
            @promotionCode = P.[PromotionCode],
            @promotionTypeId = PT.[PromotionTypeId],
            @promotionType = PT.[PromotionType]
        FROM [dbo].[PromotionManufacturerProductCategory] PMPC
        INNER JOIN [dbo].[Promotion] P ON PMPC.[PromotionId] = P.[PromotionId]
        INNER JOIN [dbo].[PromotionType] PT ON P.[PromotionTypeId] = PT.[PromotionTypeId]
        WHERE PMPC.[ManufacturerId] = @productManufacturerId
          AND PMPC.[ProductCategoryId] = @productCategoryId
          AND P.[ActiveStatus] = 1
          AND @currentUTCTimestampUTC BETWEEN P.[PromotionStartTimestampUTC] AND P.[PromotionEndTimestampUTC]
        ORDER BY P.[PromotionValue] DESC;

        IF @discount > 0
        BEGIN
            IF @promotionBuyQuantity + @promotionGetQuantity > 0
            BEGIN
                IF @quantity % (@promotionBuyQuantity + @promotionGetQuantity) = 0
                    SET @suggestedQuantity = @quantity;
                ELSE
                    SET @suggestedQuantity = ((@quantity / (@promotionBuyQuantity + @promotionGetQuantity)) + 1) * (@promotionBuyQuantity + @promotionGetQuantity);

                -- Calculate how many are paid for
                SET @numGroups = @suggestedQuantity / (@promotionBuyQuantity + @promotionGetQuantity);
                SET @paidQuantity = @numGroups * @promotionBuyQuantity + (@suggestedQuantity % (@promotionBuyQuantity + @promotionGetQuantity));
                SET @productFinalPrice = @paidQuantity * @productUnitPrice * (1 - @discount);
                SET @finalLineItemTotal = @productFinalPrice * @suggestedQuantity;

                INSERT INTO @result ([Discount],[OriginalQuantity],[SuggestedQuantity],[UnitPrice],[FinalPrice],[OriginalLineItemTotal],[FinalLineItemTotal],[PromotionCode],[PromotionType],[PromotionTypeId])
                VALUES (@discount, @originalQuantity, @suggestedQuantity, @productUnitPrice, @productFinalPrice, @originalLineItemTotal, @finalLineItemTotal, @promotionCode, @promotionType, @promotionTypeId);
            END
        END
    END

    -- 9. Check PromotionManufacturerProductSubCategory
    BEGIN
        SELECT TOP 1 @discount = P.[PromotionValue] / 100.0,
            @promotionBuyQuantity = P.[PromotionBuyQuantity],
            @promotionGetQuantity = P.[PromotionGetQuantity],
            @promotionValue = P.[PromotionValue],
            @promotionCode = P.[PromotionCode],
            @promotionTypeId = PT.[PromotionTypeId],
            @promotionType = PT.[PromotionType]
        FROM [dbo].[PromotionManufacturerProductSubCategory] PMPSC
        INNER JOIN [dbo].[Promotion] P ON PMPSC.[PromotionId] = P.[PromotionId]
        INNER JOIN [dbo].[PromotionType] PT ON P.[PromotionTypeId] = PT.[PromotionTypeId]
        WHERE PMPSC.[ManufacturerId] = @productManufacturerId
          AND PMPSC.[ProductSubCategoryId] = @productSubCategoryId
          AND P.[ActiveStatus] = 1
          AND @currentUTCTimestampUTC BETWEEN P.[PromotionStartTimestampUTC] AND P.[PromotionEndTimestampUTC]
        ORDER BY P.[PromotionValue] DESC;

        IF @discount > 0
        BEGIN
            IF @promotionBuyQuantity + @promotionGetQuantity > 0
            BEGIN
                IF @quantity % (@promotionBuyQuantity + @promotionGetQuantity) = 0
                    SET @suggestedQuantity = @quantity;
                ELSE
                    SET @suggestedQuantity = ((@quantity / (@promotionBuyQuantity + @promotionGetQuantity)) + 1) * (@promotionBuyQuantity + @promotionGetQuantity);

                -- Calculate how many are paid for
                SET @numGroups = @suggestedQuantity / (@promotionBuyQuantity + @promotionGetQuantity);
                SET @paidQuantity = @numGroups * @promotionBuyQuantity + (@suggestedQuantity % (@promotionBuyQuantity + @promotionGetQuantity));
                SET @productFinalPrice = @paidQuantity * @productUnitPrice * (1 - @discount);
                SET @finalLineItemTotal = @productFinalPrice * @suggestedQuantity;

                INSERT INTO @result ([Discount],[OriginalQuantity],[SuggestedQuantity],[UnitPrice],[FinalPrice],[OriginalLineItemTotal],[FinalLineItemTotal],[PromotionCode],[PromotionType],[PromotionTypeId])
                VALUES (@discount, @originalQuantity, @suggestedQuantity, @productUnitPrice, @productFinalPrice, @originalLineItemTotal, @finalLineItemTotal, @promotionCode, @promotionType, @promotionTypeId);
            END
        END
    END

    -- 10. Check PromotionSupplier
    -- Get all suppliers for this product
    DECLARE supplier_cursor CURSOR FOR
        SELECT [SupplierId] FROM [dbo].[ProductSupplier] WHERE [ProductId] = @productId AND [ActiveStatus] = 1;

    OPEN supplier_cursor;
    FETCH NEXT FROM supplier_cursor INTO @productSupplierId;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT TOP 1 @discount = P.[PromotionValue] / 100.0,
            @promotionBuyQuantity = P.[PromotionBuyQuantity],
            @promotionGetQuantity = P.[PromotionGetQuantity],
            @promotionValue = P.[PromotionValue],
            @promotionCode = P.[PromotionCode],
            @promotionTypeId = PT.[PromotionTypeId],
            @promotionType = PT.[PromotionType]
        FROM [dbo].[PromotionSupplier] PS
        INNER JOIN [dbo].[Promotion] P ON PS.[PromotionId] = P.[PromotionId]
        INNER JOIN [dbo].[PromotionType] PT ON P.[PromotionTypeId] = PT.[PromotionTypeId]
        WHERE PS.[SupplierId] = @productSupplierId
          AND P.[ActiveStatus] = 1
          AND @currentUTCTimestampUTC BETWEEN P.[PromotionStartTimestampUTC] AND P.[PromotionEndTimestampUTC]
        ORDER BY P.[PromotionValue] DESC;

        IF @discount > 0
        BEGIN
            CLOSE supplier_cursor;
            DEALLOCATE supplier_cursor;
            IF @promotionBuyQuantity + @promotionGetQuantity > 0
            BEGIN
                IF @quantity % (@promotionBuyQuantity + @promotionGetQuantity) = 0
                    SET @suggestedQuantity = @quantity;
                ELSE
                    SET @suggestedQuantity = ((@quantity / (@promotionBuyQuantity + @promotionGetQuantity)) + 1) * (@promotionBuyQuantity + @promotionGetQuantity);

                -- Calculate how many are paid for
                SET @numGroups = @suggestedQuantity / (@promotionBuyQuantity + @promotionGetQuantity);
                SET @paidQuantity = @numGroups * @promotionBuyQuantity + (@suggestedQuantity % (@promotionBuyQuantity + @promotionGetQuantity));
                SET @productFinalPrice = @paidQuantity * @productUnitPrice * (1 - @discount);
                SET @finalLineItemTotal = @productFinalPrice * @suggestedQuantity;

                INSERT INTO @result ([Discount],[OriginalQuantity],[SuggestedQuantity],[UnitPrice],[FinalPrice],[OriginalLineItemTotal],[FinalLineItemTotal],[PromotionCode],[PromotionType],[PromotionTypeId])
                VALUES (@discount, @originalQuantity, @suggestedQuantity, @productUnitPrice, @productFinalPrice, @originalLineItemTotal, @finalLineItemTotal, @promotionCode, @promotionType, @promotionTypeId);
            END
        END

        FETCH NEXT FROM supplier_cursor INTO @productSupplierId;
    END

    CLOSE supplier_cursor;
    DEALLOCATE supplier_cursor;

    -- 11. Check PromotionSupplierProductCategory
    -- Get all suppliers for this product
    DECLARE supplier_cursor CURSOR FOR
        SELECT [SupplierId] FROM [dbo].[ProductSupplier] WHERE [ProductId] = @productId AND [ActiveStatus] = 1;

    OPEN supplier_cursor;
    FETCH NEXT FROM supplier_cursor INTO @productSupplierId;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT TOP 1 @discount = P.[PromotionValue] / 100.0,
            @promotionBuyQuantity = P.[PromotionBuyQuantity],
            @promotionGetQuantity = P.[PromotionGetQuantity],
            @promotionValue = P.[PromotionValue],
            @promotionCode = P.[PromotionCode],
            @promotionTypeId = PT.[PromotionTypeId],
            @promotionType = PT.[PromotionType]
        FROM [dbo].[PromotionSupplierProductCategory] PSPC
        INNER JOIN [dbo].[Promotion] P ON PSPC.[PromotionId] = P.[PromotionId]
        INNER JOIN [dbo].[PromotionType] PT ON P.[PromotionTypeId] = PT.[PromotionTypeId]
        WHERE PSPC.[SupplierId] = @productSupplierId
          AND PSPC.[ProductCategoryId] = @productCategoryId
          AND P.[ActiveStatus] = 1
          AND @currentUTCTimestampUTC BETWEEN P.[PromotionStartTimestampUTC] AND P.[PromotionEndTimestampUTC]
        ORDER BY P.[PromotionValue] DESC;

        IF @discount > 0
        BEGIN
            CLOSE supplier_cursor;
            DEALLOCATE supplier_cursor;
            IF @promotionBuyQuantity + @promotionGetQuantity > 0
            BEGIN
                IF @quantity % (@promotionBuyQuantity + @promotionGetQuantity) = 0
                    SET @suggestedQuantity = @quantity;
                ELSE
                    SET @suggestedQuantity = ((@quantity / (@promotionBuyQuantity + @promotionGetQuantity)) + 1) * (@promotionBuyQuantity + @promotionGetQuantity);

                -- Calculate how many are paid for
                SET @numGroups = @suggestedQuantity / (@promotionBuyQuantity + @promotionGetQuantity);
                SET @paidQuantity = @numGroups * @promotionBuyQuantity + (@suggestedQuantity % (@promotionBuyQuantity + @promotionGetQuantity));
                SET @productFinalPrice = @paidQuantity * @productUnitPrice * (1 - @discount);
                SET @finalLineItemTotal = @productFinalPrice * @suggestedQuantity;

                INSERT INTO @result ([Discount],[OriginalQuantity],[SuggestedQuantity],[UnitPrice],[FinalPrice],[OriginalLineItemTotal],[FinalLineItemTotal],[PromotionCode],[PromotionType],[PromotionTypeId])
                VALUES (@discount, @originalQuantity, @suggestedQuantity, @productUnitPrice, @productFinalPrice, @originalLineItemTotal, @finalLineItemTotal, @promotionCode, @promotionType, @promotionTypeId);
            END
        END

        FETCH NEXT FROM supplier_cursor INTO @productSupplierId;
    END

    CLOSE supplier_cursor;
    DEALLOCATE supplier_cursor;

    -- 12. Check PromotionSupplierProductSubCategory
    -- Get all suppliers for this product
    DECLARE supplier_cursor CURSOR FOR
        SELECT [SupplierId] FROM [dbo].[ProductSupplier] WHERE [ProductId] = @productId AND [ActiveStatus] = 1;

    OPEN supplier_cursor;
    FETCH NEXT FROM supplier_cursor INTO @productSupplierId;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        SELECT TOP 1 @discount = P.[PromotionValue] / 100.0,
            @promotionBuyQuantity = P.[PromotionBuyQuantity],
            @promotionGetQuantity = P.[PromotionGetQuantity],
            @promotionValue = P.[PromotionValue],
            @promotionCode = P.[PromotionCode],
            @promotionTypeId = PT.[PromotionTypeId],
            @promotionType = PT.[PromotionType]
        FROM [dbo].[PromotionSupplierProductSubCategory] PSPSC
        INNER JOIN [dbo].[Promotion] P ON PSPSC.[PromotionId] = P.[PromotionId]
        INNER JOIN [dbo].[PromotionType] PT ON P.[PromotionTypeId] = PT.[PromotionTypeId]
        WHERE PSPSC.[SupplierId] = @productSupplierId
          AND PSPSC.[ProductSubCategoryId] = @productSubCategoryId
          AND P.[ActiveStatus] = 1
          AND @currentUTCTimestampUTC BETWEEN P.[PromotionStartTimestampUTC] AND P.[PromotionEndTimestampUTC]
        ORDER BY P.[PromotionValue] DESC;

        IF @discount > 0
        BEGIN
            CLOSE supplier_cursor;
            DEALLOCATE supplier_cursor;
            IF @promotionBuyQuantity + @promotionGetQuantity > 0
            BEGIN
                IF @quantity % (@promotionBuyQuantity + @promotionGetQuantity) = 0
                    SET @suggestedQuantity = @quantity;
                ELSE
                    SET @suggestedQuantity = ((@quantity / (@promotionBuyQuantity + @promotionGetQuantity)) + 1) * (@promotionBuyQuantity + @promotionGetQuantity);

                -- Calculate how many are paid for
                SET @numGroups = @suggestedQuantity / (@promotionBuyQuantity + @promotionGetQuantity);
                SET @paidQuantity = @numGroups * @promotionBuyQuantity + (@suggestedQuantity % (@promotionBuyQuantity + @promotionGetQuantity));
                SET @productFinalPrice = @paidQuantity * @productUnitPrice * (1 - @discount);
                SET @finalLineItemTotal = @productFinalPrice * @suggestedQuantity;

                INSERT INTO @result ([Discount],[OriginalQuantity],[SuggestedQuantity],[UnitPrice],[FinalPrice],[OriginalLineItemTotal],[FinalLineItemTotal],[PromotionCode],[PromotionType],[PromotionTypeId])
                VALUES (@discount, @originalQuantity, @suggestedQuantity, @productUnitPrice, @productFinalPrice, @originalLineItemTotal, @finalLineItemTotal, @promotionCode, @promotionType, @promotionTypeId);
            END
        END
        FETCH NEXT FROM supplier_cursor INTO @productSupplierId;
    END

    CLOSE supplier_cursor;
    DEALLOCATE supplier_cursor;

    -- 13. Fallback to wholesale discount logic
    IF @quantity > 500 SET @discount = 0.20;
    ELSE IF @quantity > 200 SET @discount = 0.15;
    ELSE IF @quantity > 150 SET @discount = 0.10;
    ELSE IF @quantity > 50 SET @discount = 0.05;
    ELSE SET @discount = 0.00;

    SET @suggestedQuantity = @quantity;
    SET @productFinalPrice = @quantity * @productUnitPrice * (1 - @discount);
    SET @finalLineItemTotal = @productFinalPrice * @suggestedQuantity;

    INSERT INTO @result ([Discount],[OriginalQuantity],[SuggestedQuantity],[UnitPrice],[FinalPrice],[OriginalLineItemTotal],[FinalLineItemTotal],[PromotionCode],[PromotionType],[PromotionTypeId])
    VALUES (@discount, @originalQuantity, @suggestedQuantity, @productUnitPrice, @productFinalPrice, @originalLineItemTotal, @finalLineItemTotal, @promotionCode, 'Wholesale Discount', NULL);

    RETURN;
END