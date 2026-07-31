CREATE VIEW [dbo].[vwSupplierOrderStatus]
AS

SELECT
SOS.[SupplierOrderStatusId] AS [Supplier Order Status Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
SOS.[SupplierOrderStatus] AS [Supplier Order Status],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
SOS.[ActiveStatus] AS [Active Status],
SOS.[CreatedTimestampUTC] AS [Created Timestamp UTC],
SOS.[CreatedBy] AS [Created By],
SOS.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
SOS.[ModifiedBy] AS [Modified By],
SOS.[RowVersion] AS [Row Version]
FROM [dbo].[SupplierOrderStatus] SOS
LEFT JOIN [dbo].[CompanyConfiguration] CC ON SOS.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON SOS.[MasterDataTypeId] = MDT.[MasterDataTypeId]
