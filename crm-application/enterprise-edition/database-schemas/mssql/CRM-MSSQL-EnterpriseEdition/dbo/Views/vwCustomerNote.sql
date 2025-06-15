CREATE VIEW [dbo].[vwCustomerNote]
AS
SELECT
CN.[CustomerNoteId] AS [Customer Note Id],
CN.[CustomerNoteTitle] AS [Customer Note Title],
CNT.[CustomerNoteTypeId] AS [Customer Note Type Id],
CNT.[CustomerNoteType] AS [Customer Note Type],
CN.[CustomerNote] AS [Customer Note],
CN.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CN.[CreatedBy] AS [Created By],
CN.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CN.[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerNote] CN
INNER JOIN [dbo].[CustomerNoteType] CNT ON CN.[CustomerNoteTypeId] = CNT.[CustomerNoteTypeId]