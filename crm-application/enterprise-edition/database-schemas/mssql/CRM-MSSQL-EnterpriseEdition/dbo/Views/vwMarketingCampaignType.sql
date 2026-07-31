CREATE VIEW [dbo].[vwMarketingCampaignType]
AS

SELECT 
MCT.[MarketingCampaignTypeId] AS [Marketing Campaign Type Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
MCT.[MarketingCampaignType] AS [Marketing Campaign Type],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
MCT.[ActiveStatus] AS [Active Status],
MCT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
MCT.[CreatedBy] AS [Created By],
MCT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
MCT.[ModifiedBy] AS [Modified By],
MCT.[RowVersion] AS [Row Version]
FROM [dbo].[MarketingCampaignType] MCT
LEFT JOIN [dbo].[CompanyConfiguration] CC ON MCT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON MCT.[MasterDataTypeId] = MDT.[MasterDataTypeId]