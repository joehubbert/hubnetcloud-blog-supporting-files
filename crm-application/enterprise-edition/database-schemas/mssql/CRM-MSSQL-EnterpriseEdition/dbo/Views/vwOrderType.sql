CREATE VIEW [dbo].[vwOrderType]
AS

SELECT
[OrderTypeId] AS [Order Type Id],
[OrderType] AS [Order Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[OrderType]