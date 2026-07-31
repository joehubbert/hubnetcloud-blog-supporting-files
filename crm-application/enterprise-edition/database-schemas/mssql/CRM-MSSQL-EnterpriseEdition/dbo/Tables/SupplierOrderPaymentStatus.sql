CREATE TABLE [dbo].[SupplierOrderPaymentStatus]
(
	[SupplierOrderPaymentStatusId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
	[SupplierOrderPaymentStatus] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_SupplierOrderPaymentStatus_MasterDataTypeId] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
	CONSTRAINT [FK_SupplierOrderPaymentStatus_CompanyConfigurationId] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [UC_SupplierOrderPaymentStatus_SupplierOrderPaymentStatus_CompanyConfigurationId] UNIQUE ([SupplierOrderPaymentStatus], [CompanyConfigurationId])
)
GO

CREATE TRIGGER [TRG_UpdateSupplierOrderPaymentStatus]
ON [dbo].[SupplierOrderPaymentStatus]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrderPaymentStatus]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrderPaymentStatus] sops
    INNER JOIN 
        inserted i ON sops.[SupplierOrderPaymentStatusId] = i.[SupplierOrderPaymentStatusId];
END
GO