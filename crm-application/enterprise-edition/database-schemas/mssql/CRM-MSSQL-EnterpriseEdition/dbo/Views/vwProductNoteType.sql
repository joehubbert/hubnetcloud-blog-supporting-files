CREATE VIEW [dbo].[vwProductNoteType]
AS

SELECT
PNT.[ProductNoteTypeId] AS [Product Note Type Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
PNT.[ProductNoteType] AS [Product Note Type],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
PNT.[ActiveStatus] AS [Active Status],
PNT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PNT.[CreatedBy] AS [Created By],
PNT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PNT.[ModifiedBy] AS [Modified By],
PNT.[RowVersion] AS [Row Version]
FROM [dbo].[ProductNoteType] PNT
LEFT JOIN [dbo].[CompanyConfiguration] CC ON PNT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON PNT.[MasterDataTypeId] = MDT.[MasterDataTypeId]