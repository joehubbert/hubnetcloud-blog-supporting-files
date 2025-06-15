CREATE TABLE [dbo].[CustomerNote]
(
	[CustomerNoteId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerId] UNIQUEIDENTIFIER NOT NULL,
    [CustomerNoteTitle] NVARCHAR(50) NOT NULL,
    [CustomerNoteTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerNote] NVARCHAR(4000) NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL
	CONSTRAINT [FK_CustomerNote_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([CustomerId]),
    CONSTRAINT [FK_CustomerNote_CustomerNoteTypeId] FOREIGN KEY ([CustomerNoteTypeId]) REFERENCES [dbo].[CustomerNoteType]([CustomerNoteTypeId])
)
GO

CREATE TRIGGER [TRG_UpdateCustomerNote]
ON [dbo].[CustomerNote]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CustomerNote]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CustomerNote] cn
    INNER JOIN 
        inserted i ON cn.[CustomerNoteId] = i.[CustomerNoteId];
END
GO