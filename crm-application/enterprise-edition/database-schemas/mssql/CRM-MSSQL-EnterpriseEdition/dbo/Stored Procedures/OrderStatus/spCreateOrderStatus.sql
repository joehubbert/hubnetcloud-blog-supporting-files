CREATE PROCEDURE [dbo].[spCreateOrderStatus]
	@activeStatus BIT,
	@orderStatus NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderStatusTemp
			(
				[OrderStatus] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #OrderStatusTemp
			(
				[OrderStatus],
				[ActiveStatus]
			)
			VALUES
			(
				@orderStatus,
				@activeStatus
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
				[OrderStatus],
				[ActiveStatus]
			)
			VALUES
			(
				source.[OrderStatus],
				source.[ActiveStatus]
			);

			DROP TABLE #OrderStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END