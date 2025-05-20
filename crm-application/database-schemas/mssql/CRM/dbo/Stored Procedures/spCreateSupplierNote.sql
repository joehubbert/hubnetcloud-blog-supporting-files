CREATE PROCEDURE [dbo].[spCreateSupplierNote]
	@supplierId UNIQUEIDENTIFIER,
	@supplierNote NVARCHAR(4000),
	@supplierNoteTitle NVARCHAR(50),
	@supplierNoteTypeId UNIQUEIDENTIFIER
AS
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