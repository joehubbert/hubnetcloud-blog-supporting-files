CREATE VIEW [dbo].[vwCustomerLeadNoteType]
AS

SELECT
[CustomerLeadNoteTypeId] AS [Customer Lead Note Type Id],
[CustomerLeadNoteType] AS [Customer Lead Note Type],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerLeadNoteType]