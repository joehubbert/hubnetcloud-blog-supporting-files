CREATE PROCEDURE [dbo].[spCreateCountry]
    @activeStatus BIT,
	@countryEnglishName NVARCHAR(100),
	@iso31661A2CountryCode NCHAR(2)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CountryTemp
			(
				[ISO31661A2CountryCode] NCHAR(2) NOT NULL,
				[CountryEnglishName] NVARCHAR(100) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CountryTemp
			(
				[ISO31661A2CountryCode],
				[CountryEnglishName],
				[ActiveStatus]
			)
			VALUES
			(
				@iso31661A2CountryCode,
				@countryEnglishName,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[Country] C
				INNER JOIN #CountryTemp CT ON C.[ISO31661A2CountryCode] = CT.[ISO31661A2CountryCode]
				AND C.[CountryEnglishName] = CT.[CountryEnglishName]
				WHERE C.[ISO31661A2CountryCode] = CT.[ISO31661A2CountryCode]
				AND C.[CountryEnglishName] = CT.[CountryEnglishName]
			)
			THROW 50000, 'Country already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[Country] AS target
			USING #CountryTemp AS source
			ON target.[ISO31661A2CountryCode] = source.[ISO31661A2CountryCode]
			AND target.[CountryEnglishName] = source.[CountryEnglishName]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ISO31661A2CountryCode],
				[CountryEnglishName],
				[ActiveStatus]
			)
			VALUES
			(
				source.[ISO31661A2CountryCode],
				source.[CountryEnglishName],
				source.[ActiveStatus]
			);

			DROP TABLE #CountryTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END