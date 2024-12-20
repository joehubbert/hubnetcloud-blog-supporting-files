CREATE VIEW [dbo].[vwOrderLineItemStatus]
AS
SELECT
[OrderLineItemStatusId]	AS [Order Line Item Status Id],
[OrderLineItemStatus] AS [Order Line Item Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[OrderLineItemStatus]