CREATE PROCEDURE [dbo].[spCreateOrderStatusHistory]
	@orderId UNIQUEIDENTIFIER,
	@orderStatusId UNIQUEIDENTIFIER
AS

INSERT INTO [dbo].[OrderStatusHistory]
(
	[OrderId],
	[OrderStatusId]
)
VALUES
(
	@orderId,
	@orderStatusId
)