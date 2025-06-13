CREATE PROCEDURE [dbo].[spUpdateSupplierNote]
	@supplierNote NVARCHAR(4000),
	@supplierNoteId UNIQUEIDENTIFIER,
	@supplierNoteTitle NVARCHAR(50),
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierNote]
			SET 
				[SupplierNote] = @supplierNote,
				[SupplierNoteTitle] = @supplierNoteTitle,
				[SupplierNoteTypeId] = @supplierNoteTypeId
			WHERE [SupplierNoteId] = @supplierNoteId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END