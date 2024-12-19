CREATE VIEW [dbo].[vwProductNote]
AS

SELECT
PN.[ProductNoteId] AS [Product Note Id],
PN.[ProductNoteTitle] AS [Product Note Title],
PNT.[ProductNoteType] AS [Product Note Type],
PN.[ProductNote] AS [Product Note]
FROM [dbo].[ProductNote] PN
INNER JOIN [dbo].[ProductNoteType] PNT ON PN.[ProductNoteTypeId] = PNT.[ProductNoteTypeId]