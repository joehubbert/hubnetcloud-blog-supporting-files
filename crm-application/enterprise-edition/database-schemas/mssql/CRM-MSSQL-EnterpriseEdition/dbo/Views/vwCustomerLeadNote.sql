CREATE VIEW [dbo].[vwCustomerLeadNote]
AS

SELECT
CN.[CustomerLeadNoteId] AS [Customer Lead Note Id],
CN.[CustomerLeadNoteTitle] AS [Customer Lead Note Title],
CLNT.[CustomerLeadNoteTypeId] AS [Customer Lead Note Type Id],
CLNT.[CustomerLeadNoteType] AS [Customer Lead Note Type],
CN.[CustomerLeadNote] AS [Customer Lead Note],
CN.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CN.[CreatedBy] AS [Created By],
CN.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CN.[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerLeadNote] CN
INNER JOIN [dbo].[CustomerLeadNoteType] CLNT ON CN.[CustomerLeadNoteTypeId] = CLNT.[CustomerLeadNoteTypeId]