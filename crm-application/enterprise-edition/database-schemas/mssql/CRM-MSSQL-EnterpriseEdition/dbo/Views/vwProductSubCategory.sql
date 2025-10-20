CREATE VIEW [dbo].[vwProductSubCategory]

AS
SELECT
PSC.[ProductSubCategoryId] AS [Product Sub Category Id],
PSC.[ProductSubCategory] AS [Product Sub Category],
PC.[ProductCategoryId] AS [Product Category Id],
PC.[ProductCategory] AS [Product Category],
PSC.[ActiveStatus] AS [Active Status],
PSC.[CreatedTimestampUTC] AS [Created Timestamp UTC],
PSC.[CreatedBy] AS [Created By],
PSC.[ModifiedTimestampUTC] AS [Modified Timestamp UTC],
PSC.[ModifiedBy] AS [Modified By],
PSC.[RowVersion] AS [Row Version]
FROM [dbo].[ProductSubCategory] PSC
INNER JOIN [dbo].[ProductCategory] PC ON PSC.[ProductCategoryId] = PC.[ProductCategoryId]