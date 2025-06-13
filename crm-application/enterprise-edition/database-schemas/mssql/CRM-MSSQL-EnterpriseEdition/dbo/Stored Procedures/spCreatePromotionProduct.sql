CREATE PROCEDURE [dbo].[spCreatePromotionProduct]
	@productId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionProductTemp
			(
				[ProductId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #PromotionProductTemp
			(
				[ProductId],
				[PromotionId]
			)
			VALUES
			(
				@productId,
				@promotionId
			)

			MERGE INTO [dbo].[PromotionProduct] AS target
			USING #PromotionProductTemp AS source
			ON target.[ProductId] = source.[ProductId]
			AND target.[PromotionId] = source.[PromotionId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ProductId],
				[PromotionId]
			)
			VALUES
			(
				source.[ProductId],
				source.[PromotionId]
			);

			DROP TABLE #PromotionProductTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END