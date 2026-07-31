CREATE VIEW [dbo].[vwCustomerNoteType]
AS

SELECT
CNT.[CustomerNoteTypeId] AS [Customer Note Type Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
CNT.[CustomerNoteType] AS [Customer Note Type],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
CNT.[ActiveStatus] AS [Active Status],
CNT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CNT.[CreatedBy] AS [Created By],
CNT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CNT.[ModifiedBy] AS [Modified By],
CNT.[RowVersion] AS [Row Version]
FROM [dbo].[CustomerNoteType] CNT
LEFT JOIN [dbo].[CompanyConfiguration] CC ON CNT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON CNT.[MasterDataTypeId] = MDT.[MasterDataTypeId]