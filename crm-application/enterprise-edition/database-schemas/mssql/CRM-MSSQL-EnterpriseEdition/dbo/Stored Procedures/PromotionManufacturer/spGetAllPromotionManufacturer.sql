CREATE PROCEDURE [dbo].[spGetAllPromotionManufacturer]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Promotion Manufacturer Id],
			[Promotion Id],
			[Promotion Name],
			[Manufacturer Id],
			[Manufacturer Name]
			FROM [dbo].[vwPromotionManufacturer]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END