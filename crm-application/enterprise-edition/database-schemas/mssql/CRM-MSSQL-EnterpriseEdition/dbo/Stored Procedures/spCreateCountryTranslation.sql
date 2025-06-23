CREATE PROCEDURE [dbo].[spCreateCountryTranslation]
    @activeStatus BIT,
	@bcp47LanguageTagCode NVARCHAR(5),
	@countryId UNIQUEIDENTIFIER,
	@localisedCountryName NVARCHAR(100)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CountryTranslationTemp
			(
				[CountryId] UNIQUEIDENTIFIER NOT NULL,
				[BCP47LanguageTagCode] NCHAR(5) NOT NULL,
				[LocalisedCountryName] NVARCHAR(100) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CountryTranslationTemp
			(
				[CountryId],
				[BCP47LanguageTagCode],
				[LocalisedCountryName],
				[ActiveStatus]
			)
			VALUES
			(
				@countryId,
				@bcp47LanguageTagCode,
				@localisedCountryName,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[CountryTranslation] CT
			INNER JOIN #CountryTranslationTemp CTT ON CT.[CountryId] = CTT.[CountryId]
			AND CT.[BCP47LanguageTagCode] = CTT.[BCP47LanguageTagCode]
			AND CT.[LocalisedCountryName] = CTT.[LocalisedCountryName]
			WHERE CT.[CountryId] = CTT.[CountryId]
			AND CT.[BCP47LanguageTagCode] = CTT.[BCP47LanguageTagCode]
			AND CT.[LocalisedCountryName] = CTT.[LocalisedCountryName]
			)
			THROW 50000, 'Country Translation already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[CountryTranslation] AS target
			USING #CountryTranslationTemp AS source
			ON target.[CountryId] = source.[CountryId]
			AND target.[BCP47LanguageTagCode] = source.[BCP47LanguageTagCode]
			AND target.[LocalisedCountryName] = source.[LocalisedCountryName]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[CountryId],
				[BCP47LanguageTagCode],
				[LocalisedCountryName],
				[ActiveStatus]
			)
			VALUES
			(
				source.[CountryId],
				source.[BCP47LanguageTagCode],
				source.[LocalisedCountryName],
				source.[ActiveStatus]
			);

			DROP TABLE #CountryTranslationTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END