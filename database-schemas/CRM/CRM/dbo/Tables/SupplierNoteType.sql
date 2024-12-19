CREATE TABLE [dbo].[SupplierNoteType]
(
	[SupplierNoteTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierNoteType] NVARCHAR(50) NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [UC_SupplierNoteType] UNIQUE ([SupplierNoteType])
)
GO

CREATE TRIGGER [TRG_UpdateSupplierNoteType]
ON [dbo].[SupplierNoteType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[SupplierNoteType]
	SET 
		[ModifiedTimestamp] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[SupplierNoteType] cnt
	INNER JOIN 
		inserted i ON cnt.[SupplierNoteTypeId] = i.[SupplierNoteTypeId];
END
GO