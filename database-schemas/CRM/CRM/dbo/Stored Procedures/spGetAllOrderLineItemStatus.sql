CREATE PROCEDURE [dbo].[spGetAllOrderLineItemStatus]
AS

SELECT
[Order Line Item Status Id],
[Order Line Item Status]
FROM [dbo].[vwOrderLineItemStatus]