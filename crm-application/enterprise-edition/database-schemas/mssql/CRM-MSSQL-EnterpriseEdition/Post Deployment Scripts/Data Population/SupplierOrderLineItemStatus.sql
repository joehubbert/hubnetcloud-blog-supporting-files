CREATE TABLE #SupplierOrderLineItemStatusTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[SupplierOrderLineItemStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdSupplierOrderLineItemStatus UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdSupplierOrderLineItemStatus = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #SupplierOrderLineItemStatusTemp
(
	[MasterDataTypeId],
	[SupplierOrderLineItemStatus],
	[ActiveStatus]
)
VALUES
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Pending',
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Shipped',
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Delivered',
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Cancelled',
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Returned',
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Refunded',
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Partially Shipped',
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Partially Delivered',
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Partially Returned',
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Partially Refunded',
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderLineItemStatus,
	'Awaiting Stock',
	1
)

MERGE INTO [dbo].[SupplierOrderLineItemStatus] AS target
USING #SupplierOrderLineItemStatusTemp AS source
ON target.[SupplierOrderLineItemStatus] = source.[SupplierOrderLineItemStatus]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[SupplierOrderLineItemStatus],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[SupplierOrderLineItemStatus],
	source.[ActiveStatus]
);

DROP TABLE #SupplierOrderLineItemStatusTemp
