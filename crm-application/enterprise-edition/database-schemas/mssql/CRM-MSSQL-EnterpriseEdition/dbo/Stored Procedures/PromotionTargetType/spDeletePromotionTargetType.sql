CREATE PROCEDURE [dbo].[spDeletePromotionTargetType]
	@promotionTargetTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

		DELETE PTT
		FROM [dbo].[PromotionTargetType] PTT
		INNER JOIN [dbo].[MasterDataType] MDT ON PTT.[MasterDataTypeId] = MDT.[MasterDataTypeId]
		WHERE PTT.[PromotionTargetTypeId] = @promotionTargetTypeId
		AND MDT.[IsCustom] = 1

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END