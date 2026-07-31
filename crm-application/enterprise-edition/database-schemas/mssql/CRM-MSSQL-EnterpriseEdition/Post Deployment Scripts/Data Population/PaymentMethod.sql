CREATE TABLE #PaymentMethodTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CompanyConfigurationId] UNIQUEIDENTIFIER NULL DEFAULT NULL,
	[PaymentMethod] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdPaymentMethod UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdPaymentMethod = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataTypeCode] = 'BUILTIN' AND [IsCustom] = 0)

INSERT INTO #PaymentMethodTemp
(
	[MasterDataTypeId],
	[PaymentMethod],
	[ActiveStatus]
)
VALUES
(
	@builtInMasterDataTypeIdPaymentMethod,
	'Cash', 
	1
),
(
	@builtInMasterDataTypeIdPaymentMethod,
	'Debit Card',
	1
),
(
	@builtInMasterDataTypeIdPaymentMethod,
	'Credit Card',
	1
),
(
	@builtInMasterDataTypeIdPaymentMethod,
	'Invoice',
	1
),
(
	@builtInMasterDataTypeIdPaymentMethod,
	'Account Credit',
	1
),
(
	@builtInMasterDataTypeIdPaymentMethod,
	'Bank Transfer',
	1
),
(
	@builtInMasterDataTypeIdPaymentMethod,
	'Vipps',
	1
)

MERGE INTO [dbo].[PaymentMethod] AS target
USING #PaymentMethodTemp AS source
ON target.[PaymentMethod] = source.[PaymentMethod]
AND (target.[CompanyConfigurationId] = source.[CompanyConfigurationId] OR (target.[CompanyConfigurationId] IS NULL AND source.[CompanyConfigurationId] IS NULL))
WHEN NOT MATCHED THEN
INSERT 
(
	[MasterDataTypeId],
	[CompanyConfigurationId],
	[PaymentMethod],
	[ActiveStatus]
) 
VALUES 
(
	source.[MasterDataTypeId],
	source.[CompanyConfigurationId],
	source.[PaymentMethod],
	source.[ActiveStatus]
);

DROP TABLE #PaymentMethodTemp
