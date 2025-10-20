CREATE VIEW [dbo].[vwProductNote]
AS

SELECT
PN.[ProductNoteId] AS [Product Note Id],
PN.[ProductNoteTitle] AS [Product Note Title],
PNT.[ProductNoteTypeId] AS [Product Note Type Id],
PNT.[ProductNoteType] AS [Product Note Type],
PN.[ProductNote] AS [Product Note],
PN.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PN.[CreatedBy] AS [Created By],
PN.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PN.[ModifiedBy] AS [Modified By],
PN.[RowVersion] AS [Row Version]
FROM [dbo].[ProductNote] PN
INNER JOIN [dbo].[ProductNoteType] PNT ON PN.[ProductNoteTypeId] = PNT.[ProductNoteTypeId]