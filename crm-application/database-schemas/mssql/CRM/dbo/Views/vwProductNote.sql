CREATE VIEW [dbo].[vwProductNote]
AS

SELECT
PN.[ProductNoteId] AS [Product Note Id],
PN.[ProductNoteTitle] AS [Product Note Title],
PNT.[ProductNoteType] AS [Product Note Type],
PN.[ProductNote] AS [Product Note],
PN.[CreatedTimestamp] AS [Created Timestamp],
PN.[CreatedBy] AS [Created By],
PN.[ModifiedTimestamp] AS [Modified Timestamp],
PN.[ModifiedBy] AS [Modified By]
FROM [dbo].[ProductNote] PN
INNER JOIN [dbo].[ProductNoteType] PNT ON PN.[ProductNoteTypeId] = PNT.[ProductNoteTypeId]