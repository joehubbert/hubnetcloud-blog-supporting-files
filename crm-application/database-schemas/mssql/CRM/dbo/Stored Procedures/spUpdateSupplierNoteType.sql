CREATE PROCEDURE [dbo].[spUpdateSupplierNoteType]
	@activeStatus BIT,
	@supplierNoteType NVARCHAR(50),
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[SupplierNoteType]
SET
	[ActiveStatus] = @activeStatus,
	[SupplierNoteType] = @supplierNoteType
WHERE [SupplierNoteTypeId] = @supplierNoteTypeId