CREATE VIEW [dbo].[vwOrderLineItemStatusHistory]
AS

SELECT
[OrderLineItemStatusHistoryId] AS [Order Line Item Status History Id],
[OrderLineItemId] AS [Order Line Item Id],
[OrderLineItemStatusId] AS [Order Line Item Status Id],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] [Modified By]
FROM [dbo].[OrderLineItemStatusHistory]