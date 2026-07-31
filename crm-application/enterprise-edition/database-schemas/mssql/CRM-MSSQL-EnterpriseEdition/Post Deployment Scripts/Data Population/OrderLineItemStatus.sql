CREATE TABLE #OrderLineItemStatusTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[OrderLineItemStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdOrderLineItemStatus UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdOrderLineItemStatus = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #OrderLineItemStatusTemp
(
	[MasterDataTypeId],
	[OrderLineItemStatus],
	[ActiveStatus]
)
VALUES
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Pending',
	1
),
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Shipped',
	1
),
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Delivered',
	1
),
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Cancelled',
	1
),
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Returned',
	1
),
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Refunded',
	1
),
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Partially Shipped',
	1
),
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Partially Delivered',
	1
),
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Partially Returned',
	1
),
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Partially Refunded',
	1
),
(
	@builtInMasterDataTypeIdOrderLineItemStatus,
	'Awaiting Stock',
	1
)

MERGE INTO [dbo].[OrderLineItemStatus] AS target
USING #OrderLineItemStatusTemp AS source
ON target.[OrderLineItemStatus] = source.[OrderLineItemStatus]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[OrderLineItemStatus],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[OrderLineItemStatus],
	source.[ActiveStatus]
);

DROP TABLE #OrderLineItemStatusTemp