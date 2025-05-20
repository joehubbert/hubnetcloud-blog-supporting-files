CREATE PROCEDURE [dbo].[spCreateProductSalesRegion]
	@activeStatus BIT,
	@productId UNIQUEIDENTIFIER,
	@salesRegionId UNIQUEIDENTIFIER
AS

CREATE TABLE #ProductSalesRegionTemp
(
	[AcitveStatus] BIT NOT NULL,
	[ProductId] UNIQUEIDENTIFIER NOT NULL,
	[SalesRegionId] UNIQUEIDENTIFIER NOT NULL
)

INSERT INTO #ProductSalesRegionTemp
(
	[AcitveStatus],
	[ProductId],
	[SalesRegionId]
)
VALUES
(
	@activeStatus,
	@productId,
	@salesRegionId
)

IF EXISTS
(
SELECT *
FROM [dbo].[ProductSalesRegion] PSR
INNER JOIN #ProductSalesRegionTemp PSRT ON PSR.[ProductId] = PSRT.[ProductId]
AND PSR.[SalesRegionId] = PSRT.[SalesRegionId]
WHERE PSR.[ProductId] = PSRT.[ProductId]
AND PSR.[SalesRegionId] = PSRT.[SalesRegionId]
)
THROW 50000, 'Product already available in Sales Region, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[ProductSalesRegion] AS target
USING #ProductSalesRegionTemp AS source
ON target.[ProductId] = source.[ProductId]
AND target.[SalesRegionId] = source.[SalesRegionId]
WHEN NOT MATCHED THEN
INSERT
(
	[ActiveStatus],
	[ProductId],
	[SalesRegionId]
)
VALUES
(
	source.[AcitveStatus],
	source.[ProductId],
	source.[SalesRegionId]
);

DROP TABLE #ProductSalesRegionTemp;