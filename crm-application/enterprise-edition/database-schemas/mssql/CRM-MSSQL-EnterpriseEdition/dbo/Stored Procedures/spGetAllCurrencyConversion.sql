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
			[Currency A Id],
			[Currency A Code],
			[Currency A Name],
			[Currency B Id],
			[Currency B Code],
			[Currency B Name],
			[Conversion Rate],
			[Effective Date],
			[Expiry Date],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwCurrencyConversion]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END