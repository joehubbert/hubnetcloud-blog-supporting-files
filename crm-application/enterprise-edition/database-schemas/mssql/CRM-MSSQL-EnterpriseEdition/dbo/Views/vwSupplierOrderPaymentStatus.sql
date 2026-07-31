CREATE VIEW [dbo].[vwSupplierOrderPaymentStatus]
AS

SELECT
SOPS.[SupplierOrderPaymentStatusId] AS [Supplier Order Payment Status Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
SOPS.[SupplierOrderPaymentStatus] AS [Supplier Order Payment Status],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
SOPS.[ActiveStatus] AS [Active Status],
SOPS.[CreatedTimestampUTC] AS [Created Timestamp UTC],
SOPS.[CreatedBy] AS [Created By],
SOPS.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
SOPS.[ModifiedBy] AS [Modified By],
SOPS.[RowVersion] AS [Row Version]
FROM [dbo].[SupplierOrderPaymentStatus] SOPS
LEFT JOIN [dbo].[CompanyConfiguration] CC ON SOPS.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON SOPS.[MasterDataTypeId] = MDT.[MasterDataTypeId]
