CREATE VIEW [dbo].[vwCustomerLead]
AS

SELECT
C.[CustomerId] AS [Customer Id],
CC.[CustomerContactId] AS [Customer Contact Id],
CC.[FirstName] AS [Customer Contact First Name],
CC.[LastName] AS [Customer Contact Last Name],
CL.[CustomerLeadId] AS [Customer Lead Id],
CL.[CustomerLeadTitle] AS [Customer Lead Title],
CLT.[CustomerLeadTypeId] AS [Customer Lead Type Id],
CLT.[CustomerLeadType] AS [Customer Lead Type],
CL.[CustomerLead] AS [Customer Lead],
CL.[CustomerLeadTargetDate] AS [Customer Lead Target Date],
MC.[MarketingChannelId] AS [Marketing Channel Id],
MC.[MarketingChannel] AS [Marketing Channel],
CL.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CL.[CreatedBy] AS [Created By],
CL.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CL.[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerLead] CL
INNER JOIN [dbo].[CustomerLeadType] CLT ON CL.[CustomerLeadTypeId] = CLT.[CustomerLeadTypeId]
INNER JOIN [dbo].[Customer] C ON CL.[CustomerId] = C.[CustomerId]
LEFT JOIN [dbo].[CustomerContact] CC ON CL.[CustomerContactId] = CC.[CustomerContactId]
LEFT JOIN [dbo].[MarketingChannel] MC ON CL.[CustomerLeadMarketingChannelId] = MC.[MarketingChannelId]