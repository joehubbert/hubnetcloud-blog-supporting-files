CREATE VIEW [dbo].[vwPaymentMethod]
AS

SELECT
PM.[PaymentMethodId] AS [Payment Method Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
PM.[PaymentMethod] AS [Payment Method],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
PM.[ActiveStatus] AS [Active Status],
PM.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PM.[CreatedBy] AS [Created By],
PM.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PM.[ModifiedBy] AS [Modified By],
PM.[RowVersion] AS [Row Version]
FROM [dbo].[PaymentMethod] PM
LEFT JOIN [dbo].[CompanyConfiguration] CC ON PM.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON PM.[MasterDataTypeId] = MDT.[MasterDataTypeId]
