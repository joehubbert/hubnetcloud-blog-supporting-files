CREATE TABLE #MarketingChannelTemp
(
	[MarketingChannel] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Search Engine Optimisation', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Search Engine Marketing', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Pay-Per-Click', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Email', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Social Media', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Content Marketing', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Affiliate Marketing', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Influencer Marketing', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Webinar', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Online Community', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Company Website', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Microsite', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Event & Trade Show', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Print Advertising', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Television', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Radio', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Direct Mail', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('SMS', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Account-Based Marketing', 1)
INSERT INTO #MarketingChannelTemp ([MarketingChannel], [ActiveStatus]) VALUES ('Company App', 1)

MERGE INTO [dbo].[MarketingChannel] AS target
USING #MarketingChannelTemp AS source
ON target.[MarketingChannel] = source.[MarketingChannel]
WHEN NOT MATCHED THEN
INSERT
(
	[MarketingChannel],
	[ActiveStatus]
) 
VALUES 
(
	source.[MarketingChannel],
	source.[ActiveStatus]
);

DROP TABLE #MarketingChannelTemp