CREATE PROCEDURE [dbo].[spUpdatePromotionSupplierProductCategory]
	@productCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@promotionSupplierProductCategoryId UNIQUEIDENTIFIER,
	@supplierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionSupplierProductCategory]
			SET
				[ProductCategoryId] = @productCategoryId,
				[PromotionId] = @promotionId,
				[SupplierId] = @supplierId
			WHERE [PromotionSupplierProductCategoryId] = @promotionSupplierProductCategoryId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END