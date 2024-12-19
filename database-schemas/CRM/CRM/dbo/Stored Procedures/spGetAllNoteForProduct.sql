CREATE PROCEDURE [dbo].[spGetAllNoteForProduct]
	@productId UNIQUEIDENTIFIER
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
FROM [dbo].[vwProductNoteSummary]
WHERE [Product Id] = @productId