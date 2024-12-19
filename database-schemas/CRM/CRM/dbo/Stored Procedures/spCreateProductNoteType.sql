CREATE PROCEDURE [dbo].[spCreateProductNoteType]
	@productNoteType NVARCHAR(50)
AS

CREATE TABLE #ProductNoteTypeTemp
(
	[ProductNoteType] NVARCHAR(50) NOT NULL
)

INSERT INTO #ProductNoteTypeTemp
(
	[ProductNoteType]
)
VALUES
(
	@productNoteType
)

IF EXISTS
(
SELECT *
FROM [dbo].[ProductNoteType] CT
INNER JOIN #ProductNoteTypeTemp CTT ON CT.[ProductNoteType] = CTT.[ProductNoteType]
WHERE CT.[ProductNoteType] = CTT.[ProductNoteType]
)
THROW 50000, 'Product Note Type already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[ProductNoteType] AS target
USING #ProductNoteTypeTemp AS source
ON target.[ProductNoteType] = source.[ProductNoteType]
WHEN NOT MATCHED THEN
INSERT
(
	[ProductNoteType]
)
VALUES
(
	source.[ProductNoteType]
);

DROP TABLE #ProductNoteTypeTemp;