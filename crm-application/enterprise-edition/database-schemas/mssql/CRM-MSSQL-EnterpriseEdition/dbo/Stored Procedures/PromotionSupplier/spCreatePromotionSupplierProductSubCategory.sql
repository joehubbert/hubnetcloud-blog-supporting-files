CREATE PROCEDURE [dbo].[spCreatePromotionSupplierProductSubCategory]
	@productSubCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@supplierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionSupplierProductSubCategoryTemp
			(
				[SupplierId] UNIQUEIDENTIFIER NOT NULL,
				[ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #PromotionSupplierProductSubCategoryTemp
			(
				[SupplierId],
				[ProductSubCategoryId],
				[PromotionId]
			)
			VALUES
			(
				@supplierId,
				@productSubCategoryId,
				@promotionId
			)

			MERGE INTO [dbo].[PromotionSupplierProductSubCategory] AS target
			USING #PromotionSupplierProductSubCategoryTemp AS source
			ON target.[SupplierId] = source.[SupplierId]
			AND target.[ProductSubCategoryId] = source.[ProductSubCategoryId]
			AND target.[PromotionId] = source.[PromotionId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[SupplierId],
				[ProductSubCategoryId],
				[PromotionId]
			)
			VALUES
			(
				source.[SupplierId],
				source.[ProductSubCategoryId],
				source.[PromotionId]
			);

			DROP TABLE #PromotionSupplierProductSubCategoryTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END