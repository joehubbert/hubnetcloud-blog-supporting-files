CREATE TABLE #CustomerLeadStatusTemp
(
	[CustomerLeadStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('New', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Attempted Contact', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Engaged', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Qualified', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Revisit Later', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Unresponsive', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('On Hold', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Converted', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Lost', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Demo Scheduled', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Awaiting Follow-Up', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Trial Started', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Pending Approval', 1)
INSERT INTO #CustomerLeadStatusTemp ([CustomerLeadStatus], [ActiveStatus]) VALUES ('Pending Procurement', 1)

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