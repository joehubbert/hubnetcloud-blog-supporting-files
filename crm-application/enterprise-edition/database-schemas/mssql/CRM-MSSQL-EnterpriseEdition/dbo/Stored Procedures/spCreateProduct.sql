CREATE PROCEDURE [dbo].[spCreateProduct]
	@activeStatus BIT,
    @manufactuerId UNIQUEIDENTIFIER,
    @manufacturerPartNumber NVARCHAR(50) = NULL,
    @productCountryOfOriginId UNIQUEIDENTIFIER,
    @productDescription NVARCHAR(255) = NULL,
    @productFamilyId UNIQUEIDENTIFIER = NULL,
    @productSubCategoryId UNIQUEIDENTIFIER,
    @productId UNIQUEIDENTIFIER OUTPUT,
    @productImage VARBINARY(MAX) = NULL,
    @productName NVARCHAR(50),
    @unitBarcode NVARCHAR(50) = NUll,
    @unitMinimumOrderQuantity INT,
    @unitMinimumStockQuantity INT = NULL,
    @unitPrice MONEY,
    @unitStockQuantityHeld INT,
    @unitDepthCentimeter DECIMAL(5, 2),
    @unitHeightCentimeter DECIMAL(5, 2),
    @unitWeightKilogram DECIMAL(5, 2),
    @unitWidthCentimeter DECIMAL(5, 2),
    @wholesaleCartonBarcode NVARCHAR(50) = NULL,
    @wholesaleCartonDepthCentimeter DECIMAL(5, 2),
    @wholesaleCartonHeightCentimeter DECIMAL(5, 2),
    @wholesaleCartonStockQuantityHeld INT,
    @wholesaleCartonWidthCentimeter DECIMAL(5, 2),
    @wholesaleReorderFlag BIT,
    @wholesaleUnitQuantityPerCarton INT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            CREATE TABLE #ProductTemp
            (
                [ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
                [ProductName] NVARCHAR(50) NOT NULL,
                [ProductDescription] NVARCHAR(255) NULL,
                [ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
                [ManufacturerPartNumber] NVARCHAR(50) NULL,
                [ProductImage] VARBINARY(MAX) NULL,
                [ProductCountryOfOriginId] UNIQUEIDENTIFIER NOT NULL,
                [ProductFamilyId] UNIQUEIDENTIFIER NULL,
                [WholesaleCartonBarcode] NVARCHAR(50) NULL,
                [WholesaleUnitQuantityPerCarton] INT NOT NULL,
                [WholesaleCartonStockQuantityHeld] INT NOT NULL,
                [WholesaleCartonWeightKilogram] DECIMAL(5, 2) NOT NULL,
                [WholesaleCartonHeightCentimeter] DECIMAL(5, 2) NOT NULL,
                [WholesaleCartonWidthCentimeter] DECIMAL(5, 2) NOT NULL,
                [WholesaleCartonDepthCentimeter] DECIMAL(5, 2) NOT NULL,
                [WholesaleReorderFlag] BIT NOT NULL,
                [UnitBarcode] NVARCHAR(50) NULL,
                [UnitPrice] MONEY NOT NULL,
                [UnitMinimumOrderQuantity] INT NOT NULL,
                [UnitMinimumStockQuantity] INT NULL,
                [UnitStockQuantityHeld] INT NOT NULL,
                [UnitWeightKilogram] DECIMAL(5, 2) NOT NULL,
                [UnitHeightCentimeter] DECIMAL(5, 2) NOT NULL,
                [UnitWidthCentimeter] DECIMAL(5, 2) NOT NULL,
                [UnitDepthCentimeter] DECIMAL(5, 2) NOT NULL,
                [ActiveStatus] BIT NOT NULL
            )

            DECLARE @wholesaleCartonWeightKilogram DECIMAL(5, 2)
            SET @wholesaleCartonWeightKilogram = SUM((@unitWeightKilogram * @wholesaleUnitQuantityPerCarton) + 0.02) --0.02 is the packaging allowance

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
                [WholesaleCartonBarcode],
                [WholesaleUnitQuantityPerCarton],
                [WholesaleCartonStockQuantityHeld],
                [WholesaleCartonWeightKilogram],
                [WholesaleCartonHeightCentimeter],
                [WholesaleCartonWidthCentimeter],
                [WholesaleCartonDepthCentimeter],
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
                @manufactuerId,
                @manufacturerPartNumber,
                @productImage,
                @productCountryOfOriginId,
                @productFamilyId,
                @wholesaleCartonBarcode,
                @wholesaleUnitQuantityPerCarton,
                @wholesaleCartonStockQuantityHeld,
                @wholesaleCartonWeightKilogram,
                @wholesaleCartonHeightCentimeter,
                @wholesaleCartonWidthCentimeter,
                @wholesaleCartonDepthCentimeter,
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

            IF EXISTS
            (
            SELECT *
            FROM [dbo].[Product] P
            INNER JOIN #ProductTemp PT ON P.[ManufacturerId] = PT.[ManufacturerId]
            AND P.[ProductName] = PT.[ProductName]
            WHERE P.[ManufacturerId] = PT.[ManufacturerId]
            AND P.[ProductName] = PT.[ProductName]
            )
            THROW 50000, 'Product already exists, please update the existing record.', 1;
            ELSE
            CREATE TABLE #ProductTempOutput
            (
                [ProductId] UNIQUEIDENTIFIER NOT NULL
            )
            MERGE INTO [dbo].[Product] AS target
            USING #ProductTemp AS source
            ON target.[ProductName] = source.[ProductName]
            WHEN NOT MATCHED THEN
            INSERT
            (
                [ProductSubCategoryId],
                [ProductName],
                [ProductDescription],
                [ManufacturerId],
                [ManufacturerPartNumber],
                [ProductImage],
                [ProductCountryOfOriginId],
                [ProductFamilyId],
                [WholesaleCartonBarcode],
                [WholesaleUnitQuantityPerCarton],
                [WholesaleCartonStockQuantityHeld],
                [WholesaleCartonWeightKilogram],
                [WholesaleCartonHeightCentimeter],
                [WholesaleCartonWidthCentimeter],
                [WholesaleCartonDepthCentimeter],
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
                source.[ProductSubCategoryId],
                source.[ProductName],
                source.[ProductDescription],
                source.[ManufacturerId],
                source.[ManufacturerPartNumber],
                source.[ProductImage],
                source.[ProductCountryOfOriginId],
                source.[ProductFamilyId],
                source.[WholesaleCartonBarcode],
                source.[WholesaleUnitQuantityPerCarton],
                source.[WholesaleCartonStockQuantityHeld],
                source.[WholesaleCartonWeightKilogram],
                source.[WholesaleCartonHeightCentimeter],
                source.[WholesaleCartonWidthCentimeter],
                source.[WholesaleCartonDepthCentimeter],
                source.[WholesaleReorderFlag],
                source.[UnitBarcode],
                source.[UnitPrice],
                source.[UnitMinimumOrderQuantity],
                source.[UnitMinimumStockQuantity],
                source.[UnitStockQuantityHeld],
                source.[UnitWeightKilogram],
                source.[UnitHeightCentimeter],
                source.[UnitWidthCentimeter],
                source.[UnitDepthCentimeter],
                source.[ActiveStatus]
            )
            OUTPUT inserted.ProductId INTO #ProductTempOutput;
            SELECT @productId = [ProductId] FROM #ProductTempOutput;

            DROP TABLE #ProductTemp
            DROP TABLE #ProductTempOutput;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END