CREATE PROCEDURE [dbo].[spGetAllOrderStatusHistory]
	@orderId UNIQUEIDENTIFIER
AS

SELECT
[Order Status History Id],
[Order Status Id],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwOrderStatusHistory]
WHERE [Order Id] = @orderId