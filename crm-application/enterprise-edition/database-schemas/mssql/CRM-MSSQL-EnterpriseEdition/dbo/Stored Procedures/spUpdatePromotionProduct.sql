CREATE PROCEDURE [dbo].[spUpdatePromotionProduct]
	@productId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@promotionProductId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionProduct]
			SET
				[ProductId] = @productId,
				[PromotionId] = @promotionId
			WHERE [PromotionProductId] = @promotionProductId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END