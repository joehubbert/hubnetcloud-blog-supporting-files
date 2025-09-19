CREATE PROCEDURE [dbo].[spUpdatePromotionManufacturer]
	@manufacturerId UNIQUEIDENTIFIER,
	@promotionId UNIQUEIDENTIFIER,
	@promotionManufacturerId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[PromotionManufacturer]
			SET
				[ManufacturerId] = @manufacturerId,
				[PromotionId] = @promotionId
			WHERE [PromotionManufacturerId] = @promotionManufacturerId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END