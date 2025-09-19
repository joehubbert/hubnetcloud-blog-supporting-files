CREATE PROCEDURE [dbo].[spCreatePromotionSupplier]
	@promotionId UNIQUEIDENTIFIER,
	@supplierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PromotionSupplierTemp
			(
				[SupplierId] UNIQUEIDENTIFIER NOT NULL,
				[PromotionId] UNIQUEIDENTIFIER NOT NULL
			)

			INSERT INTO #PromotionSupplierTemp
			(
				[SupplierId],
				[PromotionId]
			)
			VALUES
			(
				@supplierId,
				@promotionId
			)

			MERGE INTO [dbo].[PromotionSupplier] AS target
			USING #PromotionSupplierTemp AS source
			ON target.[SupplierId] = source.[SupplierId]
			AND target.[PromotionId] = source.[PromotionId]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[SupplierId],
				[PromotionId]
			)
			VALUES
			(
				source.[SupplierId],
				source.[PromotionId]
			);

			DROP TABLE #PromotionSupplierTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END