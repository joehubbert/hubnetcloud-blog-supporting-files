CREATE TABLE #SupplierOrderPaymentStatusTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[SupplierOrderPaymentStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdSupplierOrderPaymentStatus UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdSupplierOrderPaymentStatus = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #SupplierOrderPaymentStatusTemp 
(
	[MasterDataTypeId],
	[SupplierOrderPaymentStatus],
	[ActiveStatus]
)
VALUES
(
	@builtInMasterDataTypeIdSupplierOrderPaymentStatus,
	'Settled', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderPaymentStatus,
	'Partially Settled', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderPaymentStatus,
	'Unsettled', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderPaymentStatus,
	'Refunded', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderPaymentStatus,
	'Pending Payment', 
	1
),
(
	@builtInMasterDataTypeIdSupplierOrderPaymentStatus,
	'Chargeback', 
	1
)

MERGE INTO [dbo].[SupplierOrderPaymentStatus] AS target
USING #SupplierOrderPaymentStatusTemp AS source
ON target.[SupplierOrderPaymentStatus] = source.[SupplierOrderPaymentStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[SupplierOrderPaymentStatus],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataTypeId],
	source.[SupplierOrderPaymentStatus],
	source.[ActiveStatus]
);

DROP TABLE #SupplierOrderPaymentStatusTemp
