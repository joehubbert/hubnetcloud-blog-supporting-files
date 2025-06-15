CREATE PROCEDURE [dbo].[spCreateCountry]
    @activeStatus BIT,
	@countryName NVARCHAR(100),
	@isoCountryCode NCHAR(2)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CountryTemp
			(
				[ISOCountryCode] NCHAR(2) NOT NULL,
				[CountryName] NVARCHAR(100) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CountryTemp
			(
				[ISOCountryCode],
				[CountryName],
				[ActiveStatus]
			)
			VALUES
			(
				@isoCountryCode,
				@countryName,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[Country] C
			INNER JOIN #CountryTemp CT ON C.[ISOCountryCode] = CT.[ISOCountryCode]
			AND C.[CountryName] = CT.[CountryName]
			WHERE C.[ISOCountryCode] = CT.[ISOCountryCode]
			AND C.[CountryName] = CT.[CountryName]
			)
			THROW 50000, 'Country already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[Country] AS target
			USING #CountryTemp AS source
			ON target.[ISOCountryCode] = source.[ISOCountryCode]
			AND target.[CountryName] = source.[CountryName]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[ISOCountryCode],
				[CountryName],
				[ActiveStatus]
			)
			VALUES
			(
				source.[ISOCountryCode],
				source.[CountryName],
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