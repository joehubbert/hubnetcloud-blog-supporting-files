CREATE PROCEDURE [dbo].[spDeletePromotionManufacturerProductCategory]
	@promotionManufacturerProductCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE FROM [dbo].[PromotionManufacturerProductCategory]
		WHERE [PromotionManufacturerProductCategoryId] = @promotionManufacturerProductCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END