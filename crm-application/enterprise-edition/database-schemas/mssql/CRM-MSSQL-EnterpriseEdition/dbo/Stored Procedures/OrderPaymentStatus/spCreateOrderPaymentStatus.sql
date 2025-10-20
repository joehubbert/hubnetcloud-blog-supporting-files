CREATE PROCEDURE [dbo].[spCreateOrderPaymentStatus]
	@activeStatus BIT,
	@orderPaymentStatus NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #OrderPaymentStatusTemp
			(
				[OrderPaymentStatus] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #OrderPaymentStatusTemp
			(
				[OrderPaymentStatus],
				[ActiveStatus]
			)
			VALUES
			(
				@orderPaymentStatus,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[OrderPaymentStatus] OPS
				INNER JOIN #OrderPaymentStatusTemp OPST ON OPS.[OrderPaymentStatus] = OPST.[OrderPaymentStatus]
				WHERE OPS.[OrderPaymentStatus] = OPST.[OrderPaymentStatus]
			)
			THROW 50000, 'Order Payment Status already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[OrderPaymentStatus] AS target
			USING #OrderPaymentStatusTemp AS source
			ON target.[OrderPaymentStatus] = source.[OrderPaymentStatus]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[OrderPaymentStatus],
				[ActiveStatus]
			)
			VALUES
			(
				source.[OrderPaymentStatus],
				source.[ActiveStatus]
			);

			DROP TABLE #OrderPaymentStatusTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END