CREATE PROCEDURE [dbo].[spUpdateSupplierNoteType]
	@supplierNoteType NVARCHAR(50),
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[SupplierNoteType]
SET
	[SupplierNoteType] = @supplierNoteType
WHERE [SupplierNoteTypeId] = @supplierNoteTypeId