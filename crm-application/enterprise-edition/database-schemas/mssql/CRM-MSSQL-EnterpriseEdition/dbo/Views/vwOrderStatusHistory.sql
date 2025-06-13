CREATE VIEW [dbo].[vwOrderStatusHistory]
AS

SELECT
OSH.[OrderStatusHistoryId] AS [Order Status History Id],
OSH.[OrderId] AS [Order Id],
OS.[OrderStatusId] AS [Order Status Id],
OS.[OrderStatus] AS [Order Status],
OSH.[CreatedTimestamp] AS [Created Timestamp],
OSH.[CreatedBy] AS [Created By],
OSH.[ModifiedTimestamp] AS [Modified Timestamp],
OSH.[ModifiedBy] AS [Modified By]
FROM [dbo].[OrderStatusHistory] OSH
INNER JOIN [dbo].[OrderStatus] OS ON OSH.[OrderStatusId] = OS.[OrderStatusId]