CREATE VIEW [dbo].[vwTaxProfile]
AS

SELECT
[TaxProfileId] AS [Tax Profile Id],
[TaxProfile] AS [Tax Profile],
[TaxRate] AS [Tax Rate],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[TaxProfile]