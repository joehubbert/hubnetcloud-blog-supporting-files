CREATE PROCEDURE [dbo].[spCreateCustomerNoteType]
	@customerNoteType NVARCHAR(50)
AS

CREATE TABLE #CustomerNoteTypeTemp
(
	[CustomerNoteType] NVARCHAR(50) NOT NULL
)

INSERT INTO #CustomerNoteTypeTemp
(
	[CustomerNoteType]
)
VALUES
(
	@customerNoteType
)

IF EXISTS
(
SELECT *
FROM [dbo].[CustomerNoteType] CT
INNER JOIN #CustomerNoteTypeTemp CTT ON CT.[CustomerNoteType] = CTT.[CustomerNoteType]
WHERE CT.[CustomerNoteType] = CTT.[CustomerNoteType]
)
THROW 50000, 'Customer Note Type already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[CustomerNoteType] AS target
USING #CustomerNoteTypeTemp AS source
ON target.[CustomerNoteType] = source.[CustomerNoteType]
WHEN NOT MATCHED THEN
INSERT
(
	[CustomerNoteType]
)
VALUES
(
	source.[CustomerNoteType]
);

DROP TABLE #CustomerNoteTypeTemp;