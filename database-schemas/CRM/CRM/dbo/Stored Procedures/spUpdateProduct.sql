CREATE PROCEDURE [dbo].[spUpdateProduct]
	@activeStatus BIT,
    @productCategoryId UNIQUEIDENTIFIER,
    @productId UNIQUEIDENTIFIER,
    @productName NVARCHAR(50),
    @supplierId UNIQUEIDENTIFIER,
    @unitMinimumOrderQuantity INT,
    @unitMinimumStockQuantity INT,
    @unitPrice MONEY,
    @unitStockQuantityHeld INT,
    @wholesaleCartonStockQuantityHeld INT,
    @wholesalePricePerUnit MONEY,
    @wholesaleReorderFlag BIT,
    @wholesaleUnitQuantityPerCarton INT
AS

UPDATE [dbo].[Product]
SET
    [ActiveStatus] = @activeStatus,
    [ProductCategoryId] = @productCategoryId,
    [ProductName] = @productName,
    [SupplierId] = @supplierId,
    [UnitMinimumOrderQuantity] = @unitMinimumOrderQuantity,
    [UnitMinimumStockQuantity] = @unitMinimumStockQuantity,
    [UnitPrice] = @unitPrice,
    [UnitStockQuantityHeld] = @unitStockQuantityHeld,
    [WholesaleCartonStockQuantityHeld] = @wholesaleCartonStockQuantityHeld,
    [WholesalePricePerUnit] = @wholesalePricePerUnit,
    [WholesaleReorderFlag] = @wholesaleReorderFlag,
    [WholesaleUnitQuantityPerCarton] = @wholesaleUnitQuantityPerCarton
WHERE [ProductId] = @productId