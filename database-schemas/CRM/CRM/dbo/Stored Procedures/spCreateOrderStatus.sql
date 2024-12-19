CREATE PROCEDURE [dbo].[spCreateOrderStatus]
	@orderStatus NVARCHAR(50)
AS

CREATE TABLE #OrderStatusTemp
(
	[OrderStatus] NVARCHAR(50) NOT NULL
)

INSERT INTO #OrderStatusTemp
(
	[OrderStatus]
)
VALUES
(
	@orderStatus
)

IF EXISTS
(
SELECT *
FROM [dbo].[OrderStatus] OS
INNER JOIN #OrderStatusTemp OST ON OS.[OrderStatus] = OST.[OrderStatus]
WHERE OS.[OrderStatus] = OST.[OrderStatus]
)
THROW 50000, 'Order Status already exists, please update the existing record.', 1;
ELSE
MERGE INTO [dbo].[OrderStatus] AS target
USING #OrderStatusTemp AS source
ON target.[OrderStatus] = source.[OrderStatus]
WHEN NOT MATCHED THEN
INSERT
(
	[OrderStatus]
)
VALUES
(
	source.[OrderStatus]
);

DROP TABLE #OrderStatusTemp;