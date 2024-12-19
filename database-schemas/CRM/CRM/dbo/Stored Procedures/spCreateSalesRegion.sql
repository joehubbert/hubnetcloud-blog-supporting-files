CREATE PROCEDURE [dbo].[spCreateSalesRegion]
	@salesRegion NVARCHAR(50)
AS

CREATE TABLE #SalesRegionTemp
(
	[SalesRegion] NVARCHAR(50) NOT NULL
)

INSERT INTO #SalesRegionTemp
(
	[SalesRegion]
)
VALUES
(
	@salesRegion
)

IF EXISTS
(
SELECT *
FROM [dbo].[SalesRegion] SR
INNER JOIN #SalesRegionTemp SRT ON SR.[SalesRegion] = SRT.[SalesRegion]
WHERE SR.[SalesRegion] = SRT.[SalesRegion]
)
THROW 50000, 'Sales Region already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[SalesRegion] AS target
USING #SalesRegionTemp AS source
ON target.[SalesRegion] = source.[SalesRegion]
WHEN NOT MATCHED THEN
INSERT
(
	[SalesRegion]
)
VALUES
(
	source.[SalesRegion]
);

DROP TABLE #SalesRegionTemp;