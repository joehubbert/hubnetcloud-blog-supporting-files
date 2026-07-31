CREATE VIEW [dbo].[vwSupplierOrderLineItemStatus]
AS

SELECT
SOLIS.[SupplierOrderLineItemStatusId] AS [Supplier Order Line Item Status Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
SOLIS.[SupplierOrderLineItemStatus] AS [Supplier Order Line Item Status],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
SOLIS.[ActiveStatus] AS [Active Status],
SOLIS.[CreatedTimestampUTC] AS [Created Timestamp UTC],
SOLIS.[CreatedBy] AS [Created By],
SOLIS.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
SOLIS.[ModifiedBy] AS [Modified By],
SOLIS.[RowVersion] AS [Row Version]
FROM [dbo].[SupplierOrderLineItemStatus] SOLIS
LEFT JOIN [dbo].[CompanyConfiguration] CC ON SOLIS.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON SOLIS.[MasterDataTypeId] = MDT.[MasterDataTypeId]
