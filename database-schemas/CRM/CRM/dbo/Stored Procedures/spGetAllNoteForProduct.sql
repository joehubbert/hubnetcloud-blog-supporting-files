CREATE PROCEDURE [dbo].[spGetAllNoteForProduct]
	@productId UNIQUEIDENTIFIER
AS

SELECT
PN.[ProductNoteId] AS [Product Note Id],
PN.[ProductNoteTitle] AS [Product Note Title],
PNT.[ProductNoteType] AS [Product Note Type],
LEFT(PN.[ProductNote],50) AS [Product Note],
CAST(PN.[CreatedTimestamp] AS DATE) AS [Date Logged],
PN.[CreatedBy] AS [Logged By]
FROM [dbo].[ProductNote] PN
INNER JOIN [dbo].[ProductNoteType] PNT ON PN.[ProductNoteTypeId] = PNT.[ProductNoteTypeId]
WHERE PN.[ProductId] = @productId