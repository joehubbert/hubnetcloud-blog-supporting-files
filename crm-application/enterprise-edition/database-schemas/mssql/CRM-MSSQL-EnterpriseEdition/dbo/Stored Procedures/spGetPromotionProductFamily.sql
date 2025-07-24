CREATE PROCEDURE [dbo].[spGetPromotionProductFamily]
	@promotionProductFamilyId UNIQUEIDENTIFIER
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
			[Product Family],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwPromotionProductFamily]
			WHERE [Promotion Product Family Id] = @promotionProductFamilyId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END