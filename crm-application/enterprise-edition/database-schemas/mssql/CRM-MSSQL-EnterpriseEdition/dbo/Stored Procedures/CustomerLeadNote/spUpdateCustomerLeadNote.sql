CREATE PROCEDURE [dbo].[spUpdateCustomerLeadNote]
	@customerLeadNote NVARCHAR(4000),
	@customerLeadNoteId UNIQUEIDENTIFIER,
	@customerLeadNoteTitle NVARCHAR(50),
	@customerLeadNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerLeadNote]
			SET 
				[CustomerLeadNote] = @customerLeadNote,
				[CustomerLeadNoteTitle] = @customerLeadNoteTitle,
				[CustomerLeadNoteTypeId] = @customerLeadNoteTypeId
			WHERE [CustomerLeadNoteId] = @customerLeadNoteId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END