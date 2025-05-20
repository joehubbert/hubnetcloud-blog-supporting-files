CREATE VIEW [dbo].[vwProductNoteSummary]
AS

SELECT
PN.[ProductId] AS [Product Id],
PN.[ProductNoteId] AS [Product Note Id],
PN.[ProductNoteTitle] AS [Product Note Title],
PNT.[ProductNoteType] AS [Product Note Type],
LEFT(PN.[ProductNote],50) AS [Product Note],
PN.[CreatedTimestamp] AS [Created Timestamp],
PN.[CreatedBy] AS [Created By],
PN.[ModifiedTimestamp] AS [Modified Timestamp],
PN.[ModifiedBy] AS [Modified By]
FROM [dbo].[ProductNote] PN
INNER JOIN [dbo].[ProductNoteType] PNT ON PN.[ProductNoteTypeId] = PNT.[ProductNoteTypeId]