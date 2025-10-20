CREATE TABLE #ProductNoteTypeTemp
(
	[ProductNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #ProductNoteTypeTemp 
(
	[ProductNoteType],
	[ActiveStatus]
)
VALUES
(
	'General', 
	1
),
(
	'Specification', 
	1
),
(
	'Installation', 
	1
),
(
	'Maintenance', 
	1
),
(
	'Safety', 
	1
),
(
	'Compliance', 
	1
),
(
	'Usage', 
	1
),
(
	'Troubleshooting', 
	1
),
(
	'FAQ', 
	1
),
(
	'Warranty', 
	1
),
(
	'Recall', 
	1
),
(
	'Product Development', 
	1
),
(
	'Product Improvement', 
	1
),
(
	'Product Issue', 
	1
)

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

DROP TABLE #ProductNoteTypeTemp