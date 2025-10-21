CREATE PROCEDURE [dbo].[spGetAllCountry]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Country Id],
			[Master Data Type Id],
			[Master Data Type],
			[Master Data Type Code],
			[Is Custom],
			[ISO 3166-1 Alpha 2 Country Code],
			[Country English Name],
			[Company Configuration Id],
			[Company Name],
			[Active Status]
			FROM [dbo].[vwCountry]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END