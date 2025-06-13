CREATE PROCEDURE [dbo].[spCreatePromotionManufacturerProductSubCategory]
	@manufacturerId UNIQUEIDENTIFIER,
	@productSubCategoryId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionManufacturerProductSubCategoryTemp
			(
				[ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
				[ProductSubCategoryId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #PromotionManufacturerProductSubCategoryTemp
			(
				[ManufacturerId],
				[ProductSubCategoryId],
				[PromotionId]
			)
			VALUES
			(
				@manufacturerId,
				@productSubCategoryId,
				@promotionId
			)

			MERGE INTO [dbo].[PromotionManufacturerProductSubCategory] AS target
			USING #PromotionManufacturerProductSubCategoryTemp AS source
			ON target.[ManufacturerId] = source.[ManufacturerId]
			AND target.[ProductSubCategoryId] = source.[ProductSubCategoryId]
			AND target.[PromotionId] = source.[PromotionId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ManufacturerId],
				[ProductSubCategoryId],
				[PromotionId]
			)
			VALUES
			(
				source.[ManufacturerId],
				source.[ProductSubCategoryId],
				source.[PromotionId]
			);

			DROP TABLE #PromotionManufacturerProductSubCategoryTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END