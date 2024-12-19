CREATE PROCEDURE [dbo].[spGetProductNote]
	@productNoteId UNIQUEIDENTIFIER
AS

SELECT
[Product Note Id],
[Product Note Title],
[Product Note Type],
[Product Note],
[Created Timestamp],
[Created By],
[Modified Timestamp],
[Modified By]
FROM [dbo].[vwProductNote]
WHERE [Product Note Id] = @productNoteId