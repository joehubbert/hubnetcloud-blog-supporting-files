CREATE VIEW [dbo].[vwCompanyConfiguration]
AS

SELECT
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
CC.[CompanyLogo] AS [Company Logo],
CC.[AddressLine1] AS [Address Line 1],
CC.[AddressLine2] AS [Address Line 2],
CC.[AddressLine3] AS [Address Line 3],
CC.[AddressLine4] AS [Address Line 4],
CC.[AddressLine5] AS [Address Line 5],
CC.[TelephoneNumber] AS [Telephone Number],
CC.[EmailAddress] AS [Email Address],
CC.[EmailTopLevelDomain] AS [Email Top Level Domain],
CC.[VATNumber] AS [VAT Number],
CC.[WebsiteURL] AS [Website URL],
CC.[BankAccountBalance] AS [Bank Account Balance],
CC.[BankAccountCurrencyId] AS [Bank Account Currency Id],
C.[CurrencyCode] AS [Bank Account Currency Code],
C.[CurrencyName] AS [Bank Account Currency Name],
CC.[BankAccountNumber] AS [Bank Account Number],
CC.[BankAccountName] AS [Bank Account Name],
CC.[BankSortCode] AS [Bank Sort Code],
CC.[BankIBAN] AS [Bank IBAN],
CC.[BankSWIFT] AS [Bank SWIFT],
CC.[BankAddressLine1] AS [Bank Address Line 1],
CC.[BankAddressLine2] AS [Bank Address Line 2],
CC.[BankAddressLine3] AS [Bank Address Line 3],
CC.[BankAddressLine4] AS [Bank Address Line 4],
CC.[BankAddressLine5] AS [Bank Address Line 5],
CC.[CreatedTimestamp] AS [Created Timestamp],
CC.[CreatedBy] AS [Created By],
CC.[ModifiedTimestamp] AS [Modified Timestamp],
CC.[ModifiedBy] AS [Modified By]
FROM [dbo].[CompanyConfiguration] CC
INNER JOIN [dbo].[Currency] C ON CC.[BankAccountCurrencyId] = C.[CurrencyId]