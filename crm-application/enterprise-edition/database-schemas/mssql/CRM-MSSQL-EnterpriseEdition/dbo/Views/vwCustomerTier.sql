CREATE VIEW [dbo].[vwCustomerTier]
AS

SELECT
CT.[CustomerTierId] AS [Customer Tier Id],
CT.[CustomerTierCode] AS [Customer Tier Code],
CT.[CustomerTierDescription] AS [Customer Tier Description],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
CT.[ActiveStatus] AS [Active Status],
CT.[CreatedTimestampUTC] AS [Created Timestamp UTC],
CT.[CreatedBy] AS [Created By],
CT.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
CT.[ModifiedBy] AS [Modified By],
CT.[RowVersion] AS [Row Version]
FROM [dbo].[CustomerTier] CT
INNER JOIN [dbo].[CompanyConfiguration] CC ON CT.[CompanyConfigurationId] = CC.[CompanyConfigurationId]