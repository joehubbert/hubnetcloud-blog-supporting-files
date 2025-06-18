CREATE PROCEDURE [dbo].[spGetCountryTranslation]
	@countryTranslationId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Country Translation Id],
			[BCP 47 Language Tag Code],
			[Localised Country Name],
			[Country Id],
			[Country English Name],
			[Active Status],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwCountryTranslation]
			WHERE [Country Translation Id] = @countryTranslationId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END