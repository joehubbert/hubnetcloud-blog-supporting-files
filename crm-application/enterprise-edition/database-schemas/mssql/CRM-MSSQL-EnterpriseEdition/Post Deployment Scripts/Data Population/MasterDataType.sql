CREATE TABLE #MasterDataTypeTemp
(
	[MasterDataType] NVARCHAR(50) NOT NULL,
	[SystemDefined] BIT NOT NULL,
	[UserDefined] BIT NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #MasterDataTypeTemp 
(
	[MasterDataType],
	[SystemDefined],
	[UserDefined],
	[ActiveStatus]
) 
VALUES
(
	'Built-In',
	1,
	0,
	1
),
(
	'User Defined (Company Specific)',
	0,
	1,
	1
),
(
	'User Defined (Global)',
	0,
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
	[SystemDefined],
	[UserDefined],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataType],
	source.[SystemDefined],
	source.[UserDefined],
	source.[ActiveStatus]
);

DROP TABLE #MasterDataTypeTemp