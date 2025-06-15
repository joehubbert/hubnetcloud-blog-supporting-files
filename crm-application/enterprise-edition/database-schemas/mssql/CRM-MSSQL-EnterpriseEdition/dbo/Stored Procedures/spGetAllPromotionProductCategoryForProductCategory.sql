CREATE PROCEDURE [dbo].[spGetAllPromotionProductCategoryForProductCategory]
	@productCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Product Category Id],
			[Promotion Id],
			[Promotion Name],
			[Product Category Id],
			[Product Category]
			FROM [dbo].[vwPromotionProductCategory]
			WHERE [Product Category Id] = @productCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END