CREATE TABLE #tempPortalRole
(
	[portalRole] NVARCHAR(50) NOT NULL
)

INSERT INTO #tempPortalRole (portalRole) VALUES ('FTE_Allow_All')
INSERT INTO #tempPortalRole (portalRole) VALUES ('FTE_Maintenance_Only')
INSERT INTO #tempPortalRole (portalRole) VALUES ('FTE_Ticket_Sales_Only')
INSERT INTO #tempPortalRole (portalRole) VALUES ('Vendor_Suntours_Vacation_LLC_Only')
INSERT INTO #tempPortalRole (portalRole) VALUES ('Vendor_Timeless_Travel_Only')
INSERT INTO #tempPortalRole (portalRole) VALUES ('Vendor_Sunchasers_Ltd_Only')
INSERT INTO #tempPortalRole (portalRole) VALUES ('Vendor_Christopher_Columbus_Only')

MERGE INTO [dbo].[portalRole] DEST
USING #tempPortalRole SRC
ON DEST.[portalRole] = SRC.[portalRole]
WHEN NOT MATCHED BY TARGET
THEN
INSERT
(
[portalRole]
)
VALUES
(
SRC.[PortalRole]
)
;

DROP TABLE #tempPortalRole