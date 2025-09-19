CREATE PROCEDURE [dbo].[spDeletePromotionSupplierProductSupplier]
	@promotionSupplierProductSubCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE FROM [dbo].[PromotionSupplierProductSubCategory]
		WHERE [PromotionSupplierProductSubCategoryId] = @promotionSupplierProductSubCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END