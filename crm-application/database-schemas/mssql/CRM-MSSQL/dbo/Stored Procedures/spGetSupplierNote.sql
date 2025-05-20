CREATE PROCEDURE [dbo].[spGetSupplierNote]
	@supplierNoteId UNIQUEIDENTIFIER
AS

SELECT
[Supplier Note Id],
[Supplier Note Title],
[Supplier Note Type],
[Supplier Note],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwSupplierNote]
WHERE [Supplier Note Id] = @supplierNoteId