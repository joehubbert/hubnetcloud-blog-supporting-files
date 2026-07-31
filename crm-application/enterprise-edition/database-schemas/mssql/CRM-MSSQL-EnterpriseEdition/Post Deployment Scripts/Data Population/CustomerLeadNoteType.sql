CREATE TABLE #CustomerLeadNoteTypeTemp
(
	[CustomerLeadNoteType] NVARCHAR(50) NOT NULL,
	[CustomerLeadNoteTypeCode] NVARCHAR(20) NOT NULL,
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdCustomerLeadNoteType UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdCustomerLeadNoteType = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #CustomerLeadNoteTypeTemp 
(
	[CustomerLeadNoteType],
	[CustomerLeadNoteTypeCode],
	[MasterDataTypeId],
	[ActiveStatus]
) 
VALUES 
(
	'General',
	'GENERAL',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Initial Contact',
	'INITIALCONTACT',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Follow-Up',
	'FOLLOWUP',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Client Background',
	'CLIENTBACKGROUND',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Decision Maker Info',
	'DECISIONMAKER',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Pain Points',
	'PAINPOINT',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Buying Signals',
	'BUYINGSIGNAL',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Objections Raised',
	'OBJECTIONRAISED',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Competitor Mentioned',
	'COMPETITORRISK',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Call Summary',
	'CALLSUMMARY',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Meeting Notes',
	'MEETINGNOTES',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Email Summary',
	'EMAILSUMMARY',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Voicemail Left',
	'VOICEMAILLEFT',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Demo Feedback',
	'DEMOFEEDBACK',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Presentation Delivered',
	'PRESENTATIONDEL',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Proposal Sent',
	'PROPOSALSENT',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Next Steps',
	'NEXTSTEPS',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Timeline',
	'TIMELINE',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Budget Info',
	'BUDGETINFO',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Deal Status Update',
	'DEALSTATUSUPDATE',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Contract Discussion',
	'CONTRACTDISCUSSION',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Waiting on Response',
	'WAITINGONRESPONSE',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Sales Strategy',
	'SALESSTRATEGY',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Internal Discussion',
	'INTERNALDISCUSSION',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Product Fit Assessment',
	'PRODUCTFITASSEMT',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Custom Requirements',
	'CUSTOMREQS',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Technical Considerations',
	'TECHCONSIDERATIONS',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Risk Factors',
	'RISKFACTORS',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Legal/Compliance Concerns',
	'LEGALCOMPLIANCE',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Personal Details',
	'PERSONALDETAILS',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Meeting Rescheduled',
	'MEETINGRESCHEDULED',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Referral Source',
	'REFERRALSOURCE',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
),
(
	'Social Media Interaction',
	'SOCIALMEDIAINTERACT',
	@builtInMasterDataTypeIdCustomerLeadNoteType,
	1
)

MERGE INTO [dbo].[CustomerLeadNoteType] AS target
USING #CustomerLeadNoteTypeTemp AS source
ON target.[CustomerLeadNoteType] = source.[CustomerLeadNoteType]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT
(
	[CustomerLeadNoteType],
	[CustomerLeadNoteTypeCode],
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[ActiveStatus]
)
VALUES 
(
	source.[CustomerLeadNoteType],
	source.[CustomerLeadNoteTypeCode],
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[ActiveStatus]
);

DROP TABLE #CustomerLeadNoteTypeTemp