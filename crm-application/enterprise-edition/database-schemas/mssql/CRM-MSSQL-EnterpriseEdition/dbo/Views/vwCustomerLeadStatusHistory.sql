CREATE VIEW [dbo].[vwCustomerLeadStatusHistory]
AS

SELECT
CLSH.[CustomerLeadStatusHistoryId] AS [Customer Lead Status History Id],
CLSH.[CustomerLeadId] AS [Customer Lead Id],
CLS.[CustomerLeadStatusId] AS [Customer Lead Status Id],
CLS.[CustomerLeadStatus] AS [Customer Lead Status],
CLSH.[CreatedTimestamp] AS [Created Timestamp],
CLSH.[CreatedBy] AS [Created By],
CLSH.[ModifiedTimestamp] AS [Modified Timestamp],
CLSH.[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerLeadStatusHistory] CLSH
INNER JOIN [dbo].[CustomerLeadStatus] CLS ON CLSH.[CustomerLeadStatusId] = CLS.[CustomerLeadStatusId]