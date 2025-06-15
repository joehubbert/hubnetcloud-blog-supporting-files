CREATE VIEW [dbo].[vwProductCategory]

AS
SELECT
PC.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
PC.[ActiveStatus] AS [Active Status],
PC.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PC.[CreatedBy] AS [Created By],
PC.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PC.[ModifiedBy] AS [Modified By]
FROM [dbo].[ProductCategory] PC
INNER JOIN [dbo].[CompanyConfiguration] CC ON PC.[CompanyConfigurationId] = CC.[CompanyConfigurationId]