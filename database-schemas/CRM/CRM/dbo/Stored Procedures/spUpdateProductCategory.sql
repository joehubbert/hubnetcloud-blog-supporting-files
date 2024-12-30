CREATE PROCEDURE [dbo].[spUpdateProductCategory]
	@activeStatus BIT,
	@productCatagory NVARCHAR(50),
	@productCategoryId UNIQUEIDENTIFIER
AS

UPDATE [dbo].[ProductCategory]
SET 
	[ActiveStatus] = @activeStatus,
	[ProductCategory] = @productCatagory
WHERE [ProductCategoryId] = @productCategoryId