CREATE PROCEDURE [dbo].[spUpdateProductCategory]
	@productCatagory NVARCHAR(50),
	@productCategoryId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[ProductCategory]
SET 
	[ProductCategory] = @productCatagory
WHERE [ProductCategoryId] = @productCategoryId