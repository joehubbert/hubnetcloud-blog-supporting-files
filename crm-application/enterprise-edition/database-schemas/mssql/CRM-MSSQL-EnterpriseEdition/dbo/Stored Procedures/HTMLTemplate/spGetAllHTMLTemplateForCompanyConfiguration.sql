CREATE PROCEDURE [dbo].[spGetAllHTMLTemplateForCompanyConfiguration]
	@companyConfigurationId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Company Configuration Id],
			[HTML Template Id],
			[HTML Template Title],
			[HTML Template Type Id],
			[HTML Template Type],
			[HTML Template]
			FROM [dbo].[vwHTMLTemplate]
			WHERE [Company Configuration Id] = @companyConfigurationId;

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END