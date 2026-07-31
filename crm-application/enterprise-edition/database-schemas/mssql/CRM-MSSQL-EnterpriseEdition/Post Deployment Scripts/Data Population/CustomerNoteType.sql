CREATE TABLE #CustomerNoteTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
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
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CustomerNoteType],
	[ActiveStatus]
)
VALUES 
(
	source.[MasterDataTypeId],
	source.[CustomerNoteType],
	source.[ActiveStatus]
);

DROP TABLE #CustomerNoteTypeTemp