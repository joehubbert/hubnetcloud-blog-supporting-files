CREATE TABLE #CustomerLeadStatusTemp
(
	[CustomerLeadStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #CustomerLeadStatusTemp 
(
	[CustomerLeadStatus],
	[ActiveStatus]
)
VALUES 
(
	'New',
	1
),
(
	'Attempted Contact', 
	1
),
(
	'Engaged', 
	1
),
(
	'Qualified', 
	1
),
(
	'Revisit Later',
	1
),
(
	'Unresponsive',
	1
),
(
	'On Hold',
	1
),
(
	'Converted',
	1
),
(
	'Lost',
	1
),
(
	'Demo Scheduled',
	1
),
(
	'Awaiting Follow-Up',
	1
),
(
	'Trial Started',
	1
),
(
	'Pending Approval',
	1
),
(
	'Pending Procurement',
	1
)

MERGE INTO [dbo].[CustomerLeadStatus] AS target
USING #CustomerLeadStatusTemp AS source
ON target.[CustomerLeadStatus] = source.[CustomerLeadStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[CustomerLeadStatus],
	[ActiveStatus]
) 
VALUES 
(
	source.[CustomerLeadStatus],
	source.[ActiveStatus]
);

DROP TABLE #CustomerLeadStatusTemp