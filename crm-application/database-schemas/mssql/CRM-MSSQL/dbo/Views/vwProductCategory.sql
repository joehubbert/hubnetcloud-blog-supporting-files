CREATE VIEW [dbo].[vwProductCategory]

AS
SELECT
[ProductCategoryId] AS [Product Category Id],
[ProductCategory] AS [Product Category],
[ActiveStatus] AS [Active Status],
[CreatedTimestamp] AS [Created Timestamp],
[CreatedBy] AS [Created By],
[ModifiedTimestamp] AS [Modified Timestamp],
[ModifiedBy] AS [Modified By]
FROM [dbo].[ProductCategory]