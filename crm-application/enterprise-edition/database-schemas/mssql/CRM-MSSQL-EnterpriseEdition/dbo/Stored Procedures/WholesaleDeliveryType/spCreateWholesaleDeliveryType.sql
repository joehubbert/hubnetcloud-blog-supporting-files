CREATE PROCEDURE [dbo].[spCreateWholesaleDeliveryType]
	@activeStatus BIT,
	@wholesaleDeliveryType NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #WholesaleDeliveryTypeTemp
			(
				[WholesaleDeliveryType] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #WholesaleDeliveryTypeTemp
			(
				[WholesaleDeliveryType],
				[ActiveStatus]
			)
			VALUES
			(
				@wholesaleDeliveryType,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[WholesaleDeliveryType] CT
			INNER JOIN #WholesaleDeliveryTypeTemp CTT ON CT.[WholesaleDeliveryType] = CTT.[WholesaleDeliveryType]
			WHERE CT.[WholesaleDeliveryType] = CTT.[WholesaleDeliveryType]
			)
			THROW 50000, 'Wholesale Delivery Type already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[WholesaleDeliveryType] AS target
			USING #WholesaleDeliveryTypeTemp AS source
			ON target.[WholesaleDeliveryType] = source.[WholesaleDeliveryType]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[WholesaleDeliveryType],
				[ActiveStatus]
			)
			VALUES
			(
				source.[WholesaleDeliveryType],
				source.[ActiveStatus]
			);

			DROP TABLE #WholesaleDeliveryTypeTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END