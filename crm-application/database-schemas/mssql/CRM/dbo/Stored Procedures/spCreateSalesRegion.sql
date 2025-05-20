CREATE PROCEDURE [dbo].[spCreateSalesRegion]
	@activeStatus BIT,
	@salesRegion NVARCHAR(50)
AS

CREATE TABLE #SalesRegionTemp
(
	[SalesRegion] NVARCHAR(50) NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #SalesRegionTemp
(
	[SalesRegion],
	[ActiveStatus]
)
VALUES
(
	@salesRegion,
	@activeStatus
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
	[SalesRegion],
	[ActiveStatus]
)
VALUES
(
	source.[SalesRegion],
	source.[ActiveStatus]
);

DROP TABLE #SalesRegionTemp;