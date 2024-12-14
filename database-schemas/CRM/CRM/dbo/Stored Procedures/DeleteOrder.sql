CREATE PROCEDURE [dbo].[DeleteOrder]
	@orderId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[Order]
WHERE [OrderId] = @orderId