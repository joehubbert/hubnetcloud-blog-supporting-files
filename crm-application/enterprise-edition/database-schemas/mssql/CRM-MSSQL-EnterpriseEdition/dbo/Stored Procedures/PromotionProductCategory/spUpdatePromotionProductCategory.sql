CREATE PROCEDURE [dbo].[spUpdatePromotionProductCategory]
    @productCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@promotionProductCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionProductCategory]
			SET
				[ProductCategoryId] = @productCategoryId,
				[PromotionId] = @promotionId
			WHERE [PromotionProductCategoryId] = @promotionProductCategoryId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END