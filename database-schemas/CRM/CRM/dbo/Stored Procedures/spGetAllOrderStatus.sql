CREATE PROCEDURE [dbo].[spGetAllOrderStatus]
AS

SELECT
[Order Status Id],
[Order Status]
FROM [dbo].[vwOrderStatus]