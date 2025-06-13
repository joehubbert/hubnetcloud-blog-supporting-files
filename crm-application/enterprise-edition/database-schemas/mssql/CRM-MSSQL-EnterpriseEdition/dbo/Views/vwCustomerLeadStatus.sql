CREATE VIEW [dbo].[vwCustomerLeadStatus]
AS

SELECT
[CustomerLeadStatusId]	AS [Customer Lead Status Id],
[CustomerLeadStatus] AS [Customer Lead Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerLeadStatus]