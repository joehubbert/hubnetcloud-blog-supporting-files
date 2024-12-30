CREATE PROCEDURE [dbo].[spGetAllOrderStatus]
AS

SELECT
[Order Status Id],
[Order Status],
[Active Status]
FROM [dbo].[vwOrderStatus]