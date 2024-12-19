CREATE PROCEDURE [dbo].[spGetSupplierNoteType]
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS

SELECT
[Supplier Note Type Id],
[Supplier Note Type]
FROM [dbo].[vwSupplierNoteType]
WHERE [Supplier Note Type Id] = @supplierNoteTypeId