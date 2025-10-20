CREATE TABLE [dbo].[CustomerLeadNote]
(
	[CustomerLeadNoteId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerLeadId] UNIQUEIDENTIFIER NOT NULL,
    [CustomerLeadNoteTitle] NVARCHAR(50) NOT NULL,
    [CustomerLeadNoteTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerLeadNote] NVARCHAR(4000) NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_CustomerLeadNote_CustomerLeadId] FOREIGN KEY ([CustomerLeadId]) REFERENCES [dbo].[CustomerLead]([CustomerLeadId]),
    CONSTRAINT [FK_CustomerLeadNote_CustomerLeadNoteTypeId] FOREIGN KEY ([CustomerLeadNoteTypeId]) REFERENCES [dbo].[CustomerLeadNoteType]([CustomerLeadNoteTypeId])
)
GO

CREATE TRIGGER [TRG_UpdateCustomerLeadNote]
ON [dbo].[CustomerLeadNote]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CustomerLeadNote]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CustomerLeadNote] cln
    INNER JOIN 
        inserted i ON cln.[CustomerLeadNoteId] = i.[CustomerLeadNoteId];
END
GO