CREATE TABLE [dbo].[CompanyConfiguration]
(
	[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CompanyName] NVARCHAR(50) NOT NULL,
    [CompanyLogo] VARBINARY(MAX) NULL,
    [AddressLine1] NVARCHAR(50) NOT NULL,
    [AddressLine2] NVARCHAR(50) NULL,
    [AddressLine3] NVARCHAR(50) NOT NULL,
    [AddressLine4] NVARCHAR(50) NOT NULL,
    [AddressLine5] NVARCHAR(50) NOT NULL,
    [TelephoneNumber] NVARCHAR(13) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [EmailTopLevelDomain] NVARCHAR(50) NOT NULL,
    [VATNumber] NVARCHAR(50) NULL,
    [WebsiteURL] NVARCHAR(50) NULL,
    [BankAccountBalance] MONEY NOT NULL,
    [BankAccountCurrencyId] UNIQUEIDENTIFIER NOT NULL,
    [BankAccountNumber] NVARCHAR(50) NOT NULL,
    [BankAccountName] NVARCHAR(50) NOT NULL,
    [BankSortCode] NVARCHAR(8) NULL,
    [BankIBAN] NVARCHAR(50) NULL,
    [BankSWIFT] NVARCHAR(50) NULL,
    [BankAddressLine1] NVARCHAR(50) NOT NULL,
    [BankAddressLine2] NVARCHAR(50) NULL,
    [BankAddressLine3] NVARCHAR(50) NOT NULL,
    [BankAddressLine4] NVARCHAR(50) NOT NULL,
    [BankAddressLine5] NVARCHAR(50) NOT NULL,
    [CreatedTimestamp] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestamp] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_CompanyConfiguration_BankAccountCurrencyId] FOREIGN KEY ([BankAccountCurrencyId]) REFERENCES [dbo].[Currency]([CurrencyId]),
    CONSTRAINT [CC_CompanyConfiguration_BankSortCode_UK] CHECK (
        ([BankAddressLine5] = 'United Kingdom' AND [BankSortCode] IS NOT NULL AND LTRIM(RTRIM([BankSortCode])) <> '')
        OR
        ([BankAddressLine5] <> 'United Kingdom' AND ([BankSortCode] IS NULL OR LTRIM(RTRIM([BankSortCode])) = ''))
    ),
    CONSTRAINT [UC_CompanyConfiguration_CompanyName] UNIQUE ([CompanyName])
)
GO

CREATE TRIGGER [TRG_UpdateCompanyConfiguration]
ON [dbo].[CompanyConfiguration]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [dbo].[CompanyConfiguration]
    SET 
        [ModifiedTimestamp] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CompanyConfiguration] c
    INNER JOIN 
        inserted i ON c.[CompanyConfigurationId] = i.[CompanyConfigurationId];
END
GO