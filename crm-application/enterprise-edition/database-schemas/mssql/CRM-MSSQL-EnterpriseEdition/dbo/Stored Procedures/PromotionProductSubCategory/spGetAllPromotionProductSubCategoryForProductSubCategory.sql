CREATE PROCEDURE [dbo].[spGetAllPromotionProductSubCategoryForProductSubCategory]
	@productSubCategoryId UNIQUEIDENTIFIER
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
			WHERE [Product Sub Category Id] = @productSubCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END