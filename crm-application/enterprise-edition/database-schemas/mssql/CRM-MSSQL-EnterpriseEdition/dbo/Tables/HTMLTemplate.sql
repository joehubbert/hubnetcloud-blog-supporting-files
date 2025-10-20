CREATE TABLE [dbo].[HTMLTemplate]
(
	[HTMLTemplateId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
    [HTMLTemplateTypeId] UNIQUEIDENTIFIER NOT NULL,
    [HTMLTemplateTitle] NVARCHAR(50) NOT NULL,
	[HTMLTemplate] NVARCHAR(MAX) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_HTMLTemplate_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration] ([CompanyConfigurationId]),
    CONSTRAINT [FK_HTMLTemplate_HTMLTemplateType] FOREIGN KEY ([HTMLTemplateTypeId]) REFERENCES [dbo].[HTMLTemplateType] ([HTMLTemplateTypeId])
)
GO

CREATE TRIGGER [TRG_UpdateHTMLTemplate]
ON [dbo].[HTMLTemplate]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[HTMLTemplate]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[HTMLTemplate] htmlt
    INNER JOIN 
        inserted i ON htmlt.[HTMLTemplateId] = i.[HTMLTemplateId];
END
GO