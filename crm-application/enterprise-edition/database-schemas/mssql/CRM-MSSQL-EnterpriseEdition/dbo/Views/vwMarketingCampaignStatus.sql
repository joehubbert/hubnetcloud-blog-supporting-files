CREATE VIEW [dbo].[vwMarketingCampaignStatus]
AS

SELECT
MCS.[MarketingCampaignStatusId] AS [Marketing Campaign Status Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
MCS.[MarketingCampaignStatus] AS [Marketing Campaign Status],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
MCS.[ActiveStatus] AS [Active Status],
MCS.[CreatedTimestampUTC] AS [Created Timestamp UTC],
MCS.[CreatedBy] AS [Created By],
MCS.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
MCS.[ModifiedBy] AS [Modified By],
MCS.[RowVersion] AS [Row Version]
FROM [dbo].[MarketingCampaignStatus] MCS
LEFT JOIN [dbo].[CompanyConfiguration] CC ON MCS.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON MCS.[MasterDataTypeId] = MDT.[MasterDataTypeId]