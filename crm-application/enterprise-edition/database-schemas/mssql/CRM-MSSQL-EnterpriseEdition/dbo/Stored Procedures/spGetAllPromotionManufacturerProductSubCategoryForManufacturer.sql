CREATE PROCEDURE [dbo].[spGetAllPromotionManufacturerProductSubCategoryForManufacturer]
	@manufacturerId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Manufacturer Product Sub Category Id],
			[Promotion Id],
			[Promotion Name],
			[Manufacturer Id],
			[Manufacturer Name],
			[Product Sub Category Id],
			[Product Sub Category]
			FROM [dbo].[vwPromotionManufacturerProductSubCategory]
			WHERE [Manufacturer Id] = @manufacturerId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END