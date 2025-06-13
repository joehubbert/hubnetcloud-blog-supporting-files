CREATE PROCEDURE [dbo].[spUpdateSupplierNoteType]
	@activeStatus BIT,
	@supplierNoteType NVARCHAR(50),
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			UPDATE [dbo].[SupplierNoteType]
			SET
				[ActiveStatus] = @activeStatus,
				[SupplierNoteType] = @supplierNoteType
			WHERE [SupplierNoteTypeId] = @supplierNoteTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END