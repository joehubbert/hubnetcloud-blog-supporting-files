CREATE PROCEDURE [dbo].[DeleteProductCategory]
	@productCategoryId UNIQUEIDENTIFIER
AS
DELETE FROM [dbo].[ProductCategory]
WHERE [ProductCategoryId] = @productCategoryId