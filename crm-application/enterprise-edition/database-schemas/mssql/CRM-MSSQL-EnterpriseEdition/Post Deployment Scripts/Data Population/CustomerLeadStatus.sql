CREATE TABLE #CustomerLeadStatusTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[CustomerLeadStatus] NVARCHAR(50) NOT NULL,
	[CustomerLeadStatusCode] NVARCHAR(20) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdCustomerLeadStatus UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdCustomerLeadStatus = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #CustomerLeadStatusTemp 
(
	[MasterDataTypeId],
	[CustomerLeadStatus],
	[CustomerLeadStatusCode],
	[ActiveStatus]
)
VALUES 
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'New',
	'NEW',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Attempted Contact',
	'ATTEMPTCONTACT',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Engaged', 
	'ENGAGED',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Qualified',
	'QUALIFIED',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Revisit Later',
	'REVISITLATER',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Unresponsive',
	'UNRESPONSIVE',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'On Hold',
	'ONHOLD',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Converted',
	'CONVERTED',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Lost',
	'LOST',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Demo Scheduled',
	'DEMOSCHEDULED',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Awaiting Follow-Up',
	'AWAITFOLLOWUP',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Trial Started',
	'TRIALSTARTED',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Pending Approval',
	'PENDINGAPPROVAL',
	1
),
(
	@builtInMasterDataTypeIdCustomerLeadStatus,
	'Pending Procurement',
	'PENDINGPROCUREMENT',
	1
)

MERGE INTO [dbo].[CustomerLeadStatus] AS target
USING #CustomerLeadStatusTemp AS source
ON target.[CustomerLeadStatus] = source.[CustomerLeadStatus]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[CustomerLeadStatus],
	[CustomerLeadStatusCode],
	[ActiveStatus]
) 
VALUES 
(
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[CustomerLeadStatus],
	source.[CustomerLeadStatusCode],
	source.[ActiveStatus]
);

DROP TABLE #CustomerLeadStatusTemp