CREATE VIEW [dbo].[vwTaxProfile]
AS

SELECT
[TaxProfileId] AS [Tax Profile Id],
[TaxProfile] AS [Tax Profile],
[TaxRate] AS [Tax Rate],
[ActiveStatus] AS [Active Status],
[CreatedTimestampUTC] AS [Created Timestamp UTC],
[CreatedBy] AS [Created By],
[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
[ModifiedBy] AS [Modified By],
[RowVersion] AS [Row Version]
FROM [dbo].[TaxProfile]