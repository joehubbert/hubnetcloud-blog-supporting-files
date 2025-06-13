CREATE PROCEDURE [dbo].[spUpdatePromotionManufacturerProductSubCategory]
	@manufacturerId UNIQUEIDENTIFIER,
	@productSubCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@promotionManufacturerProductSubCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionManufacturerProductSubCategory]
			SET
				[ManufacturerId] = @manufacturerId,
				[ProductSubCategoryId] = @productSubCategoryId,
				[PromotionId] = @promotionId
			WHERE [PromotionManufacturerProductSubCategoryId] = @promotionManufacturerProductSubCategoryId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END