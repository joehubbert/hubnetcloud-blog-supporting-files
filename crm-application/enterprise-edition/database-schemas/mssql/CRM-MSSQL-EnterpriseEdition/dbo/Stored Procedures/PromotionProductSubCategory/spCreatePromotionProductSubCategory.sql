CREATE PROCEDURE [dbo].[spCreatePromotionProductSubCategory]
	@productSubCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionProductSubCategoryTemp
			(
				[ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #PromotionProductSubCategoryTemp
			(
				[ProductSubCategoryId],
				[PromotionId]
			)
			VALUES
			(
				@productSubCategoryId,
				@promotionId
			)

			MERGE INTO [dbo].[PromotionProductSubCategory] AS target
			USING #PromotionProductSubCategoryTemp AS source
			ON target.[ProductSubCategoryId] = source.[ProductSubCategoryId]
			AND target.[PromotionId] = source.[PromotionId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ProductSubCategoryId],
				[PromotionId]
			)
			VALUES
			(
				source.[ProductSubCategoryId],
				source.[PromotionId]
			);

			DROP TABLE #PromotionProductSubCategoryTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END