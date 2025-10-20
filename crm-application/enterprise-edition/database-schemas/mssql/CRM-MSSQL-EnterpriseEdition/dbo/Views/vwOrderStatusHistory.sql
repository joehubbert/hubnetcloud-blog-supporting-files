CREATE VIEW [dbo].[vwOrderStatusHistory]
AS

SELECT
OSH.[OrderStatusHistoryId] AS [Order Status History Id],
OSH.[OrderId] AS [Order Id],
OS.[OrderStatusId] AS [Order Status Id],
OS.[OrderStatus] AS [Order Status],
OSH.[CreatedTimestampUTC] AS [Created Timestamp UTC],
OSH.[CreatedBy] AS [Created By],
OSH.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
OSH.[ModifiedBy] AS [Modified By],
OSH.[RowVersion] AS [Row Version]
FROM [dbo].[OrderStatusHistory] OSH
INNER JOIN [dbo].[OrderStatus] OS ON OSH.[OrderStatusId] = OS.[OrderStatusId]