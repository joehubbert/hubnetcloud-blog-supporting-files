CREATE VIEW [dbo].[vwCustomerNoteType]
AS

SELECT
[CustomerNoteTypeId] AS [Customer Note Type Id],
[CustomerNoteType] AS [Customer Note Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerNoteType]