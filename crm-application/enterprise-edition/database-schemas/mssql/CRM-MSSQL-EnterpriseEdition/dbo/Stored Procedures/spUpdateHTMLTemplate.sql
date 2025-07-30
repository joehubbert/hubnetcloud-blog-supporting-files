CREATE PROCEDURE [dbo].[spUpdateHTMLTemplate]
	@htmlTemplate NVARCHAR(4000),
	@htmlTemplateId UNIQUEIDENTIFIER,
	@htmlTemplateTitle NVARCHAR(50),
	@htmlTemplateTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[HTMLTemplate]
			SET 
				[HTMLTemplate] = @htmlTemplate,
				[HTMLTemplateTitle] = @htmlTemplateTitle,
				[HTMLTemplateTypeId] = @htmlTemplateTypeId
			WHERE [HTMLTemplateId] = @htmlTemplateId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END