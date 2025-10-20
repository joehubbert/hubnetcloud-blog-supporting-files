CREATE TABLE #CustomerLeadNoteTypeTemp
(
	[CustomerLeadNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #CustomerLeadNoteTypeTemp 
(
	[CustomerLeadNoteType],
	[ActiveStatus]
) 
VALUES 
(
	'General',
	1
),
(
	'Initial Contact',
	1
),
(
	'Follow-Up',
	1
),
(
	'Client Background',
	1
),
(
	'Decision Maker Info',
	1
),
(
	'Pain Points',
	1
),
(
	'Buying Signals',
	1
),
(
	'Objections Raised',
	1
),
(
	'Competitor Mentioned',
	1
),
(
	'Call Summary',
	1
),
(
	'Meeting Notes',
	1
),
(
	'Email Summary',
	1
),
(
	'Voicemail Left',
	1
),
(
	'Demo Feedback',
	1
),
(
	'Presentation Delivered',
	1
),
(
	'Proposal Sent',
	1
),
(
	'Next Steps',
	1
),
(
	'Timeline',
	1
),
(
	'Budget Info',
	1
),
(
	'Deal Status Update',
	1
),
(
	'Contract Discussion',
	1
),
(
	'Waiting on Response',
	1
),
(
	'Sales Strategy',
	1
),
(
	'Internal Discussion',
	1
),
(
	'Product Fit Assessment',
	1
),
(
	'Custom Requirements',
	1
),
(
	'Technical Considerations',
	1
),
(
	'Risk Factors',
	1
),
(
	'Legal/Compliance Concerns',
	1
),
(
	'General Note',
	1
),
(
	'Personal Details',
	1
),
(
	'Meeting Rescheduled',
	1
),
(
	'Referral Source',
	1
),
(
	'Social Media Interaction',
	1
)

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