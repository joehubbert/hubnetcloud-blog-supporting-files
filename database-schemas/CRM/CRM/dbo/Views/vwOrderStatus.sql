CREATE VIEW [dbo].[vwOrderStatus]
AS

SELECT
[OrderStatusId]	AS [Order Status Id],
[OrderStatus] AS [Order Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[OrderStatus]