CREATE PROCEDURE [dbo].[spCreateProductCategory]
	@productCategory NVARCHAR(50)
AS

CREATE TABLE #ProductCategoryTemp
(
	[ProductCategory] NVARCHAR(50) NOT NULL
)

INSERT INTO #ProductCategoryTemp
(
	[ProductCategory]
)
VALUES
(
	@productCategory
)

IF EXISTS
(
SELECT *
FROM [dbo].[ProductCategory] PC
INNER JOIN #ProductCategoryTemp PCT ON PC.[ProductCategory] = PCT.[ProductCategory]
WHERE PC.[ProductCategory] = PCT.[ProductCategory]
)
THROW 50000, 'Product Category already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[ProductCategory] AS target
USING #ProductCategoryTemp AS source
ON target.[ProductCategory] = source.[ProductCategory]
WHEN NOT MATCHED THEN
INSERT
(
	[ProductCategory]
)
VALUES
(
	source.[ProductCategory]
);

DROP TABLE #ProductCategoryTemp;