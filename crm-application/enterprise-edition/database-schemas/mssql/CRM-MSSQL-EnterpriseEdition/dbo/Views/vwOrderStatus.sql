CREATE VIEW [dbo].[vwOrderStatus]
AS

SELECT
OS.[OrderStatusId] AS [Order Status Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
OS.[OrderStatus] AS [Order Status],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
OS.[ActiveStatus] AS [Active Status],
OS.[CreatedTimestampUTC] AS [Created Timestamp UTC],
OS.[CreatedBy] AS [Created By],
OS.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
OS.[ModifiedBy] AS [Modified By],
OS.[RowVersion] AS [Row Version]
FROM [dbo].[OrderStatus] OS
LEFT JOIN [dbo].[CompanyConfiguration] CC ON OS.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON OS.[MasterDataTypeId] = MDT.[MasterDataTypeId]
