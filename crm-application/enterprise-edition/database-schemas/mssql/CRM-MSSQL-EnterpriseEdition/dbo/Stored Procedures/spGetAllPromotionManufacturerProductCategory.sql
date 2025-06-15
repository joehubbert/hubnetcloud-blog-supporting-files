CREATE PROCEDURE [dbo].[spGetAllPromotionManufacturerProductCategory]
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
			[Product Category],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwPromotionManufacturerProductCategory]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END