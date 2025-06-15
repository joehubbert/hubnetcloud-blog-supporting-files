CREATE VIEW [dbo].[vwCustomerNoteSummary]
AS

SELECT
CN.[CustomerId] AS [Customer Id],
CN.[CustomerNoteId] AS [Customer Note Id],
CN.[CustomerNoteTitle] AS [Customer Note Title],
CNT.[CustomerNoteType] AS [Customer Note Type],
LEFT(CN.[CustomerNote],50) AS [Customer Note],
CN.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CN.[CreatedBy] AS [Created By],
CN.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CN.[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerNote] CN
INNER JOIN [dbo].[CustomerNoteType] CNT ON CN.[CustomerNoteTypeId] = CNT.[CustomerNoteTypeId]