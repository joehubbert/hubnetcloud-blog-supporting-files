CREATE PROCEDURE [dbo].[spGetAllCurrencyConversion]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Currency Conversion Id],
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
			[Active Status]
			FROM [dbo].[vwCurrencyConversion]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END