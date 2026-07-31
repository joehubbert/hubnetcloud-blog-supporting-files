CREATE VIEW [dbo].[vwOrderLineItemStatus]
AS

SELECT
OLIS.[OrderLineItemStatusId] AS [Order Line Item Status Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
OLIS.[OrderLineItemStatus] AS [Order Line Item Status],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
OLIS.[ActiveStatus] AS [Active Status],
OLIS.[CreatedTimestampUTC] AS [Created Timestamp UTC],
OLIS.[CreatedBy] AS [Created By],
OLIS.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
OLIS.[ModifiedBy] AS [Modified By],
OLIS.[RowVersion] AS [Row Version]
FROM [dbo].[OrderLineItemStatus] OLIS
LEFT JOIN [dbo].[CompanyConfiguration] CC ON OLIS.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON OLIS.[MasterDataTypeId] = MDT.[MasterDataTypeId]