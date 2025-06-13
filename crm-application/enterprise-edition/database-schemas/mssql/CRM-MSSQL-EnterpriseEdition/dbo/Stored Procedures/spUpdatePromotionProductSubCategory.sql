CREATE PROCEDURE [dbo].[spUpdatePromotionProductSubCategory]
    @productSubCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@promotionProductSubCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionProductSubCategory]
			SET
				[ProductSubCategoryId] = @productSubCategoryId,
				[PromotionId] = @promotionId
			WHERE [PromotionProductSubCategoryId] = @promotionProductSubCategoryId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END