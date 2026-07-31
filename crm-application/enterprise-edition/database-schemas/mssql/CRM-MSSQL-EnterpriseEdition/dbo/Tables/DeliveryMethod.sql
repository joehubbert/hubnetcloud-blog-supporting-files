CREATE TABLE [dbo].[DeliveryMethod]
(
	[DeliveryMethodId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
	[TaxProfileId] UNIQUEIDENTIFIER NOT NULL,
	[DeliveryMethod] NVARCHAR(50) NOT NULL,
	[DeliveryCost] MONEY NOT NULL,
	[DeliveryTimeDays] INT NOT NULL,
	[ActiveStatus] BIT NOT NULL,
	[CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
	[RowVersion] ROWVERSION NOT NULL,
	CONSTRAINT [FK_DeliveryMethod_MasterDataTypeId] FOREIGN KEY ([MasterDataTypeId]) REFERENCES [dbo].[MasterDataType]([MasterDataTypeId]),
	CONSTRAINT [FK_DeliveryMethod_CompanyConfigurationId] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
	CONSTRAINT [FK_DeliveryMethod_TaxProfileId] FOREIGN KEY ([TaxProfileId]) REFERENCES [dbo].[TaxProfile]([TaxProfileId]),
	CONSTRAINT [UC_DeliveryMethod_DeliveryMethod_CompanyConfigurationId] UNIQUE ([DeliveryMethod], [CompanyConfigurationId])
)
GO

CREATE TRIGGER [TRG_UpdateDeliveryMethod]
ON [dbo].[DeliveryMethod]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[DeliveryMethod]
    SET 
        [ModifiedTimestampUTC] = SYSUTCDATETIME(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[DeliveryMethod] dm
    INNER JOIN 
        inserted i ON dm.[DeliveryMethodId] = i.[DeliveryMethodId];
END
GO