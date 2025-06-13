CREATE PROCEDURE [dbo].[spCreatePromotionManufacturer]
	@manufacturerId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionManufacturerTemp
			(
				[ManufacturerId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #PromotionManufacturerTemp
			(
				[ManufacturerId],
				[PromotionId]
			)
			VALUES
			(
				@manufacturerId,
				@promotionId
			)

			MERGE INTO [dbo].[PromotionManufacturer] AS target
			USING #PromotionManufacturerTemp AS source
			ON target.[ManufacturerId] = source.[ManufacturerId]
			AND target.[PromotionId] = source.[PromotionId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ManufacturerId],
				[PromotionId]
			)
			VALUES
			(
				source.[ManufacturerId],
				source.[PromotionId]
			);

			DROP TABLE #PromotionManufacturerTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END