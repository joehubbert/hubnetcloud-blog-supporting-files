CREATE PROCEDURE [dbo].[spUpdatePromotionTargetType]
	@activeStatus BIT,
	@promotionTargetType NVARCHAR(50),
	@promotionTargetTypeDescription NVARCHAR(255) = NULL,
	@promotionTargetTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionTargetType]
			SET 
				[ActiveStatus] = @activeStatus,
				[PromotionTargetType] = @promotionTargetType,
				[PromotionTargetTypeDescription] = @promotionTargetTypeDescription
			WHERE [PromotionTargetTypeId] = @promotionTargetTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END