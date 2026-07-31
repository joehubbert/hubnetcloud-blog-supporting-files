CREATE VIEW [dbo].[vwOrderPaymentStatus]
AS

SELECT
OPS.[OrderPaymentStatusId] AS [Order Payment Status Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
OPS.[OrderPaymentStatus] AS [Order Payment Status],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
OPS.[ActiveStatus] AS [Active Status],
OPS.[CreatedTimestampUTC] AS [Created Timestamp UTC],
OPS.[CreatedBy] AS [Created By],
OPS.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
OPS.[ModifiedBy] AS [Modified By],
OPS.[RowVersion] AS [Row Version]
FROM [dbo].[OrderPaymentStatus] OPS
LEFT JOIN [dbo].[CompanyConfiguration] CC ON OPS.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON OPS.[MasterDataTypeId] = MDT.[MasterDataTypeId]
