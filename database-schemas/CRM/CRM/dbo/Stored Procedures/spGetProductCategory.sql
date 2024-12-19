CREATE PROCEDURE [dbo].[spGetProductCategory]
	@productCategoryId UNIQUEIDENTIFIER
AS

SELECT
[ProductCategoryId] AS [Product Category Id],
[ProductCategory] AS [Product Category]
FROM [dbo].[ProductCategory]
WHERE [ProductCategoryId] = @productCategoryId