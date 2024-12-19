CREATE PROCEDURE [dbo].[spGetProductCategory]
	@productCategoryId UNIQUEIDENTIFIER
AS

SELECT
[Product Category Id],
[Product Category]
FROM [dbo].[vwProductCategory]
WHERE [Product Category Id] = @productCategoryId