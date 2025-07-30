CREATE TABLE [dbo].[HTMLTemplateType]
(
	[HTMLTemplateTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[HTMLTemplateType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	CONSTRAINT [UC_HTMLTemplateType_HTMLTemplateType] UNIQUE ([HTMLTemplateType])
)
GO

CREATE TRIGGER [TRG_UpdateHTMLTemplateType]
ON [dbo].[HTMLTemplateType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[HTMLTemplateType]
	SET 
		[ModifiedTimestampUTC] = GETUTCDATE(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[HTMLTemplateType] htmltt
	INNER JOIN 
		inserted i ON htmltt.[HTMLTemplateTypeId] = i.[HTMLTemplateTypeId];
END
GO