CREATE PROCEDURE [dbo].[spGetProductNote]
	@productNoteId UNIQUEIDENTIFIER
AS

SELECT
[Product Note Id],
[Product Note Title],
[Product Note Type],
[Product Note]
FROM [dbo].[vwProductNote]
WHERE [Product Note Id] = @productNoteId