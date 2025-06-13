CREATE PROCEDURE [dbo].[spCreateProductNote]
	@productId UNIQUEIDENTIFIER,
	@productNote NVARCHAR(4000),
	@productNoteTitle NVARCHAR(50),
	@productNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[ProductNote]
			(
				[ProductId],
				[ProductNote],
				[ProductNoteTitle],
				[ProductNoteTypeId]
			)
			VALUES
			(
				@productId,
				@productNote,
				@productNoteTitle,
				@productNoteTypeId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END