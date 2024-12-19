CREATE PROCEDURE [dbo].[spGetOrderStatus]
	@orderStatusId UNIQUEIDENTIFIER
AS

SELECT
[Order Status Id],
[Order Status]
FROM [dbo].[vwOrderStatus]
WHERE [Order Status Id] = @orderStatusId