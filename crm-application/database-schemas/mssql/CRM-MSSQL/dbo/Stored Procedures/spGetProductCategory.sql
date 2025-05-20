CREATE PROCEDURE [dbo].[spGetProductCategory]
	@productCategoryId UNIQUEIDENTIFIER
AS

SELECT
[Product Category Id],
[Product Category],
[Active Status],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwProductCategory]
WHERE [Product Category Id] = @productCategoryId