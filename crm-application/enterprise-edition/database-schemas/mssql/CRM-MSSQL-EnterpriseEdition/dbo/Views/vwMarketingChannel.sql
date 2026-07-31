CREATE VIEW [dbo].[vwMarketingChannel]
AS

SELECT
MC.[MarketingChannelId] AS [Marketing Channel Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
MC.[MarketingChannel] AS [Marketing Channel],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
MC.[ActiveStatus] AS [Active Status],
MC.[CreatedTimestampUTC] AS [Created Timestamp UTC],
MC.[CreatedBy] AS [Created By],
MC.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
MC.[ModifiedBy] AS [Modified By],
MC.[RowVersion] AS [Row Version]
FROM [dbo].[MarketingChannel] MC
LEFT JOIN [dbo].[CompanyConfiguration] CC ON MC.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON MC.[MasterDataTypeId] = MDT.[MasterDataTypeId]