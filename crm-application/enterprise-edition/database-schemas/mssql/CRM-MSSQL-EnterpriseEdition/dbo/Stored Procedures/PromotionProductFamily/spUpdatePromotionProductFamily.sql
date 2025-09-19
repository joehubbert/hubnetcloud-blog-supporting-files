CREATE PROCEDURE [dbo].[spUpdatePromotionProductFamily]
    @productFamilyId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@promotionProductFamilyId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionProductFamily]
			SET
				[ProductFamilyId] = @productFamilyId,
				[PromotionId] = @promotionId
			WHERE [PromotionProductFamilyId] = @promotionProductFamilyId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END