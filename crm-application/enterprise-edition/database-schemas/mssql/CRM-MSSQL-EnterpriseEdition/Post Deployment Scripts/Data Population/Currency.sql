CREATE TABLE #CurrencyTemp
(
	[MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
	[CurrencyCode] NCHAR(3) NOT NULL,
	[CurrencyName] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

-- Declare Built-In Master Data Type
DECLARE @builtInMasterDataTypeIdCurrency UNIQUEIDENTIFIER
SET @builtInMasterDataTypeIdCurrency = (SELECT [MasterDataTypeId] FROM [dbo].[MasterDataType] WHERE [MasterDataType] = 'Built-In' AND [SystemDefined] = 1)

INSERT INTO #CurrencyTemp
(
	[MasterDataTypeId],
	[CurrencyCode],
	[CurrencyName],
	[ActiveStatus]
) 
VALUES 
(
	@builtInMasterDataTypeIdCurrency,
	'USD',
	'United States Dollar', 
	1
),
(
	@builtInMasterDataTypeIdCurrency,
	'EUR',
	'Euro',
	1
),
(
	@builtInMasterDataTypeIdCurrency,
	'GBP',
	'Pound Sterling',
	1
),
(
	@builtInMasterDataTypeIdCurrency,
	'DKK',
	'Danish Kroner',
	1
),
(
	@builtInMasterDataTypeIdCurrency,
	'SEK',
	'Swedish Kroner',
	1
),
(
	@builtInMasterDataTypeIdCurrency,
	'NOK',
	'Norwegian Kroner',
	1
),
(
	@builtInMasterDataTypeIdCurrency,
	'CAD',
	'Canadian Dollar',
	1
),
(
	@builtInMasterDataTypeIdCurrency,
	'AUD',
	'Australian Dollar',
	1
)

MERGE INTO [dbo].[Currency] AS target
USING #CurrencyTemp AS source
ON target.[CurrencyCode] = source.[CurrencyCode]
WHEN NOT MATCHED THEN
INSERT
(
	[MasterDataTypeId],
	[CurrencyCode],
	[CurrencyName],
	[ActiveStatus]
)
VALUES
(
	source.[MasterDataTypeId],
	source.[CurrencyCode],
	source.[CurrencyName],
	source.[ActiveStatus]
);

DROP TABLE #CurrencyTemp