CREATE PROCEDURE [dbo].[spCreatePaymentMethod]
	@activeStatus BIT,
	@paymentMethod NVARCHAR(50)
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PaymentMethodTemp
			(
				[PaymentMethod] NVARCHAR(50) NOT NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #PaymentMethodTemp
			(
				[PaymentMethod],
				[ActiveStatus]
			)
			VALUES
			(
				@paymentMethod,
				@activeStatus
			)

			IF EXISTS
			(
			SELECT *
			FROM [dbo].[PaymentMethod] PM
			INNER JOIN #PaymentMethodTemp PMT ON PM.[PaymentMethod] = PMT.[PaymentMethod]
			WHERE PM.[PaymentMethod] = PMT.[PaymentMethod]
			)
			THROW 50000, 'Payment Method already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[PaymentMethod] AS target
			USING #PaymentMethodTemp AS source
			ON target.[PaymentMethod] = source.[PaymentMethod]
			WHEN NOT MATCHED THEN
			INSERT
			(
				[PaymentMethod],
				[ActiveStatus]
			)
			VALUES
			(
				source.[PaymentMethod],
				source.[ActiveStatus]
			);

			DROP TABLE #PaymentMethodTemp

		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

		THROW;
	END CATCH
END