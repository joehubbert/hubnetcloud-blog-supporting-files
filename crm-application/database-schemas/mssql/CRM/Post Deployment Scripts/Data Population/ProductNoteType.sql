CREATE TABLE #ProductNoteTypeTemp
(
	[ProductNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #ProductNoteTypeTemp ([ProductNoteType], [ActiveStatus]) VALUES ('General', 1)
INSERT INTO #ProductNoteTypeTemp ([ProductNoteType], [ActiveStatus]) VALUES ('Warranty', 1)
INSERT INTO #ProductNoteTypeTemp ([ProductNoteType], [ActiveStatus]) VALUES ('Recall', 1)
INSERT INTO #ProductNoteTypeTemp ([ProductNoteType], [ActiveStatus]) VALUES ('Product Development', 1)
INSERT INTO #ProductNoteTypeTemp ([ProductNoteType], [ActiveStatus]) VALUES ('Product Improvement', 1)
INSERT INTO #ProductNoteTypeTemp ([ProductNoteType], [ActiveStatus]) VALUES ('Product Issue', 1)

MERGE INTO [dbo].[ProductNoteType] AS target
USING #ProductNoteTypeTemp AS source
ON target.[ProductNoteType] = source.[ProductNoteType]
WHEN NOT MATCHED THEN
INSERT
(
	[ProductNoteType],
	[ActiveStatus]
)
VALUES
(
	source.[ProductNoteType],
	source.[ActiveStatus]
);

DROP TABLE #ProductNoteTypeTemp;