CREATE PROCEDURE [dbo].[spUpdateProductNoteType]
	@activeStatus BIT,
	@productNoteType NVARCHAR(50),
	@productNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[ProductNoteType]
			SET
				[ActiveStatus] = @activeStatus,
				[ProductNoteType] = @productNoteType
			WHERE [ProductNoteTypeId] = @productNoteTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END