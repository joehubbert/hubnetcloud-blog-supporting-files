CREATE VIEW [dbo].[vwHTMLTemplateType]
AS

SELECT
HTMLTT.[HTMLTemplateTypeId] AS [HTML Template Type Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
HTMLTT.[HTMLTemplateType] AS [HTML Template Type],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
HTMLTT.[ActiveStatus] AS [Active Status],
HTMLTT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
HTMLTT.[CreatedBy] AS [Created By],
HTMLTT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
HTMLTT.[ModifiedBy] AS [Modified By],
HTMLTT.[RowVersion] AS [Row Version]
FROM [dbo].[HTMLTemplateType] HTMLTT
LEFT JOIN [dbo].[CompanyConfiguration] CC ON HTMLTT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON HTMLTT.[MasterDataTypeId] = MDT.[MasterDataTypeId]