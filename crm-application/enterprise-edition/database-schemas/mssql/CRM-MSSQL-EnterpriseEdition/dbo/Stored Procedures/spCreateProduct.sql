CREATE PROCEDURE [dbo].[spCreateProduct]
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
    @activeStatus BIT,
    @productId UNIQUEIDENTIFIER OUTPUT
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

        CREATE TABLE #ProductTemp
        (
            [ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
            [ProductName] NVARCHAR(50) NOT NULL,
            [ProductDescription] NVARCHAR(255) NULL,
            [ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
            [ManufacturerPartNumber] NVARCHAR(50) NULL,
            [ProductImage] VARBINARY(MAX) NULL,
            [ProductCountryOfOriginId] UNIQUEIDENTIFIER NULL,
            [ProductFamilyId] UNIQUEIDENTIFIER NULL,
            [WholesaleCartonFlag] BIT NOT NULL,
            [WholesaleCartonBarcode] NVARCHAR(50) NULL,
            [WholesaleUnitQuantityPerCarton] INT NULL,
            [WholesaleCartonStockQuantityHeld] BIGINT NULL,
            [WholesaleCartonWeightKilogram] DECIMAL(5, 2) NULL,
            [WholesaleCartonHeightCentimeter] DECIMAL(5, 2) NULL,
            [WholesaleCartonWidthCentimeter] DECIMAL(5, 2) NULL,
            [WholesaleCartonDepthCentimeter] DECIMAL(5, 2) NULL,
            [WholesalePalletFlag] BIT NOT NULL,
            [WholesaleCartonQuantityPerPallet] TINYINT NULL,
            [WholesalePalletHeightCentimeter] DECIMAL(5, 2) NULL,
            [WholesalePalletWidthCentimeter] DECIMAL(5, 2) NULL,
            [WholesalePalletDepthCentimeter] DECIMAL(5, 2) NULL,
            [WholesalePalletWeightKilogram] DECIMAL(5, 2) NULL,
            [WholesalePalletTotalHeightCentimeter] DECIMAL(5, 2) NULL,
            [WholesalePalletTotalWidthCentimeter] DECIMAL(5, 2) NULL,
            [WholesalePalletTotalDepthCentimeter] DECIMAL(5, 2) NULL,
            [WholesalePalletTotalWeightKilogram] DECIMAL(5, 2) NULL,
            [WholesaleReorderFlag] BIT NULL,
            [UnitBarcode] NVARCHAR(50) NULL,
            [UnitPrice] MONEY NOT NULL,
            [UnitMinimumOrderQuantity] INT NOT NULL,
            [UnitMinimumStockQuantity] INT NOT NULL,
            [UnitStockQuantityHeld] INT NOT NULL,
            [UnitWeightKilogram] DECIMAL(5, 2) NOT NULL,
            [UnitHeightCentimeter] DECIMAL(5, 2) NOT NULL,
            [UnitWidthCentimeter] DECIMAL(5, 2) NOT NULL,
            [UnitDepthCentimeter] DECIMAL(5, 2) NOT NULL,
            [ActiveStatus] BIT NOT NULL
        )

        INSERT INTO #ProductTemp
        (
            [ProductSubCategoryId],
            [ProductName],
            [ProductDescription],
            [ManufacturerId],
            [ManufacturerPartNumber],
            [ProductImage],
            [ProductCountryOfOriginId],
            [ProductFamilyId],
            [WholesaleCartonFlag],
            [WholesaleCartonBarcode],
            [WholesaleUnitQuantityPerCarton],
            [WholesaleCartonStockQuantityHeld],
            [WholesaleCartonWeightKilogram],
            [WholesaleCartonHeightCentimeter],
            [WholesaleCartonWidthCentimeter],
            [WholesaleCartonDepthCentimeter],
            [WholesalePalletFlag],
            [WholesaleCartonQuantityPerPallet],
            [WholesalePalletHeightCentimeter],
            [WholesalePalletWidthCentimeter],
            [WholesalePalletDepthCentimeter],
            [WholesalePalletWeightKilogram],
            [WholesalePalletTotalHeightCentimeter],
            [WholesalePalletTotalWidthCentimeter],
            [WholesalePalletTotalDepthCentimeter],
            [WholesalePalletTotalWeightKilogram],
            [WholesaleReorderFlag],
            [UnitBarcode],
            [UnitPrice],
            [UnitMinimumOrderQuantity],
            [UnitMinimumStockQuantity],
            [UnitStockQuantityHeld],
            [UnitWeightKilogram],
            [UnitHeightCentimeter],
            [UnitWidthCentimeter],
            [UnitDepthCentimeter],
            [ActiveStatus]
        )
        VALUES
        (
            @productSubCategoryId,
            @productName,
            @productDescription,
            @manufacturerId,
            @manufacturerPartNumber,
            @productImage,
            @productCountryOfOriginId,
            @productFamilyId,
            @wholesaleCartonFlag,
            @wholesaleCartonBarcode,
            @wholesaleUnitQuantityPerCarton,
            @wholesaleCartonStockQuantityHeld,
            @wholesaleCartonWeightKilogram,
            @wholesaleCartonHeightCentimeter,
            @wholesaleCartonWidthCentimeter,
            @wholesaleCartonDepthCentimeter,
            @wholesalePalletFlag,
            @wholesaleCartonQuantityPerPallet,
            @wholesalePalletHeightCentimeter,
            @wholesalePalletWidthCentimeter,
            @wholesalePalletDepthCentimeter,
            @wholesalePalletWeightKilogram,
            @wholesalePalletTotalHeightCentimeter,
            @wholesalePalletTotalWidthCentimeter,
            @wholesalePalletTotalDepthCentimeter,
            @wholesalePalletTotalWeightKilogram,
            @wholesaleReorderFlag,
            @unitBarcode,
            @unitPrice,
            @unitMinimumOrderQuantity,
            @unitMinimumStockQuantity,
            @unitStockQuantityHeld,
            @unitWeightKilogram,
            @unitHeightCentimeter,
            @unitWidthCentimeter,
            @unitDepthCentimeter,
            @activeStatus
        )

        IF EXISTS (
            SELECT 1
            FROM [dbo].[Product] P
            INNER JOIN #ProductTemp PT ON P.[ManufacturerId] = PT.[ManufacturerId]
            AND P.[ProductName] = PT.[ProductName]
        )
        BEGIN
            DROP TABLE #ProductTemp;
            THROW 50000, 'Product already exists, please update the existing record.', 1;
        END

        DECLARE @InsertedProducts TABLE ([ProductId] UNIQUEIDENTIFIER);

        INSERT INTO [dbo].[Product]
        (
            [ProductSubCategoryId],
            [ProductName],
            [ProductDescription],
            [ManufacturerId],
            [ManufacturerPartNumber],
            [ProductImage],
            [ProductCountryOfOriginId],
            [ProductFamilyId],
            [WholesaleCartonFlag],
            [WholesaleCartonBarcode],
            [WholesaleUnitQuantityPerCarton],
            [WholesaleCartonStockQuantityHeld],
            [WholesaleCartonWeightKilogram],
            [WholesaleCartonHeightCentimeter],
            [WholesaleCartonWidthCentimeter],
            [WholesaleCartonDepthCentimeter],
            [WholesalePalletFlag],
            [WholesaleCartonQuantityPerPallet],
            [WholesalePalletHeightCentimeter],
            [WholesalePalletWidthCentimeter],
            [WholesalePalletDepthCentimeter],
            [WholesalePalletWeightKilogram],
            [WholesalePalletTotalHeightCentimeter],
            [WholesalePalletTotalWidthCentimeter],
            [WholesalePalletTotalDepthCentimeter],
            [WholesalePalletTotalWeightKilogram],
            [WholesaleReorderFlag],
            [UnitBarcode],
            [UnitPrice],
            [UnitMinimumOrderQuantity],
            [UnitMinimumStockQuantity],
            [UnitStockQuantityHeld],
            [UnitWeightKilogram],
            [UnitHeightCentimeter],
            [UnitWidthCentimeter],
            [UnitDepthCentimeter],
            [ActiveStatus]
        )
        OUTPUT inserted.[ProductId] INTO @InsertedProducts
        SELECT
            [ProductSubCategoryId],
            [ProductName],
            [ProductDescription],
            [ManufacturerId],
            [ManufacturerPartNumber],
            [ProductImage],
            [ProductCountryOfOriginId],
            [ProductFamilyId],
            [WholesaleCartonFlag],
            [WholesaleCartonBarcode],
            [WholesaleUnitQuantityPerCarton],
            [WholesaleCartonStockQuantityHeld],
            [WholesaleCartonWeightKilogram],
            [WholesaleCartonHeightCentimeter],
            [WholesaleCartonWidthCentimeter],
            [WholesaleCartonDepthCentimeter],
            [WholesalePalletFlag],
            [WholesaleCartonQuantityPerPallet],
            [WholesalePalletHeightCentimeter],
            [WholesalePalletWidthCentimeter],
            [WholesalePalletDepthCentimeter],
            [WholesalePalletWeightKilogram],
            [WholesalePalletTotalHeightCentimeter],
            [WholesalePalletTotalWidthCentimeter],
            [WholesalePalletTotalDepthCentimeter],
            [WholesalePalletTotalWeightKilogram],
            [WholesaleReorderFlag],
            [UnitBarcode],
            [UnitPrice],
            [UnitMinimumOrderQuantity],
            [UnitMinimumStockQuantity],
            [UnitStockQuantityHeld],
            [UnitWeightKilogram],
            [UnitHeightCentimeter],
            [UnitWidthCentimeter],
            [UnitDepthCentimeter],
            [ActiveStatus]
        FROM #ProductTemp;

        SELECT TOP 1 @productId = [ProductId] FROM @InsertedProducts;

        DROP TABLE #ProductTemp;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END