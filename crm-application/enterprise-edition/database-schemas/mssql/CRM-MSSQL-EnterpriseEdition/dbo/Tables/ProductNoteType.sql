CREATE TABLE [dbo].[ProductNoteType]
(
	[ProductNoteTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[ProductNoteType] NVARCHAR(50) NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_ProductNoteType_MasterDataType] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
	CONSTRAINT [FK_ProductNoteType_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [UC_ProductNoteType_ProductNoteType_CompanyConfigurationId] UNIQUE ([ProductNoteType], [CompanyConfigurationId])
)
GO

CREATE TRIGGER [TRG_UpdateProductNoteType]
ON [dbo].[ProductNoteType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[ProductNoteType]
	SET 
		[ModifiedTimestampUTC] = SYSUTCDATETIME(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[ProductNoteType] pnt
	INNER JOIN 
		inserted i ON pnt.[ProductNoteTypeId] = i.[ProductNoteTypeId];
END
GO