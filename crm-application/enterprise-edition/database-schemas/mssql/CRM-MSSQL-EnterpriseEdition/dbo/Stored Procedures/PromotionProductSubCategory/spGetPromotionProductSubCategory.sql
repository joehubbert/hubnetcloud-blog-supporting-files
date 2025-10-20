CREATE PROCEDURE [dbo].[spGetPromotionProductSubCategory]
	@promotionProductSubCategoryId UNIQUEIDENTIFIER
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
			[Product Sub Category],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwPromotionProductSubCategory]
			WHERE [Promotion Product Sub Category Id] = @promotionProductSubCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END