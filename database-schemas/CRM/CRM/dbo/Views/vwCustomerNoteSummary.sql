CREATE VIEW [dbo].[vwCustomerNoteSummary]
AS

SELECT
CN.[CustomerId] AS [Customer Id],
CN.[CustomerNoteId] AS [Customer Note Id],
CN.[CustomerNoteTitle] AS [Customer Note Title],
CNT.[CustomerNoteType] AS [Customer Note Type],
LEFT(CN.[CustomerNote],50) AS [Customer Note],
CN.[CreatedTimestamp] AS [Created Timestamp],
CN.[CreatedBy] AS [Created By],
CN.[ModifiedTimestamp] AS [Modified Timestamp],
CN.[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerNote] CN
INNER JOIN [dbo].[CustomerNoteType] CNT ON CN.[CustomerNoteTypeId] = CNT.[CustomerNoteTypeId]