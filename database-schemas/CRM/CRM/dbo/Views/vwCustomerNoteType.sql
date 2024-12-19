CREATE VIEW [dbo].[vwCustomerNoteType]
AS

SELECT
[CustomerNoteTypeId] AS [Customer Note Type Id],
[CustomerNoteType] AS [Customer Note Type],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerNoteType]