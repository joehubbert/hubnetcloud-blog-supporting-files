CREATE PROCEDURE [dbo].[spGetAllPromotionProductFamilyForPromotion]
	@promotionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Product Family Id],
			[Promotion Id],
			[Promotion Name],
			[Product Family Id],
			[Product Family]
			FROM [dbo].[vwPromotionProductFamily]
			WHERE [Promotion Id] = @promotionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END