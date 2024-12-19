CREATE PROCEDURE [dbo].[spGetProductCategory]
	@productCategoryId UNIQUEIDENTIFIER
AS

SELECT
[Product Category Id],
[Product Category],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwProductCategory]
WHERE [Product Category Id] = @productCategoryId