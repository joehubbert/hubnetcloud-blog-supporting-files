CREATE PROCEDURE [dbo].[spCreateProduct]
	@activeStatus BIT,
    @productCategoryId UNIQUEIDENTIFIER,
    @productName NVARCHAR(50),
    @supplierId UNIQUEIDENTIFIER,
    @unitPrice MONEY,
    @unitStockQuantityHeld INT,
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
    [WholesaleReorderFlag] BIT NOT NULL,
    [WholesaleUnitQuantityPerCarton] INT NOT NULL,
    [UnitPrice] MONEY NOT NULL,
    [UnitStockQuantityHeld] INT NOT NULL,
    [ActiveStatus] BIT NOT NULL
)

INSERT INTO #ProductTemp
(
    [ProductCategoryId],
    [SupplierId],
    [ProductName],
    [WholesalePricePerUnit],
    [WholesaleReorderFlag],
    [WholesaleUnitQuantityPerCarton],
    [UnitPrice],
    [UnitStockQuantityHeld],
    [ActiveStatus]
)
VALUES
(
    @productCategoryId,
    @supplierId,
    @productName,
    @wholesalePricePerUnit,
    @wholesaleReorderFlag,
    @wholesaleUnitQuantityPerCarton,
    @unitPrice,
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
    [WholesaleReorderFlag],
    [UnitPrice],
    [UnitStockQuantityHeld],
    [ActiveStatus]
)
VALUES
(
    source.[ProductCategoryId],
    source.[SupplierId],
    source.[ProductName],
    source.[WholesalePricePerUnit],
    source.[WholesaleReorderFlag],
    source.[WholesaleUnitQuantityPerCarton],
    source.[UnitPrice],
    source.[UnitStockQuantityHeld],
    source.[ActiveStatus]
);

DROP TABLE #ProductTemp;