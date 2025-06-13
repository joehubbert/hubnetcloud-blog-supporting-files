CREATE PROCEDURE [dbo].[spCreatePromotionProductCategory]
	@productCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionProductCategoryTemp
			(
				[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #PromotionProductCategoryTemp
			(
				[ProductCategoryId],
				[PromotionId]
			)
			VALUES
			(
				@productCategoryId,
				@promotionId
			)

			MERGE INTO [dbo].[PromotionProductCategory] AS target
			USING #PromotionProductCategoryTemp AS source
			ON target.[ProductCategoryId] = source.[ProductCategoryId]
			AND target.[PromotionId] = source.[PromotionId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ProductCategoryId],
				[PromotionId]
			)
			VALUES
			(
				source.[ProductCategoryId],
				source.[PromotionId]
			);

			DROP TABLE #PromotionProductCategoryTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END