CREATE VIEW [dbo].[vwOrderStatusHistory]
AS

SELECT
[OrderStatusHistoryId] AS [Order Status History Id],
[OrderId] AS [Order Id],
[OrderStatusId] AS [Order Status Id],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[OrderStatusHistory]