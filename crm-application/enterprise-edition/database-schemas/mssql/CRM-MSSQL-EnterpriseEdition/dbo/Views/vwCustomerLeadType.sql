CREATE VIEW [dbo].[vwCustomerLeadType]
AS

SELECT
[CustomerLeadTypeId] AS [Customer Lead Type Id],
[CustomerLeadType] AS [Customer Lead Type],
[CustomerLeadTypeDescription] AS [Customer Lead Type Description],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerLeadType]