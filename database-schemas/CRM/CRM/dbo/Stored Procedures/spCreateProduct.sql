CREATE PROCEDURE [dbo].[spCreateProduct]
	@activeStatus BIT,
    @productCategoryId UNIQUEIDENTIFIER,
    @productName NVARCHAR(50),
    @supplierId UNIQUEIDENTIFIER,
    @unitPrice MONEY,
    @unitMinimumOrderQuantity INT,
    @unitMinimumStockQuantity INT = NULL,
    @unitStockQuantityHeld INT,
    @wholesaleCartonStockQuantityHeld INT,
    @wholesalePricePerUnit MONEY,
    @wholesaleReorderFlag BIT,
    @wholesaleUnitQuantityPerCarton INT
AS

CREATE TABLE #ProductTemp
(
    [ProductCategoryId] UNIQUEIDENTIFIER NOT NULL,
    [SupplierId] UNIQUEIDENTIFIER NOT NULL,
    [ProductName] NVARCHAR(50) NOT NULL,
    [WholesalePricePerUnit] MONEY NOT NULL,
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
    [ProductCategoryId],
    [SupplierId],
    [ProductName],
    [WholesalePricePerUnit],
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
    @productCategoryId,
    @supplierId,
    @productName,
    @wholesalePricePerUnit,
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
INNER JOIN #ProductTemp PT ON P.[SupplierId] = PT.[SupplierId]
AND P.[ProductName] = PT.[ProductName]
WHERE P.[SupplierId] = PT.[SupplierId]
AND P.[ProductName] = PT.[ProductName]
)
THROW 50000, 'Product already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[Product] AS target
USING #ProductTemp AS source
ON target.[SupplierId] = source.[SupplierId]
AND target.[ProductName] = source.[ProductName]
WHEN NOT MATCHED THEN
INSERT
(
    [ProductCategoryId],
    [SupplierId],
    [ProductName],
    [WholesalePricePerUnit],
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
    source.[ProductCategoryId],
    source.[SupplierId],
    source.[ProductName],
    source.[WholesalePricePerUnit],
    source.[WholesaleUnitQuantityPerCarton],
    source.[WholesaleCartonStockQuantityHeld],
    source.[WholesaleReorderFlag],
    source.[UnitPrice],
    source.[UnitMinimumOrderQuantity],
    source.[UnitMinimumStockQuantity],
    source.[UnitStockQuantityHeld],
    source.[ActiveStatus]
);

DROP TABLE #ProductTemp;