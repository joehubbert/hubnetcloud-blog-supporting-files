CREATE PROCEDURE [dbo].[spCreateProductCategory]
	@activeStatus BIT,
	@productCategory NVARCHAR(50)
AS

CREATE TABLE #ProductCategoryTemp
(
	[ProductCategory] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #ProductCategoryTemp
(
	[ProductCategory],
	[ActiveStatus]
)
VALUES
(
	@productCategory,
	@activeStatus
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
	[ProductCategory],
	[ActiveStatus]
)
VALUES
(
	source.[ProductCategory],
	source.[ActiveStatus]
);

DROP TABLE #ProductCategoryTemp;