CREATE VIEW [dbo].[vwPromotionType]
AS

SELECT
PT.[PromotionTypeId] AS [Promotion Type Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
PT.[PromotionType] AS [Promotion Type],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
PT.[ActiveStatus] AS [Active Status],
PT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PT.[CreatedBy] AS [Created By],
PT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PT.[ModifiedBy] AS [Modified By],
PT.[RowVersion] AS [Row Version]
FROM [dbo].[PromotionType] PT
LEFT JOIN [dbo].[CompanyConfiguration] CC ON PT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON PT.[MasterDataTypeId] = MDT.[MasterDataTypeId]