CREATE PROCEDURE [dbo].[spUpdateOrderStatus]
	@activeStatus BIT,
	@orderStatus NVARCHAR(50),
	@orderStatusId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[OrderStatus]
SET 
	[ActiveStatus] = @activeStatus,
	[OrderStatus] = @orderStatus
WHERE [OrderStatusId] = @orderStatusId