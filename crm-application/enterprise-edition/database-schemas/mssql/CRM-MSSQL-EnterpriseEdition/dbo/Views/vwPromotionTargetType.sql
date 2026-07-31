CREATE VIEW [dbo].[vwPromotionTargetType]
AS

SELECT
PTT.[PromotionTargetTypeId] AS [Promotion Target Type Id],
MDT.[MasterDataTypeId] AS [Master Data Type Id],
MDT.[MasterDataType] AS [Master Data Type],
MDT.[MasterDataTypeCode] AS [Master Data Type Code],
MDT.[IsCustom] AS [Is Custom],
PTT.[PromotionTargetType] AS [Promotion Target Type],
PTT.[PromotionTargetTypeDescription] AS [Promotion Target Type Description],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
PTT.[ActiveStatus] AS [Active Status],
PTT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PTT.[CreatedBy] AS [Created By],
PTT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PTT.[ModifiedBy] AS [Modified By],
PTT.[RowVersion] AS [Row Version]
FROM [dbo].[PromotionTargetType] PTT
LEFT JOIN [dbo].[CompanyConfiguration] CC ON PTT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]
INNER JOIN [dbo].[MasterDataType] MDT ON PTT.[MasterDataTypeId] = MDT.[MasterDataTypeId]