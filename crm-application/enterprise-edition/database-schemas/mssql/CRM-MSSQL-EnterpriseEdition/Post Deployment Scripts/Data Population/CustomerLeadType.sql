CREATE TABLE #CustomerLeadTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CustomerLeadType] NVARCHAR(50) NOT NULL,
	[CustomerLeadTypeCode] NVARCHAR(20) NOT NULL,
	[CustomerLeadTypeDescription] NVARCHAR(255) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

DECLARE @builtInMasterDataTypeIdCustomerLeadType UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdCustomerLeadType = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #CustomerLeadTypeTemp
(
	[MasterDataTypeId],
	[CustomerLeadType],
	[CustomerLeadTypeCode],
	[CustomerLeadTypeDescription],
	[ActiveStatus]
)
VALUES 
(
	@builtInMasterDataTypeIdCustomerLeadType,
	'Cold',
	'COLD',
	'People or organisations who haven’t shown interest yet.', 
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadType,
	'Warm', 
	'WARM',
	'Prospects who have shown some level of interest but aren’t ready to buy yet.',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadType,
	'Hot',
	'HOT',
	'High-intent prospects ready to engage in a sales conversation or make a purchase.', 
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadType,
	'Marketing Qualified',
	'MARKETINGQUALIFIED',
	'Leads identified by marketing as more likely to become customers based on their engagement.',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadType,
	'Sales Qualified',
	'SALESQUALIFIED',
	'Leads that have been vetted by sales and are deemed ready for a direct sales follow-up.',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadType,
	'Product Qualified',
	'PRODUCTQUALIFIED',
	'Leads who have used a product (often via a free trial or freemium model) and shown intent to upgrade.',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadType,
	'Service Qualified',
	'SERVICEQUALIFIED',
	'Existing customers or users who indicate interest in additional services or upgrades.',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadType,
	'Referral',
	'REFERRAL',
	'Leads referred by current customers, partners, or employees.',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadType,
	'Inbound',
	'INBOUND',
	'Leads that come to you through marketing efforts (SEO, content marketing, paid ads, etc.).',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadType,
	'Outbound',
	'OUTBOUND',
	'Leads sourced proactively by internal team.',
	1
)

MERGE INTO [dbo].[CustomerLeadType] AS target
USING #CustomerLeadTypeTemp AS source
ON target.[CustomerLeadType] = source.[CustomerLeadType]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CustomerLeadType],
	[CustomerLeadTypeCode],
	[CustomerLeadTypeDescription],
	[ActiveStatus]
)
VALUES 
(
	source.[MasterDataTypeId],
	source.[CustomerLeadType],
	source.[CustomerLeadTypeCode],
	source.[CustomerLeadTypeDescription],
	source.[ActiveStatus]
);

DROP TABLE #CustomerLeadTypeTemp