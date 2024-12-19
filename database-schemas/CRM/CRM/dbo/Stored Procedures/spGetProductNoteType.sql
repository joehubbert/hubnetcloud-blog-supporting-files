CREATE PROCEDURE [dbo].[spGetProductNoteType]
	@productNoteTypeId UNIQUEIDENTIFIER
AS

SELECT
[Product Note Type Id],
[Product Note Type]
FROM [dbo].[vwProductNoteType]
WHERE [Product Note Type Id] = @productNoteTypeId