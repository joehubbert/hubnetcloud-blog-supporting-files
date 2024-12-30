CREATE PROCEDURE [dbo].[spGetAllOrderLineItemStatus]
AS

SELECT
[Order Line Item Status Id],
[Order Line Item Status],
[Active Status]
FROM [dbo].[vwOrderLineItemStatus]