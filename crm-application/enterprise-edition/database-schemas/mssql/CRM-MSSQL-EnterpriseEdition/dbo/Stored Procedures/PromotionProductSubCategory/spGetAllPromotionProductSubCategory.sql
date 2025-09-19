CREATE PROCEDURE [dbo].[spGetAllPromotionProductSubCategory]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Product Sub Category Id],
			[Promotion Id],
			[Promotion Name],
			[Product Sub Category Id],
			[Product Sub Category]
			FROM [dbo].[vwPromotionProductSubCategory]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END