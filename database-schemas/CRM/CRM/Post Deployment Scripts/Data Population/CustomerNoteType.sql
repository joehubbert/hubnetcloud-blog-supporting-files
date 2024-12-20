CREATE TABLE #CustomerNoteTypeTemp
(
	[CustomerNoteType] NVARCHAR(50) NOT NULL
)

INSERT INTO #CustomerNoteTypeTemp ([CustomerNoteType]) VALUES ('General')
INSERT INTO #CustomerNoteTypeTemp ([CustomerNoteType]) VALUES ('Complaint')
INSERT INTO #CustomerNoteTypeTemp ([CustomerNoteType]) VALUES ('Compliment')
INSERT INTO #CustomerNoteTypeTemp ([CustomerNoteType]) VALUES ('Suggestion')

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