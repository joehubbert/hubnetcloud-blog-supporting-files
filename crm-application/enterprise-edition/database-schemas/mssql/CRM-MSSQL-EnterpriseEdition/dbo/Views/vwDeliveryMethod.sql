CREATE VIEW [dbo].[vwDeliveryMethod]
AS

SELECT
DM.[DeliveryMethodId] AS [Delivery Method Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
DM.[DeliveryMethod] AS [Delivery Method],
DM.[DeliveryCost] AS [Delivery Cost],
DM.[DeliveryTimeDays] AS [Delivery Time Days],
TP.[TaxProfile] AS [Tax Profile],
TP.[TaxRate] AS [Tax Rate],
DM.[ActiveStatus] AS [Delivery Method Active Status],
DM.[CreatedTimestampUTC] AS [Created Timestamp UTC],
DM.[CreatedBy] AS [Created By],
DM.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
DM.[ModifiedBy] AS [Modified By],
DM.[RowVersion] AS [Row Version]
FROM [dbo].[DeliveryMethod] DM
INNER JOIN [dbo].[TaxProfile] TP ON DM.[TaxProfileId] = TP.[TaxProfileId]
LEFT JOIN [dbo].[CompanyConfiguration] CC ON DM.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON DM.[MasterDataTypeId] = MDT.[MasterDataTypeId]
