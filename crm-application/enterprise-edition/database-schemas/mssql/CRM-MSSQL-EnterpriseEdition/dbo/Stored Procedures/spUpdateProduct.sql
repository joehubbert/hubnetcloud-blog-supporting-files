CREATE PROCEDURE [dbo].[spUpdateProduct]
    @productId UNIQUEIDENTIFIER,
    @productSubCategoryId UNIQUEIDENTIFIER,
    @productName NVARCHAR(50),
    @productDescription NVARCHAR(255) = NULL,
    @manufacturerId UNIQUEIDENTIFIER,
    @manufacturerPartNumber NVARCHAR(50) = NULL,
    @productImage VARBINARY(MAX) = NULL,
    @productCountryOfOriginId UNIQUEIDENTIFIER = NULL,
    @productFamilyId UNIQUEIDENTIFIER = NULL,
    @wholesaleCartonFlag BIT,
    @wholesaleCartonBarcode NVARCHAR(50) = NULL,
    @wholesaleUnitQuantityPerCarton INT = NULL,
    @wholesaleCartonStockQuantityHeld BIGINT = NULL,
    @wholesaleCartonHeightCentimeter DECIMAL(5, 2) = NULL,
    @wholesaleCartonWidthCentimeter DECIMAL(5, 2) = NULL,
    @wholesaleCartonDepthCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletFlag BIT,
    @wholesaleCartonQuantityPerPallet TINYINT = NULL,
    @wholesalePalletHeightCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletWidthCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletDepthCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletWeightKilogram DECIMAL(5, 2) = NULL,
    @wholesalePalletTotalHeightCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletTotalWidthCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletTotalDepthCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletTotalWeightKilogram DECIMAL(5, 2) = NULL,
    @wholesaleReorderFlag BIT = NULL,
    @unitBarcode NVARCHAR(50) = NULL,
    @unitPrice MONEY,
    @unitMinimumOrderQuantity INT,
    @unitMinimumStockQuantity INT,
    @unitStockQuantityHeld INT,
    @unitWeightKilogram DECIMAL(5, 2),
    @unitHeightCentimeter DECIMAL(5, 2),
    @unitWidthCentimeter DECIMAL(5, 2),
    @unitDepthCentimeter DECIMAL(5, 2),
    @activeStatus BIT
AS

BEGIN
    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
        BEGIN TRANSACTION;

        DECLARE @wholesaleCartonWeightKilogram DECIMAL(5, 2)
        SET @wholesaleCartonWeightKilogram = 
            CASE 
                WHEN @unitWeightKilogram IS NOT NULL AND @wholesaleUnitQuantityPerCarton IS NOT NULL
                THEN (@unitWeightKilogram * @wholesaleUnitQuantityPerCarton) + 0.02
                ELSE NULL
            END

        UPDATE [dbo].[Product]
        SET
            [ProductSubCategoryId] = @productSubCategoryId,
            [ProductName] = @productName,
            [ProductDescription] = @productDescription,
            [ManufacturerId] = @manufacturerId,
            [ManufacturerPartNumber] = @manufacturerPartNumber,
            [ProductImage] = @productImage,
            [ProductCountryOfOriginId] = @productCountryOfOriginId,
            [ProductFamilyId] = @productFamilyId,
            [WholesaleCartonFlag] = @wholesaleCartonFlag,
            [WholesaleCartonBarcode] = @wholesaleCartonBarcode,
            [WholesaleUnitQuantityPerCarton] = @wholesaleUnitQuantityPerCarton,
            [WholesaleCartonStockQuantityHeld] = @wholesaleCartonStockQuantityHeld,
            [WholesaleCartonWeightKilogram] = @wholesaleCartonWeightKilogram,
            [WholesaleCartonHeightCentimeter] = @wholesaleCartonHeightCentimeter,
            [WholesaleCartonWidthCentimeter] = @wholesaleCartonWidthCentimeter,
            [WholesaleCartonDepthCentimeter] = @wholesaleCartonDepthCentimeter,
            [WholesalePalletFlag] = @wholesalePalletFlag,
            [WholesaleCartonQuantityPerPallet] = @wholesaleCartonQuantityPerPallet,
            [WholesalePalletHeightCentimeter] = @wholesalePalletHeightCentimeter,
            [WholesalePalletWidthCentimeter] = @wholesalePalletWidthCentimeter,
            [WholesalePalletDepthCentimeter] = @wholesalePalletDepthCentimeter,
            [WholesalePalletWeightKilogram] = @wholesalePalletWeightKilogram,
            [WholesalePalletTotalHeightCentimeter] = @wholesalePalletTotalHeightCentimeter,
            [WholesalePalletTotalWidthCentimeter] = @wholesalePalletTotalWidthCentimeter,
            [WholesalePalletTotalDepthCentimeter] = @wholesalePalletTotalDepthCentimeter,
            [WholesalePalletTotalWeightKilogram] = @wholesalePalletTotalWeightKilogram,
            [WholesaleReorderFlag] = @wholesaleReorderFlag,
            [UnitBarcode] = @unitBarcode,
            [UnitPrice] = @unitPrice,
            [UnitMinimumOrderQuantity] = @unitMinimumOrderQuantity,
            [UnitMinimumStockQuantity] = @unitMinimumStockQuantity,
            [UnitStockQuantityHeld] = @unitStockQuantityHeld,
            [UnitWeightKilogram] = @unitWeightKilogram,
            [UnitHeightCentimeter] = @unitHeightCentimeter,
            [UnitWidthCentimeter] = @unitWidthCentimeter,
            [UnitDepthCentimeter] = @unitDepthCentimeter,
            [ActiveStatus] = @activeStatus
        WHERE [ProductId] = @productId

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END