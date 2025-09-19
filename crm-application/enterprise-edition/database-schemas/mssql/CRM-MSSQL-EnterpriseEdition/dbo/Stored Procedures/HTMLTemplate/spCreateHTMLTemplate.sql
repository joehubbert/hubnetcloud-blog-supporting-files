CREATE PROCEDURE [dbo].[spCreateHTMLTemplate]
	@companyConfigurationId UNIQUEIDENTIFIER,
	@htmlTemplate NVARCHAR(MAX),
	@htmlTemplateTitle NVARCHAR(50),
	@htmlTemplateTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[HTMLTemplate]
			(
				[CompanyConfigurationId],
				[HTMLTemplate],
				[HTMLTemplateTitle],
				[HTMLTemplateTypeId]
			)
			VALUES
			(
				@companyConfigurationId,
				@htmlTemplate,
				@htmlTemplateTitle,
				@htmlTemplateTypeId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END