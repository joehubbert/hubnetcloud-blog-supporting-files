CREATE VIEW [dbo].[vwSalesRegion]
AS

SELECT
SR.[SalesRegionId]	AS [Sales Region Id],
SR.[SalesRegion] AS [Sales Region],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Configuration Name],
SR.[ActiveStatus] AS [Active Status],
SR.[CreatedTimestamp] AS [Created Timestamp],
SR.[CreatedBy] AS [Created By],
SR.[ModifiedTimestamp] AS [Modified Timestamp],
SR.[ModifiedBy] AS [Modified By]
FROM [dbo].[SalesRegion] SR
INNER JOIN [dbo].[CompanyConfiguration] CC ON SR.[CompanyConfigurationId] = CC.[CompanyConfigurationId]