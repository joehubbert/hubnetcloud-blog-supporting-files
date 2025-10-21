CREATE VIEW [dbo].[vwCustomerLeadNoteType]
AS

SELECT
CLNT.[CustomerLeadNoteTypeId] AS [Customer Lead Note Type Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
CLNT.[CustomerLeadNoteType] AS [Customer Lead Note Type],
CLNT.[CustomerLeadNoteTypeCode] AS [Customer Lead Note Type Code],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
CLNT.[ActiveStatus] AS [Active Status],
CLNT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CLNT.[CreatedBy] AS [Created By],
CLNT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CLNT.[ModifiedBy] AS [Modified By],
CLNT.[RowVersion] AS [Row Version]
FROM [dbo].[CustomerLeadNoteType] CLNT
LEFT JOIN [dbo].[CompanyConfiguration] CC ON CLNT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON CLNT.[MasterDataTypeId] = MDT.[MasterDataTypeId]