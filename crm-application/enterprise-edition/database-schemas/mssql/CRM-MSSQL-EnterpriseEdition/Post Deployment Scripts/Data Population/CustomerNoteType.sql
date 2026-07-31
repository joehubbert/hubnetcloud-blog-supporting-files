CREATE TABLE #CustomerNoteTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[CustomerNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

DECLARE @builtInMasterDataTypeIdCustomerNoteType UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdCustomerNoteType = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #CustomerNoteTypeTemp 
(
	[MasterDataTypeId],
	[CustomerNoteType],
	[ActiveStatus]
) 
VALUES 
(
	@builtInMasterDataTypeIdCustomerNoteType,
	'General',
	1
),
(
	@builtInMasterDataTypeIdCustomerNoteType,
	'Complaint',
	1
),
(
	@builtInMasterDataTypeIdCustomerNoteType,
	'Compliment',
	1
),
(
	@builtInMasterDataTypeIdCustomerNoteType,
	'Suggestion',
	1
)

MERGE INTO [dbo].[CustomerNoteType] AS target
USING #CustomerNoteTypeTemp AS source
ON target.[CustomerNoteType] = source.[CustomerNoteType]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[CustomerNoteType],
	[ActiveStatus]
)
VALUES 
(
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[CustomerNoteType],
	source.[ActiveStatus]
);

DROP TABLE #CustomerNoteTypeTemp