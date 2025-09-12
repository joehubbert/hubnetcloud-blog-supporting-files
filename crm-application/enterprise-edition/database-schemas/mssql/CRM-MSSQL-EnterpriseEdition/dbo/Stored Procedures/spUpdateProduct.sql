CREATE PROCEDURE [dbo].[spUpdateProduct]
    @activeStatus BIT,
    @manufacturerId UNIQUEIDENTIFIER,
    @manufacturerPartNumber NVARCHAR(50) = NULL,
    @productCountryOfOriginId UNIQUEIDENTIFIER,
    @productDescription NVARCHAR(255) = NULL,
    @productFamilyId UNIQUEIDENTIFIER = NULL,
    @productId UNIQUEIDENTIFIER,
    @productName NVARCHAR(50),
    @productSubCategoryId UNIQUEIDENTIFIER,
    @unitBarcode NVARCHAR(50) = NULL,
    @unitDepthCentimeter DECIMAL(5, 2),
    @unitHeightCentimeter DECIMAL(5, 2),
    @unitMinimumOrderQuantity INT,
    @unitMinimumStockQuantity INT,
    @unitPrice MONEY,
    @unitStockQuantityHeld INT,
    @unitVolumeCubicCentimeter DECIMAL(5, 2),
    @unitWeightKilogram DECIMAL(5, 2),
    @unitWidthCentimeter DECIMAL(5, 2),
    @wholesaleCartonBarcode NVARCHAR(50) = NULL,
    @wholesaleCartonDepthCentimeter DECIMAL(5, 2) = NULL,
    @wholesaleCartonFlag BIT,
    @wholesaleCartonHeightCentimeter DECIMAL(5, 2) = NULL,
    @wholesaleCartonPackagingWeightKilogram DECIMAL(5, 2) = NULL,
    @wholesaleCartonQuantityPerPallet TINYINT = NULL,
    @wholesaleCartonStackingHeightPerPallet TINYINT = NULL,
    @wholesaleCartonStockQuantityHeld BIGINT = NULL,
    @wholesaleCartonTotalWeightKilogram DECIMAL(5, 2) = NULL,
    @wholesaleCartonVolumeCubicCentimeter DECIMAL(5, 2) = NULL,
    @wholesaleCartonWidthCentimeter DECIMAL(5, 2) = NULL,
    @wholesaleDeliveryTypeId UNIQUEIDENTIFIER = NULL,
    @wholesaleFlag BIT,
    @wholesalePalletBarcode NVARCHAR(50) = NULL,
    @wholesalePalletDepthCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletFlag BIT,
    @wholesalePalletHeightCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletTotalHeightCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletTotalVolumeCubicCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletTotalWeightKilogram DECIMAL(5, 2) = NULL,
    @wholesalePalletVolumeCubicCentimeter DECIMAL(5, 2) = NULL,
    @wholesalePalletWeightKilogram DECIMAL(5, 2) = NULL,
    @wholesalePalletWidthCentimeter DECIMAL(5, 2) = NULL,
    @wholesaleReorderFlag BIT,
    @wholesaleUnitQuantityPerCarton INT = NULL,
    @wholesaleUnitQuantityPerPallet INT = NULL,
    @wholesaleUnitStackingHeightPerPallet TINYINT = NULL
AS

BEGIN
    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
        BEGIN TRANSACTION;

        UPDATE [dbo].[Product]
        SET
            [ActiveStatus] = @activeStatus,
            [ManufacturerId] = @manufacturerId,
            [ManufacturerPartNumber] = @manufacturerPartNumber,
            [ProductCountryOfOriginId] = @productCountryOfOriginId,
            [ProductDescription] = @productDescription,
            [ProductFamilyId] = @productFamilyId,
            [ProductName] = @productName,
            [ProductSubCategoryId] = @productSubCategoryId,
            [UnitBarcode] = @unitBarcode,
            [UnitDepthCentimeter] = @unitDepthCentimeter,
            [UnitHeightCentimeter] = @unitHeightCentimeter,
            [UnitMinimumOrderQuantity] = @unitMinimumOrderQuantity,
            [UnitMinimumStockQuantity] = @unitMinimumStockQuantity,
            [UnitPrice] = @unitPrice,
            [UnitStockQuantityHeld] = @unitStockQuantityHeld,
            [UnitVolumeCubicCentimeter] = @unitVolumeCubicCentimeter,
            [UnitWeightKilogram] = @unitWeightKilogram,
            [UnitWidthCentimeter] = @unitWidthCentimeter,
            [WholesaleCartonBarcode] = @wholesaleCartonBarcode,
            [WholesaleCartonDepthCentimeter] = @wholesaleCartonDepthCentimeter,
            [WholesaleCartonFlag] = @wholesaleCartonFlag,
            [WholesaleCartonHeightCentimeter] = @wholesaleCartonHeightCentimeter,
            [WholesaleCartonQuantityPerPallet] = @wholesaleCartonQuantityPerPallet,
            [WholesaleCartonStackingHeightPerPallet] = @wholesaleCartonStackingHeightPerPallet,
            [WholesaleCartonStockQuantityHeld] = @wholesaleCartonStockQuantityHeld,
            [WholesaleCartonTotalWeightKilogram] = @wholesaleCartonTotalWeightKilogram,
            [WholesaleCartonVolumeCubicCentimeter] = @wholesaleCartonVolumeCubicCentimeter,
            [WholesaleCartonPackagingWeightKilogram] = @wholesaleCartonPackagingWeightKilogram,
            [WholesaleCartonWidthCentimeter] = @wholesaleCartonWidthCentimeter,
            [WholesaleDeliveryTypeId] = @wholesaleDeliveryTypeId,
            [WholesaleFlag] = @wholesaleFlag,
            [WholesalePalletBarcode] = @wholesalePalletBarcode,
            [WholesalePalletDepthCentimeter] = @wholesalePalletDepthCentimeter,
            [WholesalePalletFlag] = @wholesalePalletFlag,
            [WholesalePalletHeightCentimeter] = @wholesalePalletHeightCentimeter,
            [WholesalePalletTotalHeightCentimeter] = @wholesalePalletTotalHeightCentimeter,
            [WholesalePalletTotalVolumeCubicCentimeter] = @wholesalePalletTotalVolumeCubicCentimeter,
            [WholesalePalletTotalWeightKilogram] = @wholesalePalletTotalWeightKilogram,
            [WholesalePalletVolumeCubicCentimeter] = @wholesalePalletVolumeCubicCentimeter,
            [WholesalePalletWeightKilogram] = @wholesalePalletWeightKilogram,
            [WholesalePalletWidthCentimeter] = @wholesalePalletWidthCentimeter,
            [WholesaleReorderFlag] = @wholesaleReorderFlag,
            [WholesaleUnitQuantityPerCarton] = @wholesaleUnitQuantityPerCarton,
            [WholesaleUnitQuantityPerPallet] = @wholesaleUnitQuantityPerPallet,
            [WholesaleUnitStackingHeightPerPallet] = @wholesaleUnitStackingHeightPerPallet
        WHERE [ProductId] = @productId

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END