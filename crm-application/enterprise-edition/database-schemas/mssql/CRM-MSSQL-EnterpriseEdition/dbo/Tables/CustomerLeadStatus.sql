CREATE TABLE [dbo].[CustomerLeadStatus]
(
	[CustomerLeadStatusId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerLeadStatus] NVARCHAR(50) NOT NULL,
    [CustomerLeadStatusCode] NVARCHAR(20) NOT NULL,
    [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_CustomerLeadStatus_MasterDataType] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
    CONSTRAINT [FK_CustomerLeadStatus_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
    CONSTRAINT [UC_CustomerLeadStatus_CustomerLeadStatus] UNIQUE ([CustomerLeadStatus]),
    CONSTRAINT [UC_CustomerLeadStatus_CustomerLeadStatusCode] UNIQUE ([CustomerLeadStatusCode])
)
GO

CREATE TRIGGER [TRG_UpdateCustomerLeadStatus]
ON [dbo].[CustomerLeadStatus]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CustomerLeadStatus]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CustomerLeadStatus] cls
    INNER JOIN 
        inserted i ON cls.[CustomerLeadStatusId] = i.[CustomerLeadStatusId];
END
GO