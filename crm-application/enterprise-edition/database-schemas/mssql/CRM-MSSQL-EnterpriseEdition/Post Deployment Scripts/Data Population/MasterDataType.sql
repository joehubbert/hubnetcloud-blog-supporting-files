CREATE TABLE #MasterDataTypeTemp
(
	[MasterDataType] NVARCHAR(50) NOT NULL,
	[MasterDataTypeCode] NVARCHAR(20) NOT NULL,
	[IsCustom] BIT NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #MasterDataTypeTemp 
(
	[MasterDataType],
	[MasterDataTypeCode],
	[IsCustom],
	[ActiveStatus]
) 
VALUES
(
	'Built-In',
	'BUILTIN',
	0,
	1
),
(
	'User Defined (Company Specific)',
	'USERCOMPANY',
	1,
	1
),
(
	'User Defined (Global)',
	'USERGLOBAL',
	1,
	1
)

MERGE INTO [dbo].[MasterDataType] AS target
USING #MasterDataTypeTemp AS source
ON target.[MasterDataType] = source.[MasterDataType]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataType],
	[MasterDataTypeCode],
	[IsCustom],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataType],
	source.[MasterDataTypeCode],
	source.[IsCustom],
	source.[ActiveStatus]
);

DROP TABLE #MasterDataTypeTemp