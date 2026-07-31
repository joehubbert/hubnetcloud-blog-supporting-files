CREATE TABLE #OrderPaymentStatusTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[OrderPaymentStatus] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdOrderPaymentStatus UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdOrderPaymentStatus = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #OrderPaymentStatusTemp
(
	[MasterDataTypeId],
	[OrderPaymentStatus],
	[ActiveStatus]
) 
VALUES 
(
	@builtInMasterDataTypeIdOrderPaymentStatus,
	'Settled', 
	1
),
(
	@builtInMasterDataTypeIdOrderPaymentStatus,
	'Partially Settled', 
	1
),
(
	@builtInMasterDataTypeIdOrderPaymentStatus,
	'Unsettled', 
	1
),
(
	@builtInMasterDataTypeIdOrderPaymentStatus,
	'Refunded', 
	1
),
(
	@builtInMasterDataTypeIdOrderPaymentStatus,
	'Pending Payment', 
	1
),
(
	@builtInMasterDataTypeIdOrderPaymentStatus,
	'Chargeback', 
	1
)

MERGE INTO [dbo].[OrderPaymentStatus] AS target
USING #OrderPaymentStatusTemp AS source
ON target.[OrderPaymentStatus] = source.[OrderPaymentStatus]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[OrderPaymentStatus],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[OrderPaymentStatus],
	source.[ActiveStatus]
);

DROP TABLE #OrderPaymentStatusTemp
