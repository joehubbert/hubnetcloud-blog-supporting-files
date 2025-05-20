CREATE PROCEDURE [dbo].[spCreateDeliveryMethod]
	@activeStatus BIT,
	@deliveryCost MONEY,
	@deliveryMethod NVARCHAR(50),	
	@deliveryTimeDays INT,
	@taxProfileId UNIQUEIDENTIFIER
AS

CREATE TABLE #DeliveryMethodTemp
(
	[TaxProfileId] UNIQUEIDENTIFIER NOT NULL,
	[DeliveryMethod] NVARCHAR(50) NOT NULL,
	[DeliveryCost] MONEY NOT NULL,
	[DeliveryTimeDays] INT NOT NULL,
	[ActiveStatus] BIT NOT NULL
)

INSERT INTO #DeliveryMethodTemp
(
	[TaxProfileId],
	[DeliveryMethod],
	[DeliveryCost],
	[DeliveryTimeDays],
	[ActiveStatus]
)
VALUES
(
	@taxProfileId,
	@deliveryMethod,
	@deliveryCost,
	@deliveryTimeDays,
	@activeStatus
)

IF EXISTS
(
SELECT *
FROM [dbo].[DeliveryMethod] DM
INNER JOIN #DeliveryMethodTemp DMT ON DM.[TaxProfileId] = DMT.[TaxProfileId]
AND DM.[DeliveryMethod] = DMT.[DeliveryMethod]
AND DM.[DeliveryCost] = DMT.[DeliveryCost]
AND DM.[DeliveryTimeDays] = DMT.[DeliveryTimeDays]
WHERE DM.[TaxProfileId] = DMT.[TaxProfileId]
AND DM.[DeliveryMethod] = DMT.[DeliveryMethod]
AND DM.[DeliveryCost] = DMT.[DeliveryCost]
AND DM.[DeliveryTimeDays] = DMT.[DeliveryTimeDays]
)
THROW 50000, 'Delivery Method already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[DeliveryMethod] AS target
USING #DeliveryMethodTemp AS source
ON target.[TaxProfileId] = source.[TazProfileId]
AND target.[DeliveryMethod] = source.[DeliveryMethod]
AND target.[DeliveryCost] = source.[DeliveryCost]
AND target.[DeliveryTimeDays] = source.[DeliveryTimeDays]
WHEN NOT MATCHED THEN
INSERT
(
	[TaxProfileId],
	[DeliveryMethod],
	[DeliveryCost],
	[DeliveryTimeDays],
	[ActiveStatus]
)
VALUES
(
	source.[TaxProfileId],
	source.[DeliveryMethod],
	source.[DeliveryCost],
	source.[DeliveryTimeDays],
	source.[ActiveStatus]
);

DROP TABLE #DeliveryMethodTemp;