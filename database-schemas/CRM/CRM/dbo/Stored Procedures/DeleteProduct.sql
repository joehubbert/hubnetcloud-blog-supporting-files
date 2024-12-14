CREATE PROCEDURE [dbo].[DeleteProduct]
	@productId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[Product]
WHERE [ProductId] = @productId