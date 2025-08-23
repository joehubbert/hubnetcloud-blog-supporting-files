CREATE VIEW [dbo].[vwSupplier]
AS

SELECT
S.[SupplierId] AS [Supplier Id],
S.[SupplierName] AS [Supplier Name],
S.[AddressLine1] AS [Address Line 1],
S.[AddressLine2] AS [Address Line 2],
S.[AddressLine3] AS [Address Line 3],
S.[AddressLine4] AS [Address Line 4],
S.[AddressLine5] AS [Address Line 5],
S.[TelephoneNumber] AS [Telephone Number],
S.[EmailAddress] AS [Email Address],
S.[PaymentDays] AS [Payment Days],
C.[CurrencyId] AS [Payment Currency Id],
C.[CurrencyCode] AS [Payment Currency],
S.[VATRegistered] AS [VAT Registered],
S.[VATNumber] AS [VAT Number],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
S.[ActiveStatus] AS [Active Status],
S.[CreatedTimestampUTC] AS [Created Timestamp UTC],
S.[CreatedBy] AS [Created By],
S.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
S.[ModifiedBy] AS [Modified By]
FROM [dbo].[Supplier] S
INNER JOIN [dbo].[CompanyConfiguration] CC ON S.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[Currency] C ON S.[PaymentCurrencyId] = C.[CurrencyId]