CREATE PROCEDURE [dbo].[spCreateCountry]
    @activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@countryEnglishName NVARCHAR(100),
	@iso31661A2CountryCode NCHAR(2),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CountryTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[ISO31661A2CountryCode] NCHAR(2) NOT NULL,
				[CountryEnglishName] NVARCHAR(100) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CountryTemp
			(
				[MasterDataTypeId],
				[ISO31661A2CountryCode],
				[CountryEnglishName],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@iso31661A2CountryCode,
				@countryEnglishName,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[Country] C
				LEFT JOIN #CountryTemp CT ON C.[ISO31661A2CountryCode] = CT.[ISO31661A2CountryCode]
				AND C.[CountryEnglishName] = CT.[CountryEnglishName]
				AND (C.[CompanyConfigurationId] = CT.[CompanyConfigurationId] OR (C.[CompanyConfigurationId] IS NULL AND CT.[CompanyConfigurationId] IS NULL))
				WHERE C.[ISO31661A2CountryCode] = CT.[ISO31661A2CountryCode]
				AND C.[CountryEnglishName] = CT.[CountryEnglishName]
				AND (C.[CompanyConfigurationId] = CT.[CompanyConfigurationId] OR (C.[CompanyConfigurationId] IS NULL AND CT.[CompanyConfigurationId] IS NULL))
			)
			THROW 50000, 'Country already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[Country] AS target
			USING #CountryTemp AS source
			ON target.[ISO31661A2CountryCode] = source.[ISO31661A2CountryCode]
			AND target.[CountryEnglishName] = source.[CountryEnglishName]
			AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[ISO31661A2CountryCode],
				[CountryEnglishName],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[ISO31661A2CountryCode],
				source.[CountryEnglishName],
				source.[CompanyConfigurationId],
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