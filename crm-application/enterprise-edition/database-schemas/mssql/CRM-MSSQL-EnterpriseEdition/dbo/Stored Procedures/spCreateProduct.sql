CREATE PROCEDURE [dbo].[spCreateProduct]
	@activeStatus BIT,
    @manufactuerId UNIQUEIDENTIFIER,
    @productSubCategoryId UNIQUEIDENTIFIER,
    @productId UNIQUEIDENTIFIER OUTPUT,
    @productImage VARBINARY(MAX) = NULL,
    @productName NVARCHAR(50),
    @unitPrice MONEY,
    @unitMinimumOrderQuantity INT,
    @unitMinimumStockQuantity INT = NULL,
    @unitStockQuantityHeld INT,
    @wholesaleCartonStockQuantityHeld INT,
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
                [ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
                [ProductImage] VARBINARY(MAX) NULL,
                [WholesaleUnitQuantityPerCarton] INT NOT NULL,
                [WholesaleCartonStockQuantityHeld] INT NOT NULL,
                [WholesaleReorderFlag] BIT NOT NULL,
                [UnitPrice] MONEY NOT NULL,
                [UnitMinimumOrderQuantity] INT NOT NULL,
                [UnitMinimumStockQuantity] INT NULL,
                [UnitStockQuantityHeld] INT NOT NULL,
                [ActiveStatus] BIT NOT NULL
            )

            INSERT INTO #ProductTemp
            (
                [ProductSubCategoryId],
                [ProductName],
                [ManufacturerId],
                [ProductImage],
                [WholesaleUnitQuantityPerCarton],
                [WholesaleCartonStockQuantityHeld],
                [WholesaleReorderFlag],
                [UnitPrice],
                [UnitMinimumOrderQuantity],
                [UnitMinimumStockQuantity],
                [UnitStockQuantityHeld],
                [ActiveStatus]
            )
            VALUES
            (
                @productSubCategoryId,
                @productName,
                @manufactuerId,
                @productImage,
                @wholesaleUnitQuantityPerCarton,
                @wholesaleCartonStockQuantityHeld,
                @wholesaleReorderFlag,
                @unitPrice,
                @unitMinimumOrderQuantity,
                @unitMinimumStockQuantity,
                @unitStockQuantityHeld,
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
                [ManufacturerId],
                [ProductImage],
                [WholesaleUnitQuantityPerCarton],
                [WholesaleCartonStockQuantityHeld],
                [WholesaleReorderFlag],
                [UnitPrice],
                [UnitMinimumOrderQuantity],
                [UnitMinimumStockQuantity],
                [UnitStockQuantityHeld],
                [ActiveStatus]
            )
            VALUES
            (
                source.[ProductSubCategoryId],
                source.[ProductName],
                source.[ManufacturerId],
                source.[ProductImage],
                source.[WholesaleUnitQuantityPerCarton],
                source.[WholesaleCartonStockQuantityHeld],
                source.[WholesaleReorderFlag],
                source.[UnitPrice],
                source.[UnitMinimumOrderQuantity],
                source.[UnitMinimumStockQuantity],
                source.[UnitStockQuantityHeld],
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