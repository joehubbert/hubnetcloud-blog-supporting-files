CREATE TABLE #SupplierNoteTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[SupplierNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

DECLARE @builtInMasterDataTypeIdSupplierNoteType UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdSupplierNoteType = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #SupplierNoteTypeTemp 
(
	[MasterDataTypeId],
	[SupplierNoteType],
	[ActiveStatus]
)
VALUES
(
	@builtInMasterDataTypeIdSupplierNoteType,
	'General',
	1
),
(
	@builtInMasterDataTypeIdSupplierNoteType,
	'Quality',
	1
),
(
	@builtInMasterDataTypeIdSupplierNoteType,
	'Compliance',
	1
),
(
	@builtInMasterDataTypeIdSupplierNoteType,
	'Product',
	1
),
(
	@builtInMasterDataTypeIdSupplierNoteType,
	'Service',
	1
),
(
	@builtInMasterDataTypeIdSupplierNoteType,
	'Logistics',
	1
),
(
	@builtInMasterDataTypeIdSupplierNoteType,
	'Finance',
	1
),
(
	@builtInMasterDataTypeIdSupplierNoteType,
	'Product Offering',
	1
)

MERGE INTO [dbo].[SupplierNoteType] AS target
USING #SupplierNoteTypeTemp AS source
ON target.[SupplierNoteType] = source.[SupplierNoteType]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[SupplierNoteType],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[SupplierNoteType],
	source.[ActiveStatus]
);

DROP TABLE #SupplierNoteTypeTemp