CREATE PROCEDURE [dbo].[spCreatePromotionSupplierProductCategory]
	@productCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@supplierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionSupplierProductCategoryTemp
			(
				[SupplierId] UNIQUEIDENTIFIER NOT NULL,
				[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #PromotionSupplierProductCategoryTemp
			(
				[SupplierId],
				[ProductCategoryId],
				[PromotionId]
			)
			VALUES
			(
				@supplierId,
				@productCategoryId,
				@promotionId
			)

			MERGE INTO [dbo].[PromotionSupplierProductCategory] AS target
			USING #PromotionSupplierProductCategoryTemp AS source
			ON target.[SupplierId] = source.[SupplierId]
			AND target.[ProductCategoryId] = source.[ProductCategoryId]
			AND target.[PromotionId] = source.[PromotionId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[SupplierId],
				[ProductCategoryId],
				[PromotionId]
			)
			VALUES
			(
				source.[SupplierId],
				source.[ProductCategoryId],
				source.[PromotionId]
			);

			DROP TABLE #PromotionSupplierProductCategoryTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END