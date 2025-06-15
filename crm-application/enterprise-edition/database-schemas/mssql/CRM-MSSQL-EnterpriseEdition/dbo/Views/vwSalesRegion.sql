CREATE VIEW [dbo].[vwSalesRegion]
AS

SELECT
SR.[SalesRegionId]	AS [Sales Region Id],
SR.[SalesRegion] AS [Sales Region],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
SR.[ActiveStatus] AS [Active Status],
SR.[CreatedTimestampUTC] AS [Created Timestamp UTC],
SR.[CreatedBy] AS [Created By],
SR.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
SR.[ModifiedBy] AS [Modified By]
FROM [dbo].[SalesRegion] SR
INNER JOIN [dbo].[CompanyConfiguration] CC ON SR.[CompanyConfigurationId] = CC.[CompanyConfigurationId]