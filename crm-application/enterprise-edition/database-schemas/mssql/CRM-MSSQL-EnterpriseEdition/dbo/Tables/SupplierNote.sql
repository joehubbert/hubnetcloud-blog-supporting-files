CREATE TABLE [dbo].[SupplierNote]
(
	[SupplierNoteId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[SupplierId] UNIQUEIDENTIFIER NOT NULL,
    [SupplierNoteTitle] NVARCHAR(50) NOT NULL,
    [SupplierNoteTypeId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierNote] NVARCHAR(4000) NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL
	CONSTRAINT [FK_SupplierNote_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier]([SupplierId]),
    CONSTRAINT [FK_SupplierNote_SupplierNoteTypeId] FOREIGN KEY ([SupplierNoteTypeId]) REFERENCES [dbo].[SupplierNoteType]([SupplierNoteTypeId])
)
GO

CREATE TRIGGER [TRG_UpdateSupplierNote]
ON [dbo].[SupplierNote]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierNote]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierNote] sn
    INNER JOIN 
        inserted i ON sn.[SupplierNoteId] = i.[SupplierNoteId];
END
GO