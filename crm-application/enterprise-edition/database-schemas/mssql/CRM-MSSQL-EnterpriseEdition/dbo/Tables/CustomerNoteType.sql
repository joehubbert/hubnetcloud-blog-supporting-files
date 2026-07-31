CREATE TABLE [dbo].[CustomerNoteType]
(
	[CustomerNoteTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerNoteType] NVARCHAR(50) NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_CustomerNoteType_MasterDataType] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
	CONSTRAINT [FK_CustomerNoteType_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [UC_CustomerNoteType_CustomerNoteType_CompanyConfigurationId] UNIQUE ([CustomerNoteType], [CompanyConfigurationId])
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
		[ModifiedTimestampUTC] = SYSUTCDATETIME(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[CustomerNoteType] cnt
	INNER JOIN 
		inserted i ON cnt.[CustomerNoteTypeId] = i.[CustomerNoteTypeId];
END
GO