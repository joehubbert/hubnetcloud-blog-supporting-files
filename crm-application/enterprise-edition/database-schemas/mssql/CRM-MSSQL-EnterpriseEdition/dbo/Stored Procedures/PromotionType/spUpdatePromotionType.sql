CREATE PROCEDURE [dbo].[spUpdatePromotionType]
	@activeStatus BIT,
	@promotionType NVARCHAR(50),
	@promotionTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionType]
			SET
				[ActiveStatus] = @activeStatus,
				[PromotionType] = @promotionType
			WHERE [PromotionTypeId] = @promotionTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END