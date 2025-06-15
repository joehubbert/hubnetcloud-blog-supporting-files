CREATE PROCEDURE [dbo].[spGetPromotionManufacturerProductSubCategory]
	@promotionManufacturerProductSubCategoryId UNIQUEIDENTIFIER
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
			[Product Sub Category],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwPromotionManufacturerProductSubCategory]
			WHERE [Promotion Manufacturer Product Sub Category Id] = @promotionManufacturerProductSubCategoryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END