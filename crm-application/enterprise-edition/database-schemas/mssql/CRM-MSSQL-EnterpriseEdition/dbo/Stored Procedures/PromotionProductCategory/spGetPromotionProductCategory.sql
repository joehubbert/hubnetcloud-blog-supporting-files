CREATE PROCEDURE [dbo].[spGetPromotionProductCategory]
	@promotionProductCategoryId UNIQUEIDENTIFIER
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
			[Product Category],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwPromotionProductCategory]
			WHERE [Promotion Product Category Id] = @promotionProductCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END