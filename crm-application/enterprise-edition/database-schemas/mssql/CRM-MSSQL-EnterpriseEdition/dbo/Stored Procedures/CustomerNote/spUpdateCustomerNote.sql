CREATE PROCEDURE [dbo].[spUpdateCustomerNote]
	@customerNote NVARCHAR(4000),
	@customerNoteId UNIQUEIDENTIFIER,
	@customerNoteTitle NVARCHAR(50),
	@customerNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[CustomerNote]
			SET 
				[CustomerNote] = @customerNote,
				[CustomerNoteTitle] = @customerNoteTitle,
				[CustomerNoteTypeId] = @customerNoteTypeId
			WHERE [CustomerNoteId] = @customerNoteId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END