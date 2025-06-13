CREATE VIEW [dbo].[vwProductSubCategory]

AS
SELECT
PSC.[ProductSubCategoryId] AS [Product Sub Category Id],
PSC.[ProductSubCategory] AS [Product Sub Category],
PC.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
PSC.[ActiveStatus] AS [Active Status],
PSC.[CreatedTimestamp] AS [Created Timestamp],
PSC.[CreatedBy] AS [Created By],
PSC.[ModifiedTimestamp] AS [Modified Timestamp],
PSC.[ModifiedBy] AS [Modified By]
FROM [dbo].[ProductSubCategory] PSC
INNER JOIN [dbo].[ProductCategory] PC ON PSC.[ProductCategoryId] = PC.[ProductCategoryId]