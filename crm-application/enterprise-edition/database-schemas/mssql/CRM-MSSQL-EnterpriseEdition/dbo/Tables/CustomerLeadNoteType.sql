CREATE TABLE [dbo].[CustomerLeadNoteType]
(
	[CustomerLeadNoteTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CustomerLeadNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [UC_CustomerLeadNoteType_CustomerLeadNoteType] UNIQUE ([CustomerLeadNoteType])
)
GO

CREATE TRIGGER [TRG_UpdateCustomerLeadNoteType]
ON [dbo].[CustomerLeadNoteType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[CustomerLeadNoteType]
	SET 
		[ModifiedTimestampUTC] = SYSUTCDATETIME(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[CustomerLeadNoteType] clnt
	INNER JOIN 
		inserted i ON clnt.[CustomerLeadNoteTypeId] = i.[CustomerLeadNoteTypeId];
END
GO