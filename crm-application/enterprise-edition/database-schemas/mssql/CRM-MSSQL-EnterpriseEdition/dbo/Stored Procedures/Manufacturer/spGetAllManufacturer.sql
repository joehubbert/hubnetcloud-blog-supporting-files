CREATE PROCEDURE [dbo].[spGetAllManufacturer]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Manufacturer Id],
			[Manufacturer Name],
			[Address Line 1],
			[Address Line 2],
			[Address Line 3],
			[Address Line 4],
			[Address Line 5],
			[Telephone Number],
			[Email Address],
			[VAT Registered],
			[VAT Number],
			[Active Status]
			FROM [dbo].[vwManufacturer]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END