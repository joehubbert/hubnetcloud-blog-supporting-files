CREATE PROCEDURE [dbo].[spGetAllCountryTranslationForCountry]
	@countryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Country Translation Id],
			[BCP 47 Language Tag Code],
			[Localised Country Name],
			[Country Id],
			[Country English Name],
			[Active Status]
			FROM [dbo].[vwCountryTranslation]
			WHERE [Country Id] = @countryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END