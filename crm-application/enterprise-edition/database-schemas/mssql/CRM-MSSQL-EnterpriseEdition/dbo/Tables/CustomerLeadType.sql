CREATE TABLE [dbo].[CustomerLeadType]
(
	[CustomerLeadTypeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerLeadType] NVARCHAR(50) NOT NULL,
	[CustomerLeadTypeCode] NVARCHAR(20) NOT NULL,
	[CustomerLeadTypeDescription] NVARCHAR(255) NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_CustomerLeadType_MasterDataType] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
	CONSTRAINT [FK_CustomerLeadType_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [UC_CustomerLeadType_CustomerLeadType_CompanyConfigurationId] UNIQUE ([CustomerLeadType], [CompanyConfigurationId])
)
GO

CREATE TRIGGER [TRG_UpdateCustomerLeadType]
ON [dbo].[CustomerLeadType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE [dbo].[CustomerLeadType]
	SET 
		[ModifiedTimestampUTC] = SYSUTCDATETIME(),
		[ModifiedBy] = SUSER_SNAME()
	FROM 
		[dbo].[CustomerLeadType] clt
	INNER JOIN 
		inserted i ON clt.[CustomerLeadTypeId] = i.[CustomerLeadTypeId];
END
GO