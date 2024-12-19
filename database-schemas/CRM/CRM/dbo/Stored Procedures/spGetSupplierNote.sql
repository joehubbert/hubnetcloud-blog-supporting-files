CREATE PROCEDURE [dbo].[spGetSupplierNote]
	@supplierNoteId UNIQUEIDENTIFIER
AS

SELECT
[Supplier Note Id],
[Supplier Note Title],
[Supplier Note Type],
[Supplier Note]
FROM [dbo].[vwSupplierNote]
WHERE [Supplier Note Id] = @supplierNoteId