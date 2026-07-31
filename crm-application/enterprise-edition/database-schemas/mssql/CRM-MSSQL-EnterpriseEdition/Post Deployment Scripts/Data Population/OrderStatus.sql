CREATE TABLE #OrderStatusTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[OrderStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdOrderStatus UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdOrderStatus = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #OrderStatusTemp 
(
	[MasterDataTypeId],
	[OrderStatus],
	[ActiveStatus]
)
VALUES
(
	@builtInMasterDataTypeIdOrderStatus,
	'New', 
	1
),
(
	@builtInMasterDataTypeIdOrderStatus,
	'Pending',
	1
),
(
	@builtInMasterDataTypeIdOrderStatus,
	'Awaiting Payment',
	1
),
(
	@builtInMasterDataTypeIdOrderStatus,
	'Awaiting Shipment',
	1
),
(
	@builtInMasterDataTypeIdOrderStatus,
	'Picking from Warehouse',
	1
),
(
	@builtInMasterDataTypeIdOrderStatus,
	'In Transit',
	1
),
(
	@builtInMasterDataTypeIdOrderStatus,
	'Complete',
	1
),
(
	@builtInMasterDataTypeIdOrderStatus,
	'Cancelled',
	1
)

MERGE INTO [dbo].[OrderStatus] AS target
USING #OrderStatusTemp AS source
ON target.[OrderStatus] = source.[OrderStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[OrderStatus],
	[ActiveStatus]
) 
VALUES 
(
	source.[MasterDataTypeId],
	source.[OrderStatus],
	source.[ActiveStatus]
);

DROP TABLE #OrderStatusTemp
