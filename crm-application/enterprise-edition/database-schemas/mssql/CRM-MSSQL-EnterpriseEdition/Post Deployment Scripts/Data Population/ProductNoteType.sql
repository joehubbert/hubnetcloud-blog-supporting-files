CREATE TABLE #ProductNoteTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[ProductNoteType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

DECLARE @builtInMasterDataTypeIdProductNoteType UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdProductNoteType = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #ProductNoteTypeTemp 
(
	[MasterDataTypeId],
	[ProductNoteType],
	[ActiveStatus]
)
VALUES
(
	@builtInMasterDataTypeIdProductNoteType,
	'General', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Specification', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Installation', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Maintenance', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Safety', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Compliance', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Usage', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Troubleshooting', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'FAQ', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Warranty', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Recall', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Product Development', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Product Improvement', 
	1
),
(
	@builtInMasterDataTypeIdProductNoteType,
	'Product Issue', 
	1
)

MERGE INTO [dbo].[ProductNoteType] AS target
USING #ProductNoteTypeTemp AS source
ON target.[ProductNoteType] = source.[ProductNoteType]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[ProductNoteType],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataTypeId],
	source.[ProductNoteType],
	source.[ActiveStatus]
);

DROP TABLE #ProductNoteTypeTemp