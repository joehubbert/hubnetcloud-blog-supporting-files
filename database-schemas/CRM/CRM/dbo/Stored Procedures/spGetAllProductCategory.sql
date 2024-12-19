CREATE PROCEDURE [dbo].[spGetAllProductCategory]
AS

SELECT
[ProductCategoryId] AS [Product Category Id],
[ProductCategory] AS [Product Category]
FROM [dbo].[ProductCategory]