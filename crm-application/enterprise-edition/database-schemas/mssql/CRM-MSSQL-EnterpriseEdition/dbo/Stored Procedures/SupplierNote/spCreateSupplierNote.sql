CREATE PROCEDURE [dbo].[spCreateSupplierNote]
	@supplierId UNIQUEIDENTIFIER,
	@supplierNote NVARCHAR(4000),
	@supplierNoteTitle NVARCHAR(50),
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			INSERT INTO [dbo].[SupplierNote]
			(
				[SupplierId],
				[SupplierNote],
				[SupplierNoteTitle],
				[SupplierNoteTypeId]
			)
			VALUES
			(
				@supplierId,
				@supplierNote,
				@supplierNoteTitle,
				@supplierNoteTypeId
			)

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END