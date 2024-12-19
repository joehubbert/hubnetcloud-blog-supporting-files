CREATE PROCEDURE [dbo].[spUpdateProduct]
	@activeStatus BIT,
    @productCategoryId UNIQUEIDENTIFIER,
    @productId UNIQUEIDENTIFIER,
    @productName NVARCHAR(50),
    @supplierId UNIQUEIDENTIFIER,
    @unitPrice MONEY,
    @unitStockQuantityHeld INT,
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
    [UnitPrice] = @unitPrice,
    [UnitStockQuantityHeld] = @unitStockQuantityHeld,
    [WholesalePricePerUnit] = @wholesalePricePerUnit,
    [WholesaleReorderFlag] = @wholesaleReorderFlag,
    [WholesaleUnitQuantityPerCarton] = @wholesaleUnitQuantityPerCarton
WHERE [ProductId] = @productId