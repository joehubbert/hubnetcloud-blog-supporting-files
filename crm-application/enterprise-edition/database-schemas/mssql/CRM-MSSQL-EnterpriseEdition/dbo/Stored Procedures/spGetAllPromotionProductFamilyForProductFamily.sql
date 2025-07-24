CREATE PROCEDURE [dbo].[spGetAllPromotionProductFamilyForProductFamily]
	@productFamilyId UNIQUEIDENTIFIER
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
			WHERE [Product Family Id] = @productFamilyId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END