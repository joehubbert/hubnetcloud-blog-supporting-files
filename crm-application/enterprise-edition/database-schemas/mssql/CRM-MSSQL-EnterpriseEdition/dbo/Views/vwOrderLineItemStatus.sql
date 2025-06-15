CREATE VIEW [dbo].[vwOrderLineItemStatus]
AS

SELECT
[OrderLineItemStatusId]	AS [Order Line Item Status Id],
[OrderLineItemStatus] AS [Order Line Item Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[OrderLineItemStatus]