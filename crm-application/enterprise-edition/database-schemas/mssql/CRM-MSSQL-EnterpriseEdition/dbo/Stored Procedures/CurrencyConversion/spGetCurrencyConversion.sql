CREATE PROCEDURE [dbo].[spGetCurrencyConversion]
	@currencyConversionId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Currency Conversion Id],
			[Master Data Type Id],
			[Master Data Type],
			[Master Data Type Code],
			[Is Custom],
			[Company Configuration Id],
			[Company Name],
			[Currency Conversion Friendly Name],
			[Base Currency Id],
			[Base Currency Code],
			[Base Currency Name],
			[Target Currency Id],
			[Target Currency Code],
			[Target Currency Name],
			[Base Currency Conversion Rate],
			[Target Currency Conversion Rate],
			[Effective Date],
			[Expiry Date],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwCurrencyConversion]
			WHERE [Currency Conversion Id] = @currencyConversionId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END