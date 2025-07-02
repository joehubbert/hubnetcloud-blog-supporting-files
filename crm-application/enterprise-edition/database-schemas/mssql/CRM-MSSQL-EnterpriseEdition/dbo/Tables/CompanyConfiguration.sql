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
    [BankAddressLine5] UNIQUEIDENTIFIER NOT NULL,
    [VippsId] NVARCHAR(20) NULL,
    [CreatedTimestampUTC] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
	[CreatedBy] NVARCHAR(50) NOT NULL DEFAULT SUSER_SNAME(),
	[ModifiedTimestampUTC] DATETIME2 NULL,
	[ModifiedBy] NVARCHAR(50) NULL,
    CONSTRAINT [FK_CompanyConfiguration_AddressLine5] FOREIGN KEY ([AddressLine5]) REFERENCES [dbo].[Country]([CountryId]),
    CONSTRAINT [FK_CompanyConfiguration_BankAddressLine5] FOREIGN KEY ([BankAddressLine5]) REFERENCES [dbo].[Country]([CountryId]),
    CONSTRAINT [FK_CompanyConfiguration_BankAccountCurrencyId] FOREIGN KEY ([BankAccountCurrencyId]) REFERENCES [dbo].[Currency]([CurrencyId]),
    CONSTRAINT [CC_CompanyConfiguration_BankSortCode_UK] CHECK (
        ([BankAddressLine5] = [dbo].[fnGetUnitedKingdomCountryId]() AND [BankSortCode] IS NOT NULL AND LTRIM(RTRIM([BankSortCode])) <> '')
        OR
        ([BankAddressLine5] <> [dbo].[fnGetUnitedKingdomCountryId]() AND ([BankSortCode] IS NULL OR LTRIM(RTRIM([BankSortCode])) = ''))
    ),
    CONSTRAINT [CC_CompanyConfiguration_VippsId_NO_SE_DK_FI] CHECK (
        ([BankAddressLine5] = [dbo].[fnGetNorwayCountryId]() AND [VippsId] IS NOT NULL AND LTRIM(RTRIM([VippsId])) <> '')
        OR
        ([BankAddressLine5] = [dbo].[fnGetNorwayCountryId]() AND [VippsId] IS NULL OR LTRIM(RTRIM([VippsId])) = '')
        OR
        ([BankAddressLine5] = [dbo].[fnGetSwedenCountryId]() AND [VippsId] IS NOT NULL AND LTRIM(RTRIM([VippsId])) <> '')
        OR
        ([BankAddressLine5] = [dbo].[fnGetSwedenCountryId]() AND [VippsId] IS NULL OR LTRIM(RTRIM([VippsId])) = '')
        OR
        ([BankAddressLine5] = [dbo].[fnGetDenmarkCountryId]() AND [VippsId] IS NOT NULL AND LTRIM(RTRIM([VippsId])) <> '')
        OR
        ([BankAddressLine5] = [dbo].[fnGetDenmarkCountryId]() AND [VippsId] IS NULL OR LTRIM(RTRIM([VippsId])) = '')
        OR
        ([BankAddressLine5] = [dbo].[fnGetFinlandCountryId]() AND [VippsId] IS NOT NULL AND LTRIM(RTRIM([VippsId])) <> '')
        OR
        ([BankAddressLine5] = [dbo].[fnGetFinlandCountryId]() AND [VippsId] IS NULL OR LTRIM(RTRIM([VippsId])) = '')
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