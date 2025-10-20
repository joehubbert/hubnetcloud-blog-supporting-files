CREATE PROCEDURE [dbo].[spCreateCurrency]
	@activeStatus BIT,
	@companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@currencyCode NCHAR(3),
	@currencyName NVARCHAR(50),
	@masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CurrencyTemp
			(
				[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[CurrencyCode] NCHAR(3) NOT NULL,
				[CurrencyName] NVARCHAR(50) NOT NULL,
				[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CurrencyTemp
			(
				[MasterDataTypeId],
				[CurrencyCode],
				[CurrencyName],
				[CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
				@masterDataTypeId,
				@currencyCode,
				@currencyName,
				@companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[Currency] C
				LEFT JOIN #CurrencyTemp CT ON C.[CurrencyCode] = CT.[CurrencyCode]
				AND C.[CurrencyName] = CT.[CurrencyName]
				AND (C.[CompanyConfigurationId] = CT.[CompanyConfigurationId] OR (C.[CompanyConfigurationId] IS NULL AND CT.[CompanyConfigurationId] IS NULL))
				WHERE C.[CurrencyCode] = CT.[CurrencyCode]
				AND C.[CurrencyName] = CT.[CurrencyName]
				AND (C.[CompanyConfigurationId] = CT.[CompanyConfigurationId] OR (C.[CompanyConfigurationId] IS NULL AND CT.[CompanyConfigurationId] IS NULL))
			)
			THROW 50000, 'Currency already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[Currency] AS target
			USING #CurrencyTemp AS source
			ON target.[CurrencyCode] = source.[CurrencyCode]
			AND target.[CurrencyName] = source.[CurrencyName]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[MasterDataTypeId],
				[CurrencyCode],
				[CurrencyName],
				[ActiveStatus]
			)
			VALUES
			(
				source.[MasterDataTypeId],
				source.[CurrencyCode],
				source.[CurrencyName],
				source.[ActiveStatus]
			);

			DROP TABLE #CurrencyTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END