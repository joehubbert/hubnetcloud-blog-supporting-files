CREATE PROCEDURE [dbo].[spGetSupplierNoteType]
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS

SELECT
[SupplierNoteTypeId] AS [Supplier Note Type Id],
[SupplierNoteType] AS [Supplier Note Type]
FROM [dbo].[SupplierNoteType]
WHERE [SupplierNoteTypeId] = @supplierNoteTypeId