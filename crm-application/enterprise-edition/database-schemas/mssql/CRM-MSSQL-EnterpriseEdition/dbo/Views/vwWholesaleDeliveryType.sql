CREATE VIEW [dbo].[vwWholesaleDeliveryType]
AS

SELECT
WDT.[WholesaleDeliveryTypeId] AS [Wholesale Delivery Type Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
WDT.[WholesaleDeliveryType] AS [Wholesale Delivery Type],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
WDT.[ActiveStatus] AS [Active Status],
WDT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
WDT.[CreatedBy] AS [Created By],
WDT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
WDT.[ModifiedBy] AS [Modified By],
WDT.[RowVersion] AS [Row Version]
FROM [dbo].[WholesaleDeliveryType] WDT
LEFT JOIN [dbo].[CompanyConfiguration] CC ON WDT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON WDT.[MasterDataTypeId] = MDT.[MasterDataTypeId]
