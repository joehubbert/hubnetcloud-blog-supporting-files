CREATE TABLE #CustomerLeadNoteTypeTemp
(
	[CustomerLeadNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('General', 1)
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Initial Contact', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Follow-Up', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Client Background', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Decision Maker Info', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Pain Points', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Buying Signals', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Objections Raised', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Competitor Mentioned', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Call Summary', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Meeting Notes', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Email Summary', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Voicemail Left', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Demo Feedback', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Presentation Delivered', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Proposal Sent', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Next Steps', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Timeline', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Budget Info', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Deal Status Update', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Contract Discussion', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Waiting on Response', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Sales Strategy', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Internal Discussion', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Product Fit Assessment', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Custom Requirements', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Technical Considerations', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Risk Factors', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Legal/Compliance Concerns', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('General Note', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Personal Details', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Meeting Rescheduled', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Referral Source', 1);
INSERT INTO #CustomerLeadNoteTypeTemp ([CustomerLeadNoteType], [ActiveStatus]) VALUES ('Social Media Interaction', 1);

MERGE INTO [dbo].[CustomerLeadNoteType] AS target
USING #CustomerLeadNoteTypeTemp AS source
ON target.[CustomerLeadNoteType] = source.[CustomerLeadNoteType]
WHEN NOT MATCHED THEN
INSERT
(
	[CustomerLeadNoteType],
	[ActiveStatus]
)
VALUES 
(
	source.[CustomerLeadNoteType],
	source.[ActiveStatus]
);

DROP TABLE #CustomerLeadNoteTypeTemp