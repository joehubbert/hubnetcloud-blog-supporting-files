CREATE TABLE [dbo].[CustomerLeadNoteType]
(
	[CustomerLeadNoteTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerLeadNoteType] NVARCHAR(50) NOT NULL,
	[CustomerLeadNoteTypeCode] NVARCHAR(20) NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,	
	CONSTRAINT [FK_CustomerLeadNoteType_MasterDataType] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
	CONSTRAINT [FK_CustomerLeadNoteType_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
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