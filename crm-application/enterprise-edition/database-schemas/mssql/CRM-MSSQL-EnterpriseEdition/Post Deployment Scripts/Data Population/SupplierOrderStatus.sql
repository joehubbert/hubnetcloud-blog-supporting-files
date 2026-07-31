CREATE TABLE #SupplierOrderStatusTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierOrderStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdSupplierOrderStatus UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdSupplierOrderStatus = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #SupplierOrderStatusTemp 
(
	[MasterDataTypeId],
	[SupplierOrderStatus],
	[ActiveStatus]
)
VALUES 
(
	@builtInMasterDataTypeIdSupplierOrderStatus,
	'New', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderStatus,
	'Pending', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderStatus,
	'Awaiting Payment', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderStatus,
	'Awaiting Shipment', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderStatus,
	'Picking from Warehouse', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderStatus,
	'In Transit', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderStatus,
	'Complete', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderStatus,
	'Cancelled', 
	1
)

MERGE INTO [dbo].[SupplierOrderStatus] AS target
USING #SupplierOrderStatusTemp AS source
ON target.[SupplierOrderStatus] = source.[SupplierOrderStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[SupplierOrderStatus],
	[ActiveStatus]
) 
VALUES 
(
	source.[MasterDataTypeId],
	source.[SupplierOrderStatus],
	source.[ActiveStatus]
);

DROP TABLE #SupplierOrderStatusTemp
