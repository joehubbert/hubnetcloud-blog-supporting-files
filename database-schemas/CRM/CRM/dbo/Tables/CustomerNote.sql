CREATE TABLE [dbo].[CustomerNote]
(
	[CustomerNoteId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerId] UNIQUEIDENTIFIER NOT NULL,
	[Note] NVARCHAR(MAX) NOT NULL,
	[CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL
	CONSTRAINT [FK_CustomerNote_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer]([CustomerId])
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
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CustomerNote] cn
    INNER JOIN 
        inserted i ON cn.[CustomerNoteId] = i.[CustomerNoteId];
END
GO