CREATE VIEW [dbo].[vwCustomerLeadType]
AS

SELECT
CLT.[CustomerLeadTypeId] AS [Customer Lead Type Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
CLT.[CustomerLeadType] AS [Customer Lead Type],
CLT.[CustomerLeadTypeCode] AS [Customer Lead Type Code],
CLT.[CustomerLeadTypeDescription] AS [Customer Lead Type Description],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
CLT.[ActiveStatus] AS [Active Status],
CLT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CLT.[CreatedBy] AS [Created By],
CLT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CLT.[ModifiedBy] AS [Modified By],
CLT.[RowVersion] AS [Row Version]
FROM [dbo].[CustomerLeadType] CLT
LEFT JOIN [dbo].[CompanyConfiguration] CC ON CLT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON CLT.[MasterDataTypeId] = MDT.[MasterDataTypeId]