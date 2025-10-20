CREATE TABLE [dbo].[CompanyConfiguration]
(
	[CompanyConfigurationId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[CompanyName] NVARCHAR(50) NOT NULL,
    [CompanyLogo] VARBINARY(MAX) NULL,
    [AddressLine1] NVARCHAR(50) NOT NULL,
    [AddressLine2] NVARCHAR(50) NULL,
    [AddressLine3] NVARCHAR(50) NOT NULL,
    [AddressLine4] NVARCHAR(50) NOT NULL,
    [AddressLine5] UNIQUEIDENTIFIER NOT NULL,
    [TelephoneNumber] NVARCHAR(13) NOT NULL,
    [EmailAddress] NVARCHAR(50) NOT NULL,
    [EmailTopLevelDomain] NVARCHAR(50) NOT NULL,
    [VATRegistered] BIT NOT NULL,
    [VATNumber] NVARCHAR(50) NULL,
    [WebsiteURL] NVARCHAR(50) NULL,
    [BankAccountBalance] MONEY NOT NULL,
    [BankAccountCurrencyId] UNIQUEIDENTIFIER NOT NULL,
    [BankAccountNumber] NVARCHAR(50) NOT NULL,
    [BankAccountName] NVARCHAR(50) NOT NULL,
    [BankAccountSortCode] NVARCHAR(8) NULL,
    [BankAccountIBAN] NVARCHAR(34) NULL,
    [BankAccountSWIFTCode] NVARCHAR(11) NULL,
    [BankAccountAddressLine1] NVARCHAR(50) NOT NULL,
    [BankAccountAddressLine2] NVARCHAR(50) NULL,
    [BankAccountAddressLine3] NVARCHAR(50) NOT NULL,
    [BankAccountAddressLine4] NVARCHAR(50) NOT NULL,
    [BankAccountAddressLine5] UNIQUEIDENTIFIER NOT NULL,
    [BankAccountVippsId] NVARCHAR(20) NULL,
    [ActiveStatus] BIT NOT NULL,
    [CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    [RowVersion] ROWVERSION NOT NULL,
    CONSTRAINT [FK_CompanyConfiguration_AddressLine5] FOREIGN KEY ([AddressLine5]) REFERENCES [dbo].[Country]([CountryId]),
    CONSTRAINT [FK_CompanyConfiguration_BankAccountAddressLine5] FOREIGN KEY ([BankAccountAddressLine5]) REFERENCES [dbo].[Country]([CountryId]),
    CONSTRAINT [FK_CompanyConfiguration_BankAccountCurrencyId] FOREIGN KEY ([BankAccountCurrencyId]) REFERENCES [dbo].[Currency]([CurrencyId]),
    CONSTRAINT [CC_CompanyConfiguration_BankAccountSortCode_UK] CHECK (
        ([BankAccountAddressLine5] = [dbo].[fnGetUnitedKingdomCountryId]() AND [BankAccountSortCode] IS NOT NULL AND LTRIM(RTRIM([BankAccountSortCode])) <> '')
        OR
        ([BankAccountAddressLine5] <> [dbo].[fnGetUnitedKingdomCountryId]() AND ([BankAccountSortCode] IS NULL OR LTRIM(RTRIM([BankAccountSortCode])) = ''))
    ),
    CONSTRAINT [CC_CompanyConfiguration_BankAccountVippsId_NO_SE_DK_FI] CHECK (
        ([BankAccountAddressLine5] = [dbo].[fnGetNorwayCountryId]() AND [BankAccountVippsId] IS NOT NULL AND LTRIM(RTRIM([BankAccountVippsId])) <> '')
        OR
        ([BankAccountAddressLine5] = [dbo].[fnGetNorwayCountryId]() AND [BankAccountVippsId] IS NULL OR LTRIM(RTRIM([BankAccountVippsId])) = '')
        OR
        ([BankAccountAddressLine5] = [dbo].[fnGetSwedenCountryId]() AND [BankAccountVippsId] IS NOT NULL AND LTRIM(RTRIM([BankAccountVippsId])) <> '')
        OR
        ([BankAccountAddressLine5] = [dbo].[fnGetSwedenCountryId]() AND [BankAccountVippsId] IS NULL OR LTRIM(RTRIM([BankAccountVippsId])) = '')
        OR
        ([BankAccountAddressLine5] = [dbo].[fnGetDenmarkCountryId]() AND [BankAccountVippsId] IS NOT NULL AND LTRIM(RTRIM([BankAccountVippsId])) <> '')
        OR
        ([BankAccountAddressLine5] = [dbo].[fnGetDenmarkCountryId]() AND [BankAccountVippsId] IS NULL OR LTRIM(RTRIM([BankAccountVippsId])) = '')
        OR
        ([BankAccountAddressLine5] = [dbo].[fnGetFinlandCountryId]() AND [BankAccountVippsId] IS NOT NULL AND LTRIM(RTRIM([BankAccountVippsId])) <> '')
        OR
        ([BankAccountAddressLine5] = [dbo].[fnGetFinlandCountryId]() AND [BankAccountVippsId] IS NULL OR LTRIM(RTRIM([BankAccountVippsId])) = '')
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
        [ModifiedTimestampUTC] = GETUTCDATE(),
        [ModifiedBy] = SUSER_SNAME()
    FROM 
        [dbo].[CompanyConfiguration] c
    INNER JOIN 
        inserted i ON c.[CompanyConfigurationId] = i.[CompanyConfigurationId];
END
GO