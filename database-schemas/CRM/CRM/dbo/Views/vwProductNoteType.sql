CREATE VIEW [dbo].[vwProductNoteType]
AS

SELECT
[ProductNoteTypeId] AS [Product Note Type Id],
[ProductNoteType] AS [Product Note Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[ProductNoteType]