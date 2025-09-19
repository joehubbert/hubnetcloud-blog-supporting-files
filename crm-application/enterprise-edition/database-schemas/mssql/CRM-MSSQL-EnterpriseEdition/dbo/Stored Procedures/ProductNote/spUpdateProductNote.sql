CREATE PROCEDURE [dbo].[spUpdateProductNote]
	@productNote NVARCHAR(4000),
	@productNoteId UNIQUEIDENTIFIER,
	@productNoteTitle NVARCHAR(50),
	@productNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[ProductNote]
			SET 
				[ProductNote] = @productNote,
				[ProductNoteTitle] = @productNoteTitle,
				[ProductNoteTypeId] = @productNoteTypeId
			WHERE [ProductNoteId] = @productNoteId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END