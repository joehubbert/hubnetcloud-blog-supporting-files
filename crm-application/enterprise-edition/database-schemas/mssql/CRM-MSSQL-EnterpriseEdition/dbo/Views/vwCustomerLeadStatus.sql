CREATE VIEW [dbo].[vwCustomerLeadStatus]
AS

SELECT
CLS.[CustomerLeadStatusId]	AS [Customer Lead Status Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
CLS.[CustomerLeadStatus] AS [Customer Lead Status],
CLS.[CustomerLeadStatusCode] AS [Customer Lead Status Code],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
CLS.[ActiveStatus] AS [Active Status],
CLS.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CLS.[CreatedBy] AS [Created By],
CLS.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CLS.[ModifiedBy] AS [Modified By],
CLS.[RowVersion] AS [Row Version]
FROM [dbo].[CustomerLeadStatus] CLS
LEFT JOIN [dbo].[CompanyConfiguration] CC ON CLS.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON CLS.[MasterDataTypeId] = MDT.[MasterDataTypeId]