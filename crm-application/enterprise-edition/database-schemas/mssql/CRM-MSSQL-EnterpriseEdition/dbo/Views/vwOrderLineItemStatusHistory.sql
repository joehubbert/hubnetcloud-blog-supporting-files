CREATE VIEW [dbo].[vwOrderLineItemStatusHistory]
AS

SELECT
OLISH.[OrderLineItemStatusHistoryId] AS [Order Line Item Status History Id],
OLISH.[OrderLineItemId] AS [Order Line Item Id],
OLIS.[OrderLineItemStatusId] AS [Order Line Item Status Id],
OLIS.[OrderLineItemStatus] AS [Order Line Item Status],
OLISH.[CreatedTimestamp] AS [Created Timestamp],
OLISH.[CreatedBy] AS [Created By],
OLISH.[ModifiedTimestamp] AS [Modified Timestamp],
OLISH.[ModifiedBy] [Modified By]
FROM [dbo].[OrderLineItemStatusHistory] OLISH
INNER JOIN [dbo].[OrderLineItemStatus] OLIS ON OLISH.[OrderLineItemStatusId] = OLIS.[OrderLineItemStatusId]