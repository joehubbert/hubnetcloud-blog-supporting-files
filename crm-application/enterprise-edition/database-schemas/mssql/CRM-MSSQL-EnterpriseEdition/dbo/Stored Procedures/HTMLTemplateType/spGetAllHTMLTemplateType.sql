CREATE PROCEDURE [dbo].[spGetAllHTMLTemplateType]
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[HTML Template Type Id],
			[Master Data Type Id],
			[Master Data Type],
			[Master Data Type Code],
			[Is Custom],
			[HTML Template Type],
			[Company Configuration Id],
			[Company Name],
			[Active Status]
			FROM [dbo].[vwHTMLTemplateType]

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END