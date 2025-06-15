CREATE VIEW [dbo].[vwProductNoteType]
AS

SELECT
[ProductNoteTypeId] AS [Product Note Type Id],
[ProductNoteType] AS [Product Note Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[ProductNoteType]