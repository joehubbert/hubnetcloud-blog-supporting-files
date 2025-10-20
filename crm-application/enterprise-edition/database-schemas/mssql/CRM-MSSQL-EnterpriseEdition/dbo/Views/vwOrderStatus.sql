CREATE VIEW [dbo].[vwOrderStatus]
AS

SELECT
[OrderStatusId]	AS [Order Status Id],
[OrderStatus] AS [Order Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[OrderStatus]