CREATE PROCEDURE [dbo].[spGetAllPromotionManufacturerProductCategoryForProductCategory]
	@productCategoryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Manufacturer Product Category Id],
			[Promotion Id],
			[Promotion Name],
			[Manufacturer Id],
			[Manufacturer Name],
			[Product Category Id],
			[Product Category]
			FROM [dbo].[vwPromotionManufacturerProductCategory]
			WHERE [Product Category Id] = @productCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END