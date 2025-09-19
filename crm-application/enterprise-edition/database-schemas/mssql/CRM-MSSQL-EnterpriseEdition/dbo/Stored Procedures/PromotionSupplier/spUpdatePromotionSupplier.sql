CREATE PROCEDURE [dbo].[spUpdatePromotionSupplier]
	@promotionId UNIQUEIDENTIFIER,
	@promotionSupplierId UNIQUEIDENTIFIER,
	@supplierId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionSupplier]
			SET
				[PromotionId] = @promotionId,
				[SupplierId] = @supplierId
			WHERE [PromotionSupplierId] = @promotionSupplierId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END