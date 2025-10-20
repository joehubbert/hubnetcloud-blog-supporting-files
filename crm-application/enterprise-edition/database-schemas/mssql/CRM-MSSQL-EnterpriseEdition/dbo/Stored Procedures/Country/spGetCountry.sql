CREATE PROCEDURE [dbo].[spGetCountry]
	@countryId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Country Id],
			[Master Data Type Id],
			[Master Data Type],
			[System Defined],
			[User Defined],
			[ISO 3166-1 Alpha 2 Country Code],
			[Country English Name],
			[Company Configuration Id],
			[Company Name],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By],
			[Row Version]
			FROM [dbo].[vwCountry]
			WHERE [Country Id] = @countryId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END