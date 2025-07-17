CREATE PROCEDURE [dbo].[spUpdateProduct]
	@activeStatus BIT,
    @manufactuerId UNIQUEIDENTIFIER,
    @manufacturerPartNumber NVARCHAR(50) = NULL,
    @productCountryOfOriginId UNIQUEIDENTIFIER,
    @productDescription NVARCHAR(255) = NULL,
    @productFamilyId UNIQUEIDENTIFIER = NULL,
    @productSubCategoryId UNIQUEIDENTIFIER,
    @productId UNIQUEIDENTIFIER,
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

            DECLARE @wholesaleCartonWeightKilogram DECIMAL(5, 2)
            SET @wholesaleCartonWeightKilogram = SUM((@unitWeightKilogram * @wholesaleUnitQuantityPerCarton) + 0.02) --0.02 is the packaging allowance

            UPDATE [dbo].[Product]
            SET
                [ActiveStatus] = @activeStatus,
                [ManufacturerId] = @manufactuerId,
                [ManufacturerPartNumber] = @manufacturerPartNumber,
                [ProductCountryOfOriginId] = @productCountryOfOriginId,
                [ProductDescription] = @productDescription,
                [ProductFamilyId] = @productFamilyId,
                [ProductSubCategoryId] = @productSubCategoryId,
                [ProductName] = @productName,
                [ProductImage] = @productImage,
                [UnitBarcode] = @unitBarcode,
                [UnitMinimumOrderQuantity] = @unitMinimumOrderQuantity,
                [UnitMinimumStockQuantity] = @unitMinimumStockQuantity,
                [UnitPrice] = @unitPrice,
                [UnitStockQuantityHeld] = @unitStockQuantityHeld,
                [UnitDepthCentimeter] = @unitDepthCentimeter,
                [UnitHeightCentimeter] = @unitHeightCentimeter,
                [UnitWeightKilogram] = @unitWeightKilogram,
                [UnitWidthCentimeter] = @unitWidthCentimeter,
                [WholesaleCartonBarcode] = @wholesaleCartonBarcode,
                [WholesaleCartonStockQuantityHeld] = @wholesaleCartonStockQuantityHeld,
                [WholesaleCartonDepthCentimeter] = @wholesaleCartonDepthCentimeter,
                [WholesaleCartonHeightCentimeter] = @wholesaleCartonHeightCentimeter,
                [WholesaleCartonWeightKilogram] = @wholesaleCartonWeightKilogram,
                [WholesaleCartonWidthCentimeter] = @wholesaleCartonWidthCentimeter,
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