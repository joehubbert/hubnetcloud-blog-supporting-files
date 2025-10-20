CREATE TABLE #CustomerNoteTypeTemp
(
	[CustomerNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #CustomerNoteTypeTemp 
(
	[CustomerNoteType],
	[ActiveStatus]
) 
VALUES 
(
	'General',
	1
),
(
	'Complaint',
	1
),
(
	'Compliment',
	1
),
(
	'Suggestion',
	1
)

MERGE INTO [dbo].[CustomerNoteType] AS target
USING #CustomerNoteTypeTemp AS source
ON target.[CustomerNoteType] = source.[CustomerNoteType]
WHEN NOT MATCHED THEN
INSERT
(
	[CustomerNoteType],
	[ActiveStatus]
)
VALUES 
(
	source.[CustomerNoteType],
	source.[ActiveStatus]
);

DROP TABLE #CustomerNoteTypeTemp