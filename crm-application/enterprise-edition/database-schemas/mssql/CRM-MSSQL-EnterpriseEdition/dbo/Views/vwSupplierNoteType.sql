CREATE VIEW [dbo].[vwSupplierNoteType]
AS

SELECT
SNT.[SupplierNoteTypeId] AS [Supplier Note Type Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
SNT.[SupplierNoteType] AS [Supplier Note Type],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
SNT.[ActiveStatus] AS [Active Status],
SNT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
SNT.[CreatedBy] AS [Created By],
SNT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
SNT.[ModifiedBy] AS [Modified By],
SNT.[RowVersion] AS [Row Version]
FROM [dbo].[SupplierNoteType] SNT
LEFT JOIN [dbo].[CompanyConfiguration] CC ON SNT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON SNT.[MasterDataTypeId] = MDT.[MasterDataTypeId]