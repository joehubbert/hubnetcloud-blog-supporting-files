CREATE VIEW [dbo].[vwCustomerLeadSummary]
AS

SELECT
CL.[CustomerId] AS [Customer Id],
CL.[CustomerLeadId] AS [Customer Lead Id],
CL.[CustomerLeadTitle] AS [Customer Lead Title],
CLT.[CustomerLeadType] AS [Customer Lead Type],
LEFT(CL.[CustomerLead],50) AS [Customer Lead],
CC.[FirstName] AS [Customer Contact First Name],
CC.[LastName] AS [Customer Contact Last Name],
CL.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CL.[CreatedBy] AS [Created By],
CL.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CL.[ModifiedBy] AS [Modified By],
CL.[RowVersion] AS [Row Version]
FROM [dbo].[CustomerLead] CL
INNER JOIN [dbo].[CustomerLeadType] CLT ON CL.[CustomerLeadTypeId] = CLT.[CustomerLeadTypeId]
LEFT JOIN [dbo].[CustomerContact] CC ON CL.[CustomerContactId] = CC.[CustomerContactId]