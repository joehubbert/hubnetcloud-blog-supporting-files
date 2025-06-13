CREATE PROCEDURE [dbo].[spGetSupplierNoteType]
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			SELECT
			[Supplier Note Type Id],
			[Supplier Note Type],
			[Active Status],
			[Created Timestamp],
			[Created By],
			[Modified Timestamp],
			[Modified By]
			FROM [dbo].[vwSupplierNoteType]
			WHERE [Supplier Note Type Id] = @supplierNoteTypeId

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END