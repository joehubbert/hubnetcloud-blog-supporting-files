CREATE PROCEDURE [dbo].[spCreateCustomerTier]
	@customerTierCode NCHAR(1),
	@customerTierDescription NVARCHAR(50)
AS

CREATE TABLE #CustomerTierTemp
(
	[CustomerTierCode] NCHAR(1) NOT NULL,
	[CustomerTierDescription] NVARCHAR(50) NOT NULL
)

INSERT INTO #CustomerTierTemp
(
	[CustomerTierCode],
	[CustomerTierDescription]
)
VALUES
(
	@customerTierCode,
	@customerTierDescription
)

IF EXISTS
(
SELECT *
FROM [dbo].[CustomerTier] CT
INNER JOIN #CustomerTierTemp CTT ON CT.[CustomerTierCode] = CTT.[CustomerTierCode]
AND CT.[CustomerTierDescription] = CTT.[CustomerTierDescription]
WHERE CT.[CustomerTierCode] = CTT.[CustomerTierCode]
AND CT.[CustomerTierDescription] = CTT.[CustomerTierDescription]
)
THROW 50000, 'Customer Tier already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[CustomerTier] AS target
USING #CustomerTierTemp AS source
ON target.[CustomerTierCode] = source.[CustomerTierCode]
AND target.[CustomerTierDescription] = source.[CustomerTierDescription]
WHEN NOT MATCHED THEN
INSERT
(
	[CustomerTierCode],
	[CustomerTierDescription]
)
VALUES
(
	source.[CustomerTierCode],
	source.[CustomerTierDescription]
);

DROP TABLE #CustomerTierTemp;