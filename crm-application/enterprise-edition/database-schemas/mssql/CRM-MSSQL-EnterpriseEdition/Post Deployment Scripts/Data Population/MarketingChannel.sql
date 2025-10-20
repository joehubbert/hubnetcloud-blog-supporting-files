CREATE TABLE #MarketingChannelTemp
(
	[MarketingChannel] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #MarketingChannelTemp 
(
	[MarketingChannel],
	[ActiveStatus]
)
VALUES 
(
	'Search Engine Optimisation',
	1
),
(
	'Search Engine Marketing',
	1
),
(
	'Pay-Per-Click',
	1
),
(
	'Email',
	1
),
(
	'Social Media',
	1
),
(
	'Content Marketing',
	1
),
(
	'Affiliate Marketing',
	1
),
(
	'Influencer Marketing',
	1
),
(
	'Webinar',
	1
),
(
	'Online Community',
	1
),
(
	'Company Website',
	1
),
(
	'Microsite',
	1
),
(
	'Event & Trade Show',
	1
),
(
	'Print Advertising',
	1
),
(
	'Television',
	1
),
(
	'Radio',
	1
),
(
	'Direct Mail',
	1
),
(
	'SMS',
	1
),
(
	'Account-Based Marketing',
	1
),
(
	'Company App',
	1
)

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