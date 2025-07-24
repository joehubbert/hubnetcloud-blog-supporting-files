CREATE PROCEDURE [dbo].[spCreatePromotionProductFamily]
	@productFamilyId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionProductFamilyTemp
			(
				[ProductFamilyId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #PromotionProductFamilyTemp
			(
				[ProductFamilyId],
				[PromotionId]
			)
			VALUES
			(
				@productFamilyId,
				@promotionId
			)

			MERGE INTO [dbo].[PromotionProductFamily] AS target
			USING #PromotionProductFamilyTemp AS source
			ON target.[ProductFamilyId] = source.[ProductFamilyId]
			AND target.[PromotionId] = source.[PromotionId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ProductFamilyId],
				[PromotionId]
			)
			VALUES
			(
				source.[ProductFamilyId],
				source.[PromotionId]
			);

			DROP TABLE #PromotionProductFamilyTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END