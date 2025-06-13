CREATE PROCEDURE [dbo].[spCreatePromotionManufacturerProductCategory]
	@manufacturerId UNIQUEIDENTIFIER,
	@productCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionManufacturerProductCategoryTemp
			(
				[ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
				[ProductCategoryId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #PromotionManufacturerProductCategoryTemp
			(
				[ManufacturerId],
				[ProductCategoryId],
				[PromotionId]
			)
			VALUES
			(
				@manufacturerId,
				@productCategoryId,
				@promotionId
			)

			MERGE INTO [dbo].[PromotionManufacturerProductCategory] AS target
			USING #PromotionManufacturerProductCategoryTemp AS source
			ON target.[ManufacturerId] = source.[ManufacturerId]
			AND target.[ProductCategoryId] = source.[ProductCategoryId]
			AND target.[PromotionId] = source.[PromotionId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ManufacturerId],
				[ProductCategoryId],
				[PromotionId]
			)
			VALUES
			(
				source.[ManufacturerId],
				source.[ProductCategoryId],
				source.[PromotionId]
			);

			DROP TABLE #PromotionManufacturerProductCategoryTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END