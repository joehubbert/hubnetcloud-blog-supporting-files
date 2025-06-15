CREATE VIEW [dbo].[vwCurrencyConversion]
AS
SELECT
CC.[CurrencyConversionId] AS [Currency Conversion Id],
CCFG.[CompanyConfigurationId] AS [Company Configuration Id],
CCFG.[CompanyName] AS [Company Name],
CONCAT(CURA.[CurrencyCode], ' - ', CURB.[CurrencyCode]) AS [Currency Conversion Friendly Name],
CC.[CurrencyAId] AS [Currency A Id],
CURA.[CurrencyCode] AS [Currency A Code],
CURA.[CurrencyName] AS [Currency A Name],
CC.[CurrencyBId] AS [Currency B Id],
CURB.[CurrencyCode] AS [Currency B Code],
CURB.[CurrencyName] AS [Currency B Name],
CC.[ConversionRate] AS [Conversion Rate],
CC.[EffectiveDate] AS [Effective Date],
CC.[ExpiryDate] AS [Expiry Date],
CC.[ActiveStatus] AS [Active Status],
CC.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CC.[CreatedBy] AS [Created By],
CC.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CC.[ModifiedBy] AS [Modified By]
FROM [dbo].[CurrencyConversion] CC
INNER JOIN [dbo].[Currency] CURA ON CC.[CurrencyAId] = CURA.[CurrencyId]
INNER JOIN [dbo].[Currency] CURB ON CC.[CurrencyBId] = CURB.[CurrencyId]
INNER JOIN [dbo].[CompanyConfiguration] CCFG ON CC.[CompanyConfigurationId] = CCFG.[CompanyConfigurationId]