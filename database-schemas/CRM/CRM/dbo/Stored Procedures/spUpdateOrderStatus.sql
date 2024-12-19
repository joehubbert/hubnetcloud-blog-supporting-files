CREATE PROCEDURE [dbo].[spUpdateOrderStatus]
	@orderStatus NVARCHAR(50),
	@orderStatusId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[OrderStatus]
SET 
	[OrderStatus] = @orderStatus
WHERE [OrderStatusId] = @orderStatusId