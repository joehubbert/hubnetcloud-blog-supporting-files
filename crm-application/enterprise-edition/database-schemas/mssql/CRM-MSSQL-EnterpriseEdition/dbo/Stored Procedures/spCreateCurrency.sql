CREATE PROCEDURE [dbo].[spCreateCurrency]
	@activeStatus BIT,
	@currencyCode NCHAR(3),
	@currencyName NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #CurrencyTemp
			(
				[CurrencyCode] NCHAR(3) NOT NULL,
				[CurrencyName] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #CurrencyTemp
			(
				[CurrencyCode],
				[CurrencyName],
				[ActiveStatus]
			)
			VALUES
			(
				@currencyCode,
				@currencyName,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[Currency] C
			INNER JOIN #CurrencyTemp CT ON C.[CurrencyCode] = CT.[CurrencyCode]
			AND C.[CurrencyName] = CT.[CurrencyName]
			WHERE C.[CurrencyCode] = CT.[CurrencyCode]
			AND C.[CurrencyName] = CT.[CurrencyName]
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
				[CurrencyCode],
				[CurrencyName],
				[ActiveStatus]
			)
			VALUES
			(
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