CREATE PROCEDURE [dbo].[spDeletePromotionSupplierProductCategory]
	@promotionSupplierProductCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE FROM [dbo].[PromotionSupplierProductCategory]
		WHERE [PromotionSupplierProductCategoryId] = @promotionSupplierProductCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END