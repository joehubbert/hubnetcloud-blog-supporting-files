CREATE VIEW [dbo].[vwProductCategory]

AS
SELECT
PC.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
CC.[CompanyConfigurationId] AS [Company Configuration Id],
CC.[CompanyName] AS [Company Name],
PC.[ActiveStatus] AS [Active Status],
PC.[CreatedTimestamp] AS [Created Timestamp],
PC.[CreatedBy] AS [Created By],
PC.[ModifiedTimestamp] AS [Modified Timestamp],
PC.[ModifiedBy] AS [Modified By]
FROM [dbo].[ProductCategory] PC
INNER JOIN [dbo].[CompanyConfiguration] CC ON PC.[CompanyConfigurationId] = CC.[CompanyConfigurationId]