CREATE TABLE #CustomerLeadTypeTemp
(
	[CustomerLeadType] NVARCHAR(50) NOT NULL,
	[CustomerLeadTypeDescription] NVARCHAR(255) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #CustomerLeadTypeTemp ([CustomerLeadType], [CustomerLeadTypeDescription], [ActiveStatus]) VALUES ('Cold', 'People or organisations who haven’t shown interest yet.', 1)
INSERT INTO #CustomerLeadTypeTemp ([CustomerLeadType], [CustomerLeadTypeDescription], [ActiveStatus]) VALUES ('Warm', 'Prospects who have shown some level of interest but aren’t ready to buy yet.', 1)
INSERT INTO #CustomerLeadTypeTemp ([CustomerLeadType], [CustomerLeadTypeDescription], [ActiveStatus]) VALUES ('Hot', 'High-intent prospects ready to engage in a sales conversation or make a purchase.', 1)
INSERT INTO #CustomerLeadTypeTemp ([CustomerLeadType], [CustomerLeadTypeDescription], [ActiveStatus]) VALUES ('Marketing Qualified', 'Leads identified by marketing as more likely to become customers based on their engagement.', 1)
INSERT INTO #CustomerLeadTypeTemp ([CustomerLeadType], [CustomerLeadTypeDescription], [ActiveStatus]) VALUES ('Sales Qualified', 'Leads that have been vetted by sales and are deemed ready for a direct sales follow-up.', 1)
INSERT INTO #CustomerLeadTypeTemp ([CustomerLeadType], [CustomerLeadTypeDescription], [ActiveStatus]) VALUES ('Product Qualified', 'Leads who have used a product (often via a free trial or freemium model) and shown intent to upgrade.', 1)
INSERT INTO #CustomerLeadTypeTemp ([CustomerLeadType], [CustomerLeadTypeDescription], [ActiveStatus]) VALUES ('Servkce Qualified', 'Existing customers or users who indicate interest in additional services or upgrades.', 1)
INSERT INTO #CustomerLeadTypeTemp ([CustomerLeadType], [CustomerLeadTypeDescription], [ActiveStatus]) VALUES ('Referral', 'Leads referred by current customers, partners, or employees.', 1)
INSERT INTO #CustomerLeadTypeTemp ([CustomerLeadType], [CustomerLeadTypeDescription], [ActiveStatus]) VALUES ('Inbound', 'Leads that come to you through your marketing efforts (SEO, content marketing, paid ads, etc.).', 1)
INSERT INTO #CustomerLeadTypeTemp ([CustomerLeadType], [CustomerLeadTypeDescription], [ActiveStatus]) VALUES ('Outbound', 'Leads sourced proactively by your team.', 1)

MERGE INTO [dbo].[CustomerLeadType] AS target
USING #CustomerLeadTypeTemp AS source
ON target.[CustomerLeadType] = source.[CustomerLeadType]
WHEN NOT MATCHED THEN
INSERT
(
	[CustomerLeadType],
	[CustomerLeadTypeDescription],
	[ActiveStatus]
)
VALUES 
(
	source.[CustomerLeadType],
	source.[CustomerLeadTypeDescription],
	source.[ActiveStatus]
);

DROP TABLE #CustomerLeadTypeTemp