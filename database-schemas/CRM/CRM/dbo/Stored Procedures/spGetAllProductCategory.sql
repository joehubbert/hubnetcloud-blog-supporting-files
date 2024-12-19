CREATE PROCEDURE [dbo].[spGetAllProductCategory]
AS

SELECT
[Product Category Id],
[Product Category]
FROM [dbo].[vwProductCategory]