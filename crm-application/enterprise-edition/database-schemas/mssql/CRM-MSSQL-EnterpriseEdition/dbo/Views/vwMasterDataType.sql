CREATE VIEW [dbo].[vwMasterDataType]
AS

SELECT
[MasterDataTypeId] AS [Master Data Type Id],
[MasterDataType] AS [Master Data Type],
[SystemDefined] AS [System Defined],
[UserDefined] AS [User Defined],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[MasterDataType]