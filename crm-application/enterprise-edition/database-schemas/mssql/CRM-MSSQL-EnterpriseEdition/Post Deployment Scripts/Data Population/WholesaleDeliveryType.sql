CREATE TABLE #WholesaleDeliveryTypeTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[WholesaleDeliveryType] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdWholesaleDeliveryType UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdWholesaleDeliveryType = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #WholesaleDeliveryTypeTemp
(
	[MasterDataTypeId],
	[WholesaleDeliveryType],
	[ActiveStatus]
)
VALUES
(
	@builtInMasterDataTypeIdWholesaleDeliveryType,
	'Carton',
	1
),
(
	@builtInMasterDataTypeIdWholesaleDeliveryType,
	'Pallet - Carton',
	1
),
(
	@builtInMasterDataTypeIdWholesaleDeliveryType,
	'Pallet - Unit',
	1
)

MERGE INTO [dbo].[WholesaleDeliveryType] AS target
USING #WholesaleDeliveryTypeTemp AS source
ON target.[WholesaleDeliveryType] = source.[WholesaleDeliveryType]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[WholesaleDeliveryType],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataTypeId],
	source.[WholesaleDeliveryType],
	source.[ActiveStatus]
);

DROP TABLE #WholesaleDeliveryTypeTemp
