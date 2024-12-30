CREATE PROCEDURE [dbo].[spGetAllProductCategory]
AS

SELECT
[Product Category Id],
[Product Category],
[Active Status]
FROM [dbo].[vwProductCategory]