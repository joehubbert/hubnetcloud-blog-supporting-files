CREATE TABLE #CurrencyTemp
(
	[CurrencyCode] NCHAR(3) NOT NULL,
	[CurrencyName] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #CurrencyTemp
(
	[CurrencyCode],
	[CurrencyName],
	[ActiveStatus]
) 
VALUES 
(
	'USD',
	'United States Dollar', 
	1
),
(
	'EUR',
	'Euro',
	1
),
(
	'GBP',
	'Pound Sterling',
	1
),
(
	'DKK',
	'Danish Kroner',
	1
),
(
	'SEK',
	'Swedish Kroner',
	1
),
(
	'NOK',
	'Norwegian Kroner',
	1
),
(
	'CAD',
	'Canadian Dollar',
	1
),
(
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
	[CurrencyCode],
	[CurrencyName],
	[ActiveStatus]
)
VALUES
(
	source.[CurrencyCode],
	source.[CurrencyName],
	source.[ActiveStatus]
);

DROP TABLE #CurrencyTemp