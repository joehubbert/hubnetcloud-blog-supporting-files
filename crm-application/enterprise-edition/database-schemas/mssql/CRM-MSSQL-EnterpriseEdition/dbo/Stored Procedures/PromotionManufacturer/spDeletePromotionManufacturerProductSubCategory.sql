CREATE PROCEDURE [dbo].[spDeletePromotionManufacturerProductSubCategory]
	@promotionManufacturerProductSubCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE FROM [dbo].[PromotionManufacturerProductSubCategory]
		WHERE [PromotionManufacturerProductSubCategoryId] = @promotionManufacturerProductSubCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END