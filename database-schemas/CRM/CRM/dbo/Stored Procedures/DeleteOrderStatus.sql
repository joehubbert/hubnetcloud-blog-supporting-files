CREATE PROCEDURE [dbo].[DeleteOrderStatus]
	@orderStatusId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[OrderStatus]
WHERE [OrderStatusId] = @orderStatusId