CREATE PROCEDURE [dbo].[spUpdateProduct]
	@activeStatus BIT,
    @manufactuerId UNIQUEIDENTIFIER,
    @productSubCategoryId UNIQUEIDENTIFIER,
    @productId UNIQUEIDENTIFIER,
    @productImage VARBINARY(MAX),
    @productName NVARCHAR(50),
    @unitMinimumOrderQuantity INT,
    @unitMinimumStockQuantity INT,
    @unitPrice MONEY,
    @unitStockQuantityHeld INT,
    @wholesaleCartonStockQuantityHeld INT,
    @wholesaleReorderFlag BIT,
    @wholesaleUnitQuantityPerCarton INT
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

            UPDATE [dbo].[Product]
            SET
                [ActiveStatus] = @activeStatus,
                [ManufacturerId] = @manufactuerId,
                [ProductSubCategoryId] = @productSubCategoryId,
                [ProductName] = @productName,
                [ProductImage] = @productImage,
                [UnitMinimumOrderQuantity] = @unitMinimumOrderQuantity,
                [UnitMinimumStockQuantity] = @unitMinimumStockQuantity,
                [UnitPrice] = @unitPrice,
                [UnitStockQuantityHeld] = @unitStockQuantityHeld,
                [WholesaleCartonStockQuantityHeld] = @wholesaleCartonStockQuantityHeld,
                [WholesaleReorderFlag] = @wholesaleReorderFlag,
                [WholesaleUnitQuantityPerCarton] = @wholesaleUnitQuantityPerCarton
            WHERE [ProductId] = @productId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END