CREATE VIEW [dbo].[vwCurrency]
AS
SELECT
C.[CurrencyId] AS [Currency Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
C.[CurrencyCode] AS [Currency Code],
C.[CurrencyName] AS [Currency Name],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
C.[ActiveStatus] AS [Active Status],
C.[CreatedTimestampUTC] AS [Created Timestamp UTC],
C.[CreatedBy] AS [Created By],
C.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
C.[ModifiedBy] AS [Modified By],
C.[RowVersion] AS [Row Version]
FROM [dbo].[Currency] C
INNER JOIN [dbo].[CompanyConfiguration] CC ON C.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON C.[MasterDataTypeId] = MDT.[MasterDataTypeId]