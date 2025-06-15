CREATE PROCEDURE [dbo].[spGetSupplierNote]
	@supplierNoteId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Note Id],
			[Supplier Note Title],
			[Supplier Note Type Id],
			[Supplier Note Type],
			[Supplier Note],
			[Created Timestamp UTC],
			[Created By],
			[Modified Timestamp UTC],
			[Modified By]
			FROM [dbo].[vwSupplierNote]
			WHERE [Supplier Note Id] = @supplierNoteId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END