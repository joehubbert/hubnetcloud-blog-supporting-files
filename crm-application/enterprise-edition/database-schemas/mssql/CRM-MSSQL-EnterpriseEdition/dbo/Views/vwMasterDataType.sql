CREATE VIEW [dbo].[vwMasterDataType]
AS

SELECT
[MasterDataTypeId] AS [Master Data Type Id],
[MasterDataType] AS [Master Data Type],
[MasterDataTypeCode] AS [Master Data Type Code],
[IsCustom] AS [Is Custom],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[MasterDataType]