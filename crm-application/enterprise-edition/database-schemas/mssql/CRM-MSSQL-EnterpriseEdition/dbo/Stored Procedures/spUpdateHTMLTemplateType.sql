CREATE PROCEDURE [dbo].[spUpdateHTMLTemplateType]
	@activeStatus BIT,
	@htmlTemplateType NVARCHAR(50),
	@htmlTemplateTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[HTMLTemplateType]
			SET
				[ActiveStatus] = @activeStatus,
				[HTMLTemplateType] = @htmlTemplateType
			WHERE [HTMLTemplateTypeId] = @htmlTemplateTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END