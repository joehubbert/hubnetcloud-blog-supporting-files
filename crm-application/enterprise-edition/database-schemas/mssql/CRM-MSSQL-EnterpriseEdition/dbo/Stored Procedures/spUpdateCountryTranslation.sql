CREATE PROCEDURE [dbo].[spUpdateCountryTranslation]
    @activeStatus BIT,
	@countryId UNIQUEIDENTIFIER,
	@countryTranslationId UNIQUEIDENTIFIER,
	@bcp47LanguageTagCode NVARCHAR(5),
	@localisedCountryName NVARCHAR(100)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CountryTranslation]
			SET
				[ActiveStatus] = @activeStatus,
				[CountryId] = @countryId,
				[BCP47LanguageTagCode] = @bcp47LanguageTagCode,
				[LocalisedCountryName] = @localisedCountryName
			WHERE [CountryTranslationId] = @countryTranslationId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END