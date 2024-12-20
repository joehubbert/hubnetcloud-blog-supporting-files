CREATE PROCEDURE [dbo].[spGetOrderStatus]
	@orderStatusId UNIQUEIDENTIFIER
AS

SELECT
[Order Status Id],
[Order Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwOrderStatus]
WHERE [Order Status Id] = @orderStatusId