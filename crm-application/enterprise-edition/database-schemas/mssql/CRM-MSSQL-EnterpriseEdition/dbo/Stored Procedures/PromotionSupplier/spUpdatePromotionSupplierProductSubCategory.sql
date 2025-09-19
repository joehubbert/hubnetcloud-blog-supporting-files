CREATE PROCEDURE [dbo].[spUpdatePromotionSupplierProductSubCategory]
	@productSubCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@promotionSupplierProductSubCategoryId UNIQUEIDENTIFIER,
	@supplierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionSupplierProductSubCategory]
			SET
				[ProductSubCategoryId] = @productSubCategoryId,
				[PromotionId] = @promotionId,
				[SupplierId] = @supplierId
			WHERE [PromotionSupplierProductSubCategoryId] = @promotionSupplierProductSubCategoryId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END