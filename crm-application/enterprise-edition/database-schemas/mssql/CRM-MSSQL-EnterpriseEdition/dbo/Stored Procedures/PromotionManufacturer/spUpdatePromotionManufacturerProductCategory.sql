CREATE PROCEDURE [dbo].[spUpdatePromotionManufacturerProductCategory]
	@manufacturerId UNIQUEIDENTIFIER,
	@productCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@promotionManufacturerProductCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionManufacturerProductCategory]
			SET
				[ManufacturerId] = @manufacturerId,
				[ProductCategoryId] = @productCategoryId,
				[PromotionId] = @promotionId
			WHERE [PromotionManufacturerProductCategoryId] = @promotionManufacturerProductCategoryId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END