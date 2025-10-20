CREATE TABLE [dbo].[CustomerNoteType]
(
	[CustomerNoteTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [UC_CustomerNoteType_CustomerNoteType] UNIQUE ([CustomerNoteType])
)
GO

CREATE TRIGGER [TRG_UpdateCustomerNoteType]
ON [dbo].[CustomerNoteType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[CustomerNoteType]
	SET 
		[ModifiedTimestampUTC] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[CustomerNoteType] cnt
	INNER JOIN 
		inserted i ON cnt.[CustomerNoteTypeId] = i.[CustomerNoteTypeId];
END
GO