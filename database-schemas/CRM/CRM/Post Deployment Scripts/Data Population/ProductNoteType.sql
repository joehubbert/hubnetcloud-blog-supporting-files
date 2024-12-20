CREATE TABLE #ProductNoteTypeTemp
(
	[ProductNoteType] NVARCHAR(50) NOT NULL
)

INSERT INTO #ProductNoteTypeTemp ([ProductNoteType]) VALUES ('General')
INSERT INTO #ProductNoteTypeTemp ([ProductNoteType]) VALUES ('Warranty')
INSERT INTO #ProductNoteTypeTemp ([ProductNoteType]) VALUES ('Recall')
INSERT INTO #ProductNoteTypeTemp ([ProductNoteType]) VALUES ('Product Development')
INSERT INTO #ProductNoteTypeTemp ([ProductNoteType]) VALUES ('Product Improvement')
INSERT INTO #ProductNoteTypeTemp ([ProductNoteType]) VALUES ('Product Issue')

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