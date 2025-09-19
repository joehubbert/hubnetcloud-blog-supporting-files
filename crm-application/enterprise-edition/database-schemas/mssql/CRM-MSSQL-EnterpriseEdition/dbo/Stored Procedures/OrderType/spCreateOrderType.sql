CREATE PROCEDURE [dbo].[spCreateOrderType]
	@activeStatus BIT,
	@orderType NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderTypeTemp
			(
				[OrderType] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #OrderTypeTemp
			(
				[OrderType],
				[ActiveStatus]
			)
			VALUES
			(
				@orderType,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[OrderType] OT
			INNER JOIN #OrderTypeTemp OTT ON OT.[OrderType] = OTT.[OrderType]
			WHERE OT.[OrderType] = OTT.[OrderType]
			)
			THROW 50000, 'Order Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[OrderType] AS target
			USING #OrderTypeTemp AS source
			ON target.[OrderType] = source.[OrderType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[OrderType],
				[ActiveStatus]
			)
			VALUES
			(
				source.[OrderType],
				source.[ActiveStatus]
			);

			DROP TABLE #OrderTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END