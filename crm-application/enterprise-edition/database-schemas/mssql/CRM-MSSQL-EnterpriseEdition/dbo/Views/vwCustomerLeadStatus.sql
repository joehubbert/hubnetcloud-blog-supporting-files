CREATE VIEW [dbo].[vwCustomerLeadStatus]
AS

SELECT
[CustomerLeadStatusId]	AS [Customer Lead Status Id],
[CustomerLeadStatus] AS [Customer Lead Status],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerLeadStatus]