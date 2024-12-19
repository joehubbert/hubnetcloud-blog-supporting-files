CREATE VIEW [dbo].[vwCustomerType]
AS

SELECT
[CustomerTypeId] AS [Customer Type Id],
[CustomerType] AS [Customer Type],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[CustomerType]