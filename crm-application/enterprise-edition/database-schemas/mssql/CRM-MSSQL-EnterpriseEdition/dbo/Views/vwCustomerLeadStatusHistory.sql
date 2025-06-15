CREATE VIEW [dbo].[vwCustomerLeadStatusHistory]
AS

SELECT
CLSH.[CustomerLeadStatusHistoryId] AS [Customer Lead Status History Id],
CLSH.[CustomerLeadId] AS [Customer Lead Id],
CLS.[CustomerLeadStatusId] AS [Customer Lead Status Id],
CLS.[CustomerLeadStatus] AS [Customer Lead Status],
CLSH.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CLSH.[CreatedBy] AS [Created By],
CLSH.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CLSH.[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerLeadStatusHistory] CLSH
INNER JOIN [dbo].[CustomerLeadStatus] CLS ON CLSH.[CustomerLeadStatusId] = CLS.[CustomerLeadStatusId]