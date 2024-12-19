CREATE PROCEDURE [dbo].[spGetAllProductNoteType]
AS

SELECT
[Product Note Type Id],
[Product Note Type]
FROM [dbo].[vwProductNoteType]