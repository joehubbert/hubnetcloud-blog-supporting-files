CREATE PROCEDURE [dbo].[spGetAllProductNoteType]
AS

SELECT
[Product Note Type Id],
[Product Note Type],
[Active Status]
FROM [dbo].[vwProductNoteType]