CREATE VIEW [dbo].[vwCustomerLeadType]
AS

SELECT
[CustomerLeadTypeId] AS [Customer Lead Type Id],
[CustomerLeadType] AS [Customer Lead Type],
[CustomerLeadTypeDescription] AS [Customer Lead Type Description],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerLeadType]