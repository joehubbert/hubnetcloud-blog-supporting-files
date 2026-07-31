CREATE TABLE [dbo].[SupplierOrderLineItemStatus]
(
	[SupplierOrderLineItemStatusId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
	[SupplierOrderLineItemStatus] NVARCHAR(50) NOT NULL,
    [ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_SupplierOrderLineItemStatus_MasterDataTypeId] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
	CONSTRAINT [FK_SupplierOrderLineItemStatus_CompanyConfigurationId] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [UC_SupplierOrderLineItemStatus_SupplierOrderLineItemStatus_CompanyConfigurationId] UNIQUE ([SupplierOrderLineItemStatus], [CompanyConfigurationId])
)
GO

CREATE TRIGGER [TRG_UpdateSupplierOrderLineItemStatus]
ON [dbo].[SupplierOrderLineItemStatus]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[SupplierOrderLineItemStatus]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[SupplierOrderLineItemStatus] solis
    INNER JOIN 
        inserted i ON solis.[SupplierOrderLineItemStatusId] = i.[SupplierOrderLineItemStatusId];
END
GO