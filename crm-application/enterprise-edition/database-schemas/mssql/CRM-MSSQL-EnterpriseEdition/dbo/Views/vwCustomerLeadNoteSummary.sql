CREATE VIEW [dbo].[vwCustomerLeadNoteSummary]
AS

SELECT
CL.[CustomerId] AS [Customer Id],
CL.[CustomerLeadId] AS [Customer Lead Id],
CLN.[CustomerLeadNoteId] AS [Customer Lead Note Id],
CLN.[CustomerLeadNoteTitle] AS [Customer Lead Note Title],
CLNT.[CustomerLeadNoteType] AS [Customer Lead Note Type],
LEFT(CLN.[CustomerLeadNote],50) AS [Customer Lead Note],
CLN.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CLN.[CreatedBy] AS [Created By],
CLN.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CLN.[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerLeadNote] CLN
INNER JOIN [dbo].[CustomerLeadNoteType] CLNT ON CLN.[CustomerLeadNoteTypeId] = CLNT.[CustomerLeadNoteTypeId]
INNER JOIN [dbo].[CustomerLead] CL ON CLN.[CustomerLeadId] = CL.[CustomerLeadId]