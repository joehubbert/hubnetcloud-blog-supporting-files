CREATE VIEW [dbo].[vwCurrencyConversion]
AS
SELECT
CC.[CurrencyConversionId] AS [Currency Conversion Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
CCFG.[CompanyConfigurationId] AS [Company Configuration Id],
CCFG.[CompanyName] AS [Company Name],
CONCAT(CURA.[CurrencyCode], ' - ', CURB.[CurrencyCode]) AS [Currency Conversion Friendly Name],
CC.[BaseCurrencyId] AS [Base Currency Id],
CURA.[CurrencyCode] AS [Base Currency Code],
CURA.[CurrencyName] AS [Base Currency Name],
CC.[TargetCurrencyId] AS [Target Currency Id],
CURB.[CurrencyCode] AS [Target Currency Code],
CURB.[CurrencyName] AS [Target Currency Name],
CC.[BaseCurrencyConversionRate] AS [Base Currency Conversion Rate],
CC.[TargetCurrencyConversionRate] AS [Target Currency Conversion Rate],
CC.[EffectiveDate] AS [Effective Date],
CC.[ExpiryDate] AS [Expiry Date],
CC.[ActiveStatus] AS [Active Status],
CC.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CC.[CreatedBy] AS [Created By],
CC.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CC.[ModifiedBy] AS [Modified By],
CC.[RowVersion] AS [Row Version]
FROM [dbo].[CurrencyConversion] CC
INNER JOIN [dbo].[Currency] CURA ON CC.[BaseCurrencyId] = CURA.[CurrencyId]
INNER JOIN [dbo].[Currency] CURB ON CC.[TargetCurrencyId] = CURB.[CurrencyId]
LEFT JOIN [dbo].[CompanyConfiguration] CCFG ON CC.[CompanyConfigurationId] = CCFG.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON CC.[MasterDataTypeId] = MDT.[MasterDataTypeId]