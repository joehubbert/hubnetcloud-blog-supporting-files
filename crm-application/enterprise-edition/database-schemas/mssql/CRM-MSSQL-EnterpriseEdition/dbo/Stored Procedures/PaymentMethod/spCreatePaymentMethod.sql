CREATE PROCEDURE [dbo].[spCreatePaymentMethod]
	@activeStatus BIT,
    @companyConfigurationId UNIQUEIDENTIFIER = NULL,
	@paymentMethod NVARCHAR(50),
    @masterDataTypeId UNIQUEIDENTIFIER
AS

BEGIN
	BEGIN TRY
		SET TRANSACTION ISOLATION LEVEL SNAPSHOT;
		BEGIN TRANSACTION;

			CREATE TABLE #PaymentMethodTemp
			(
                [MasterDataTypeId] UNIQUEIDENTIFIER NOT NULL,
				[PaymentMethod] NVARCHAR(50) NOT NULL,
                [CompanyConfigurationId] UNIQUEIDENTIFIER NULL,
				[ActiveStatus] BIT NOT NULL
			)

			INSERT INTO #PaymentMethodTemp
			(
                [MasterDataTypeId],
				[PaymentMethod],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                @masterDataTypeId,
				@paymentMethod,
                @companyConfigurationId,
				@activeStatus
			)

			IF EXISTS
			(
				SELECT *
				FROM [dbo].[PaymentMethod] E
				INNER JOIN #PaymentMethodTemp ET ON E.[PaymentMethod] = ET.[PaymentMethod]
				WHERE E.[PaymentMethod] = ET.[PaymentMethod]
			)
			THROW 50000, 'Payment Method already exists, please update the existing record.', 1;
			ELSE
			MERGE INTO [dbo].[PaymentMethod] AS target
			USING #PaymentMethodTemp AS source
			ON target.[PaymentMethod] = source.[PaymentMethod]
			WHEN NOT MATCHED THEN
			INSERT
			(
                [MasterDataTypeId],
				[PaymentMethod],
                [CompanyConfigurationId],
				[ActiveStatus]
			)
			VALUES
			(
                source.[MasterDataTypeId],
				source.[PaymentMethod],
                source.[CompanyConfigurationId],
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
