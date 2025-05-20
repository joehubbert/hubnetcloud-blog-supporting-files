CREATE PROCEDURE [dbo].[spUpdateSupplierNote]
	@supplierNote NVARCHAR(4000),
	@supplierNoteId UNIQUEIDENTIFIER,
	@supplierNoteTitle NVARCHAR(50),
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[SupplierNote]
SET 
	[SupplierNote] = @supplierNote,
	[SupplierNoteTitle] = @supplierNoteTitle,
	[SupplierNoteTypeId] = @supplierNoteTypeId
WHERE [SupplierNoteId] = @supplierNoteId