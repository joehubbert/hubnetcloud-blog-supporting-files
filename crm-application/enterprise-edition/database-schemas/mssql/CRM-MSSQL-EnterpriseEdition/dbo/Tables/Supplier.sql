CREATE TABLE [dbo].[Supplier]
(
	[SupplierId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierName] NVARCHAR(50) NOT NULL,
    [AddressLine1] NVARCHAR(50) NOT NULL,
    [AddressLine2] NVARCHAR(50) NULL,
    [AddressLine3] NVARCHAR(50) NOT NULL,
    [AddressLine4] NVARCHAR(50) NOT NULL,
    [AddressLine5] UNIQUEIDENTIFIER NOT NULL,
    [TelephoneNumber] NVARCHAR(50) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [PaymentDays] TINYINT NOT NULL,
    [PaymentCurrencyId] UNIQUEIDENTIFIER NOT NULL,
    [VATRegistered] BIT NOT NULL,
    [VATNumber] NVARCHAR(50) NULL,
    [ActiveStatus] BIT NOT NULL,
    [CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_Supplier_AddressLine5] FOREIGN KEY ([AddressLine5]) REFERENCES [dbo].[Country]([CountryId]),
    CONSTRAINT [FK_Supplier_CompanyConfiguration] FOREIGN KEY ([CompanyConfigurationId]) REFERENCES [dbo].[CompanyConfiguration]([CompanyConfigurationId]),
    CONSTRAINT [FK_Supplier_Currency] FOREIGN KEY ([PaymentCurrencyId]) REFERENCES [dbo].[Currency]([CurrencyId])
)
GO

CREATE TRIGGER [TRG_UpdateSupplier]
ON [dbo].[Supplier]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[Supplier]
    SET 
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[Supplier] s
    INNER JOIN 
        inserted i ON s.[SupplierId] = i.[SupplierId];
END
GO