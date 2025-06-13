CREATE TABLE [dbo].[ProductNote]
(
	[ProductNoteId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
    [ProductNoteTitle] NVARCHAR(50) NOT NULL,
    [ProductNoteTypeId] UNIQUEIDENTIFIER NOT NULL,
	[ProductNote] NVARCHAR(4000) NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [FK_ProductNote_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([ProductId]),
	CONSTRAINT [FK_ProductNote_ProductNoteTypeId] FOREIGN KEY ([ProductNoteTypeId]) REFERENCES [dbo].[ProductNoteType]([ProductNoteTypeId])
)
GO

CREATE TRIGGER [TRG_UpdateProductNote]
ON [dbo].[ProductNote]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[ProductNote]
	SET 
		[ModifiedTimestamp] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[ProductNote] pn
	INNER JOIN 
		inserted i ON pn.[ProductNoteId] = i.[ProductNoteId];
END
GO